using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace MyAnimeListInfo
{
    public class HtmlHelper
    {
        public static string GetHtmlString(string url, string login = "", string password = "", Dictionary<string, string> queries = null)
        {
            WebClient client = new WebClient();
            if (login != "" && password != "")
                client.Credentials = new NetworkCredential(login, password);
            client.Proxy = null;
            if (queries != null)
            {
                client.QueryString = new System.Collections.Specialized.NameValueCollection();
                foreach (string key in queries.Keys)
                    client.QueryString.Add(key, queries[key]);
            }
            client.Encoding = Encoding.GetEncoding("utf-8");
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0");
            return client.DownloadString(url);
        }

        private static string GetInnerText(HtmlNode node)
        {
            string result = "";
            foreach (HtmlNode child in node.ChildNodes)
                if (child.Name == "#text" && !child.HasChildNodes)
                    if (!string.IsNullOrWhiteSpace(child.InnerText))
                        result += child.InnerText;

            return GetNormalizedString(result);
        }

        private static string GetNormalizedString(string str)
        {
            return WebUtility.HtmlDecode(str.Trim());
        }

        private static HtmlNode FindNodeByAttribute(IEnumerable<HtmlNode> nodes, string attributeName, string attributeValue)
        {
            foreach (HtmlNode node in nodes)
                if (node.Attributes.ToList().Exists(a => a.Name == attributeName && a.Value == attributeValue))
                    return node;
            return null;
        }

        #region List

        private const string headerClass = "header_title";
        private const string tableHeaderClass = "table_header";
        private const string animeTitleText = "Anime Title";
        private const string listAddress = "https://myanimelist.net/animelist/";

        public static List<AnimeRecord> GetAnimeList(string userName)
        {
            string address = listAddress + userName;

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(GetHtmlString(address));

            string currentStatus = "";
            string[] currentTableHeader = new string[0];
            List<AnimeRecord> result = new List<AnimeRecord>();

            foreach (HtmlNode node in doc.DocumentNode.Element("html").Element("body").Element("div").Elements("table"))
            {
                string newStatus = GetStatus(node);
                if (newStatus != null)
                {
                    currentStatus = newStatus;
                    continue;
                }

                string[] tableHeader = GetTableHeader(node);
                if (tableHeader != null)
                {
                    currentTableHeader = tableHeader;
                    continue;
                }

                string[] tableBody = GetTableBody(node);
                if (tableBody != null && currentTableHeader.Length == tableBody.Length)
                {
                    AnimeRecord record = new AnimeRecord();
                    for (int i = 0; i < tableBody.Length; i++)
                        SetAnimeRecordProperty(record, currentTableHeader[i], tableBody[i]);
                    record.UserStatusString = currentStatus;
                    result.Add(record);
                }
            }

            return result;
        }

        private static string GetStatus(HtmlNode tableNode)
        {
            if (tableNode.Elements("tr").Count() > 1)
                return null;

            HtmlNode trNode = tableNode.Element("tr");

            if (trNode.Elements("td").Count() != 1)
                return null;

            HtmlNode tdNode = trNode.Element("td");

            HtmlNode divNode = tdNode.Element("div");
            if (divNode == null || !divNode.Attributes.ToList().Exists(a => a.Name == "class" && a.Value == headerClass))
                return null;

            HtmlNode spanNode = divNode.Element("span");
            if (spanNode == null)
                return null;

            return GetInnerText(spanNode);
        }

        private static string[] GetTableHeader(HtmlNode tableNode)
        {
            if (tableNode.Elements("tr").Count() > 1)
                return null;

            HtmlNode trNode = tableNode.Element("tr");
            List<string> headers = new List<string>();

            foreach (HtmlNode tdNode in trNode.Elements("td"))
            {
                if (!tdNode.Attributes.ToList().Exists(a => a.Name == "class" && a.Value == tableHeaderClass))
                    return null;

                if (tdNode.Element("b") != null && tdNode.Element("b").Element("span") != null)
                    headers.Add(GetInnerText(tdNode.Element("b").Element("span")));
                else if (tdNode.Element("a") != null && tdNode.Element("a").Element("strong") != null)
                    headers.Add(GetInnerText(tdNode.Element("a").Element("strong")));
                else if (tdNode.Element("strong") != null)
                {
                    if (tdNode.Element("strong").Element("a") != null)
                        headers.Add(GetInnerText(tdNode.Element("strong").Element("a")));
                    else
                        headers.Add(GetInnerText(tdNode.Element("strong")));
                }
            }

            headers.Insert(headers.IndexOf(animeTitleText), "Id");

            return headers.ToArray();
        }

        private static string[] GetTableBody(HtmlNode tableNode)
        {
            if (tableNode.Elements("tr").Count() > 1)
                return null;

            HtmlNode trNode = tableNode.Element("tr");
            List<string> body = new List<string>();

            foreach (HtmlNode tdNode in trNode.Elements("td"))
            {
                if (!tdNode.Attributes.ToList().Exists(a => a.Name == "class" && (a.Value == "td1" || a.Value == "td2")))
                    return null;

                if (tdNode.Element("a") != null)
                {
                    HtmlAttribute href = tdNode.Element("a").Attributes.ToList().Find(a => a.Name == "href");
                    string id = GetIdFromHref(href);
                    if (id != null)
                        body.Add(id);

                    if (tdNode.Element("a").Element("span") != null)
                        body.Add(GetInnerText(tdNode.Element("a").Element("span")));
                }
                else
                    body.Add(GetInnerText(tdNode));
            }

            return body.ToArray();
        }

        private static string GetIdFromHref(HtmlAttribute href)
        {
            if (href == null)
                return null;

            string[] hrefValues = href.Value.Split('/');
            for (int i = 0; i < hrefValues.Length; i++)
                if (hrefValues[i] == "anime" && hrefValues.Length > i + 1)
                    return hrefValues[i + 1];

            return null;
        }

        private static void SetAnimeRecordProperty(AnimeRecord record, string tableHeader, string property)
        {
            switch (tableHeader)
            {
                case "Id":
                    int id;
                    if (int.TryParse(property, out id))
                        record.Id = id;
                    break;
                case animeTitleText:
                    record.Name = property;
                    break;
                case "Score":
                    int score;
                    if (int.TryParse(property, out score))
                        record.UserScore = score;
                    break;
                case "Type":
                    record.Type = property;
                    break;
                case "Progress":
                    string[] values = property.Split('/');
                    int watched;
                    int quantity;
                    if (int.TryParse(values[0], out watched))
                        record.Watched = watched;
                    if (values.Count() > 1 && int.TryParse(values[1], out quantity))
                        record.Quantity = quantity;
                    break;
                case "Started Date":
                    DateTime startDate;
                    if (DateTime.TryParse(property, out startDate))
                        record.UserStartDate = startDate;
                    break;
                case "Finished Date":
                    DateTime endDate;
                    if (DateTime.TryParse(property, out endDate))
                        record.UserEndDate = endDate;
                    break;
            }
        }

        #endregion

        #region API

        #region List XML

        private const string xmlListAddress = "http://myanimelist.net/malappinfo.php?u=";
        private const string xmlListStatus = "&status=all";

        public static List<AnimeRecord> GetAnimeListXml(string userName)
        {
            string address = xmlListAddress + userName + xmlListStatus;

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(GetHtmlString(address));

            List<AnimeRecord> result = new List<AnimeRecord>();

            foreach (HtmlNode listNode in doc.DocumentNode.ChildNodes)
                if (listNode.Name == "myanimelist")
                    foreach (HtmlNode animeNode in listNode.ChildNodes)
                        if (animeNode.Name == "anime")
                        {
                            AnimeRecord record = new AnimeRecord();

                            foreach (HtmlNode attributeNode in animeNode.ChildNodes)
                                switch (attributeNode.Name)
                                {
                                    case "series_animedb_id": record.Id = int.Parse(GetInnerText(attributeNode)); break;
                                    case "series_title": record.Name = GetNormalizedString(GetInnerText(attributeNode)); break;
                                    case "series_type": record.Type = GetTypeFromString(GetInnerText(attributeNode)); break;
                                    case "series_episodes": record.Quantity = int.Parse(GetInnerText(attributeNode)); break;
                                    case "my_watched_episodes": record.Watched = int.Parse(GetInnerText(attributeNode)); break;
                                    case "series_image": record.ImageAddress = GetInnerText(attributeNode); break;
                                    case "series_start":
                                        DateTime seriesStartDate;
                                        if (DateTime.TryParse(GetInnerText(attributeNode), out seriesStartDate))
                                            record.StartDate = seriesStartDate;
                                        break;
                                    case "series_end":
                                        DateTime seriesEndDate;
                                        if (DateTime.TryParse(GetInnerText(attributeNode), out seriesEndDate))
                                            record.EndDate = seriesEndDate;
                                        break;
                                    case "my_start_date":
                                        DateTime startDate;
                                        if (DateTime.TryParse(GetInnerText(attributeNode), out startDate))
                                            record.UserStartDate = startDate;
                                        break;
                                    case "my_finish_date":
                                        DateTime finishDate;
                                        if (DateTime.TryParse(GetInnerText(attributeNode), out finishDate))
                                            record.UserEndDate = finishDate;
                                        break;
                                    case "my_score": record.UserScore = int.Parse(GetInnerText(attributeNode)); break;
                                    case "my_status": record.UserStatusString = GetUserStatusFromString(GetInnerText(attributeNode)); break;
                                }
                            result.Add(record);
                        }

            return result;
        }

        private static string GetTypeFromString(string type)
        {
            switch (type)
            {
                case "1": return "TV";
                case "2": return "OVA";
                default: return type;
            }
        }

        private static string GetUserStatusFromString(string userStatus)
        {
            switch (userStatus)
            {
                case "1": return "Watching";
                case "2": return "Completed";
                case "3": return "On-Hold";
                case "4": return "Dropped";
                case "6": return "Plan to Watch";
                default: return "";
            }
        }

        #endregion

        #region Search

        private const string xmlSearchAddress = "https://myanimelist.net/api/anime/search.xml?q=";

        public static List<AnimeRecord> SearchForAnime(AnimeRecordCollection animeList, string text, string login, string password)
        {
            string address = xmlSearchAddress + text.Replace(" ", "+");

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(GetHtmlString(address, login, password));

            List<AnimeRecord> result = new List<AnimeRecord>();

            foreach (HtmlNode animeNode in doc.DocumentNode.ChildNodes)
                if (animeNode.Name == "anime")
                {
                    foreach (HtmlNode entryNode in animeNode.ChildNodes)
                        if (entryNode.Name == "entry")
                        {
                            AnimeRecord record = new AnimeRecord();
                            bool haveRecord = false;

                            foreach (HtmlNode attributeNode in entryNode.ChildNodes)
                            {
                                switch (attributeNode.Name)
                                {
                                    case "id":
                                        int id = int.Parse(GetInnerText(attributeNode));
                                        AnimeRecord havingRecord = animeList.Get(id);
                                        if (havingRecord != null)
                                        {
                                            haveRecord = true;
                                            record = havingRecord;
                                        }
                                        else
                                            record.Id = id;
                                        break;
                                    case "title": record.Name = GetInnerText(attributeNode); break;
                                    case "synopsis": record.Synopsis = GetNormalizedString(GetInnerText(attributeNode)); break;
                                    case "type": record.Type = GetTypeFromString(GetInnerText(attributeNode)); break;
                                    case "episodes": record.Quantity = int.Parse(GetInnerText(attributeNode)); break;
                                    case "image": record.ImageAddress = GetInnerText(attributeNode); break;
                                    case "start_date":
                                        DateTime seriesStartDate;
                                        if (DateTime.TryParse(GetInnerText(attributeNode), out seriesStartDate))
                                            record.StartDate = seriesStartDate;
                                        break;
                                    case "end_date":
                                        DateTime seriesEndDate;
                                        if (DateTime.TryParse(GetInnerText(attributeNode), out seriesEndDate))
                                            record.EndDate = seriesEndDate;
                                        break;
                                }
                                if (haveRecord)
                                    break;
                            }
                            result.Add(record);
                        }
                }

            return result;
        }

        #endregion

        #region Change

        private const string apiChangeAddress = "https://myanimelist.net/api/animelist/";

        private static int GetUserStatusInt(UserStatus status)
        {
            switch (status)
            {
                case UserStatus.Watching: return 1;
                case UserStatus.Completed: return 2;
                case UserStatus.OnHold: return 3;
                case UserStatus.Dropped: return 4;
                case UserStatus.Planned: return 6;
                default: return 0;
            }
        }

        private static XmlDocument CreateXmlFromAnime(AnimeRecord record)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlNode entryNode = doc.CreateNode(XmlNodeType.Element, "entry", "");
            doc.AppendChild(entryNode);

            XmlNode episodeNode = doc.CreateNode(XmlNodeType.Element, "episode", "");
            episodeNode.InnerText = "" + record.Watched;
            entryNode.AppendChild(episodeNode);

            int userStatus = GetUserStatusInt(record.UserStatus);
            if (userStatus != 0)
            {
                XmlNode statusNode = doc.CreateNode(XmlNodeType.Element, "status", "");
                statusNode.InnerText = "" + userStatus;
                entryNode.AppendChild(statusNode);
            }

            XmlNode scoreNode = doc.CreateNode(XmlNodeType.Element, "score", "");
            scoreNode.InnerText = "" + record.UserScore;
            entryNode.AppendChild(scoreNode);

            if (record.UserStartDate.HasValue)
            {
                XmlNode startNode = doc.CreateNode(XmlNodeType.Element, "date_start", "");
                startNode.InnerText = string.Format("{0:MMddyyyy}", record.UserStartDate.Value);
                entryNode.AppendChild(startNode);
            }
            if (record.UserEndDate.HasValue)
            {
                XmlNode endNode = doc.CreateNode(XmlNodeType.Element, "date_finish", "");
                endNode.InnerText = string.Format("{0:MMddyyyy}", record.UserEndDate.Value);
                entryNode.AppendChild(endNode);
            }

            return doc;
        }

        public static void ChangeAnime(ChangeAnimeAction action, AnimeRecord record, string login, string password)
        {
            string actionString;
            switch (action)
            {
                case ChangeAnimeAction.Add: actionString = "add"; break;
                case ChangeAnimeAction.Update: actionString = "update"; break;
                case ChangeAnimeAction.Delete: actionString = "delete"; break;
                default: return;
            }
            string address = apiChangeAddress + actionString + "/" + record.Id + ".xml";

            string animeXml = CreateXmlFromAnime(record).InnerXml;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            queries.Add("data", animeXml);

            GetHtmlString(address, login, password, queries);
        }

        #endregion

        #endregion

        #region AnimeInfo

        private const string myanimelistId = "myanimelist";
        private const string wrapperClass = "wrapper";
        private const string contentWrapperId = "contentWrapper";
        private const string contentId = "content";
        private const string borderClass = "borderClass";
        private const string titlePropertyValue = "og:title";
        private const string imagePropertyValue = "og:image";
        private const string urlPropertyValue = "og:url";
        private const string recommendationsAddition = "/userrecs";
        private const string altTiltlesName = "Alternative Titles";
        private const string statisticsName = "Statistics";
        private const string darkTextClass = "dark_text";
        private const string ratingValueItemprop = "ratingValue";
        private const string descriptionItemprop = "description";
        private const string relatedAnimeClass = "anime_detail_related_anime";
        public const string AnimeInfoAddress = "https://myanimelist.net/anime/";

        public static List<AnimeNews> GetAnimeInfo(AnimeRecord record, AnimeRecordCollection currentAnimeList)
        {
            List<AnimeNews> news = new List<AnimeNews>();
            string address = AnimeInfoAddress + record.Id;

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(GetHtmlString(address));

            string title = GetNormalizedString(GetMetaProperty(doc.DocumentNode, titlePropertyValue));
            if (title != null)
            {
                if (record.Name != title)
                    news.Add(new AnimeNews(record, "Name", title));
                record.Name = title;
            }

            string imageAddress = GetMetaProperty(doc.DocumentNode, imagePropertyValue);
            if (imageAddress != null)
            {
                if (record.ImageAddress != imageAddress)
                    news.Add(new AnimeNews(record, "ImageAddress", ""));
                record.ImageAddress = imageAddress;
            }

            string xpath = "html/body";
            xpath += "/div[@id='" + myanimelistId + "']";
            xpath += "/div[contains(@class,'" + wrapperClass + "')]";
            xpath += "/div[@id='" + contentWrapperId + "']";
            xpath += "/div[@id='" + contentId + "']";
            xpath += "/table/tr/td";

            HtmlNodeCollection tableRowNodes = doc.DocumentNode.SelectNodes(xpath);
            if (tableRowNodes != null)
                foreach (HtmlNode contentTdNode in tableRowNodes)
                {
                    if (contentTdNode.Attributes.ToList().Exists(a => a.Name == "class" && a.Value == borderClass))
                    {
                        List<AlternativeTitle> alternativeTitles = GetAlternativeTitles(contentTdNode);
                        foreach (AlternativeTitle altTitle in alternativeTitles)
                            if (!record.AlternativeTitles.Exists(at => at.Title == altTitle.Title && at.Language == altTitle.Language))
                                news.Add(new AnimeNews(record, "Alternative Title", altTitle.ToString()));
                        record.AlternativeTitles = alternativeTitles;
                        news.AddRange(SetAnimeInfo(record, contentTdNode));
                        SetAnimeStatistic(record, contentTdNode);
                    }
                    else
                    {
                        HtmlNodeCollection tableCols = contentTdNode.SelectNodes("//table/tr");

                        foreach (HtmlNode trNode in tableCols)
                        {
                            HtmlNode synopsisSpanNode = trNode.SelectSingleNode("td/span[@itemprop='" + descriptionItemprop + "']");
                            if (synopsisSpanNode != null)
                                record.Synopsis = GetInnerText(synopsisSpanNode);

                            HtmlNode relatedTableNode = trNode.SelectSingleNode("td/table[@class='" + relatedAnimeClass + "']");
                            if (relatedTableNode == null)
                                continue;
                            HtmlNode relatedTrNode = relatedTableNode.Element("tr");
                            if (relatedTrNode == null)
                                continue;

                            List<RelatedAnime> relatedTitles = GetRelatedAnime(relatedTrNode, currentAnimeList);
                            foreach (RelatedAnime relatedTitle in relatedTitles)
                                if (!record.RelatedAnime.Exists(at => at.Id == relatedTitle.Id))
                                    news.Add(new AnimeNews(record, "Related Anime", relatedTitle.ToString()));
                            record.RelatedAnime = relatedTitles;
                        }
                    }
                }

            string loadedAddress = GetMetaProperty(doc.DocumentNode, urlPropertyValue);
            if (loadedAddress != null)
            {
                List<RecommendedAnime> recommendedTitles = GetRecommendedAnime(loadedAddress + recommendationsAddition, currentAnimeList);
                /*foreach (RecommendedAnime recommendedTitle in recommendedTitles)
                    if (!record.RecommendedAnime.Exists(at => at.Id == recommendedTitle.Id))
                        news.Add(new AnimeNews(record, "Recommended Anime", recommendedTitle.ToString()));*/
                record.RecommendedAnime = recommendedTitles;
            }

            return news;
        }

        public static void DownloadAnimeImage(string imageAddress, string localAddress)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(imageAddress, localAddress);
            }
        }

        private static string GetMetaProperty(HtmlNode docNode, string propertyName)
        {
            string xpath = "html/head";
            xpath += "/meta[@property='" + propertyName + "']";

            HtmlNode titleNode = docNode.SelectSingleNode(xpath);
            if (titleNode != null)
                foreach (HtmlAttribute attribute in titleNode.Attributes)
                    if (attribute.Name == "content")
                        return attribute.Value;

            return null;
        }

        private static List<AlternativeTitle> GetAlternativeTitles(HtmlNode tdNode)
        {
            List<AlternativeTitle> result = new List<AlternativeTitle>();

            HtmlNode nextNode = tdNode.ChildNodes.FindFirst("h2");

            while (nextNode != null && nextNode.ParentNode.LastChild != nextNode && nextNode.Name != "br")
            {
                nextNode = nextNode.NextSibling;
                if (nextNode.Name == "div")
                {
                    HtmlNode spanNode = nextNode.Element("span");
                    if (spanNode != null)
                    {
                        string language = GetInnerText(spanNode).Trim();
                        result.Add(new AlternativeTitle() { Language = language.Remove(language.Length - 1), Title = GetInnerText(nextNode).Trim() });
                    }
                }
            }

            return result;
        }

        private static List<AnimeNews> SetAnimeInfo(AnimeRecord record, HtmlNode tdNode)
        {
            List<AnimeNews> news = new List<AnimeNews>();
            foreach (HtmlNode div in tdNode.Element("div").Elements("div"))
            {
                HtmlNode spanNode = div.Element("span");
                if (spanNode == null)
                    continue;

                string spanText = GetInnerText(spanNode);

                switch (spanText)
                {
                    case "Type:":
                        string newType = GetInnerText(div).Trim();
                        if (string.IsNullOrEmpty(newType))
                        {
                            HtmlNode node = div.Element("a");
                            if (node == null)
                                break;
                            newType = GetInnerText(node).Trim();
                        }
                        if (newType != record.Type)
                            news.Add(new AnimeNews(record, "Type", newType));
                        record.Type = newType;
                        break;
                    case "Episodes:":
                        int quantity;
                        if (int.TryParse(GetInnerText(div), out quantity))
                        {
                            if (quantity != record.Quantity)
                                news.Add(new AnimeNews(record, "Quantity", "" + quantity));
                            record.Quantity = quantity;
                        }
                        break;
                    case "Status:":
                        string newStatus = GetInnerText(div).Trim();
                        if (newStatus != record.Status)
                            news.Add(new AnimeNews(record, "Status", newStatus));
                        record.Status = newStatus;
                        break;
                    case "Aired:":
                        string[] datesStrings = Regex.Split(GetInnerText(div).Trim(), "to");
                        DateTime startDate;
                        DateTime endDate;
                        if (datesStrings.Length > 0 && DateTime.TryParse(datesStrings[0], out startDate))
                        {
                            if (startDate != record.StartDate)
                                news.Add(new AnimeNews(record, "StartDate", startDate.ToShortDateString()));
                            record.StartDate = startDate;
                        }
                        if (datesStrings.Length > 1 && DateTime.TryParse(datesStrings[1], out endDate))
                        {
                            if (endDate != record.EndDate)
                                news.Add(new AnimeNews(record, "EndDate", endDate.ToShortDateString()));
                            record.EndDate = endDate;
                        }
                        break;
                    case "Genres:":
                        List<string> genres = new List<string>();
                        foreach (HtmlNode aNode in div.Elements("a"))
                        {
                            string genre = GetInnerText(aNode);
                            if (!record.Genres.Contains(genre))
                                news.Add(new AnimeNews(record, "Genre", genre));
                            genres.Add(genre);
                        }
                        record.Genres = genres;
                        break;
                    case "Duration:":
                        record.EpisodeDuration = GetInnerText(div).Trim();
                        break;
                }
            }

            return news;
        }

        private static void SetAnimeStatistic(AnimeRecord record, HtmlNode contentWrapperDivNode)
        {
            HtmlNode statNode = contentWrapperDivNode.Element("div").ChildNodes.ToList().Find(n => n.Name == "h2" && GetInnerText(n) == statisticsName);
            if (statNode == null)
                return;

            while (statNode.ParentNode.LastChild != statNode)
            {
                statNode = statNode.NextSibling;
                HtmlNode spanNode = statNode.SelectSingleNode("span[@class='" + darkTextClass + "']");
                if (spanNode == null)
                    continue;

                switch (GetInnerText(spanNode))
                {
                    case "Score:":
                        HtmlNode scoreValueNode = statNode.SelectSingleNode("span[@itemprop='" + ratingValueItemprop + "']");
                        double score;
                        if (scoreValueNode != null && double.TryParse(GetInnerText(scoreValueNode), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out score))
                            record.Score = score;
                        break;
                    case "Ranked:":
                        string[] rankStrings = GetInnerText(statNode).Split('#');
                        int rank;
                        if (rankStrings.Length > 1 && int.TryParse(rankStrings[1], out rank))
                            record.Rank = rank;
                        break;
                    case "Popularity:":
                        string[] popularityStrings = GetInnerText(statNode).Split('#');
                        int popularity;
                        if (popularityStrings.Length > 1 && int.TryParse(popularityStrings[1], out popularity))
                            record.Popularity = popularity;
                        break;
                }
            }
        }

        private static List<RelatedAnime> GetRelatedAnime(HtmlNode trNode, AnimeRecordCollection currentAnimeList)
        {
            List<RelatedAnime> result = new List<RelatedAnime>();

            string relation = "";
            foreach (HtmlNode tdNode in trNode.Elements("td"))
            {
                if (tdNode.Elements("a").ToList().Count == 0)
                {
                    relation = GetInnerText(tdNode);
                    relation = relation.Remove(relation.Length - 1);
                }
                else
                    foreach (HtmlNode aNode in tdNode.Elements("a"))
                    {
                        HtmlAttribute href = aNode.Attributes.ToList().Find(a => a.Name == "href");
                        string idString = GetIdFromHref(href);
                        if (idString == null)
                            continue;

                        int id = 0;
                        if (int.TryParse(idString, out id))
                            result.Add(new RelatedAnime() { Id = id, Name = GetInnerText(aNode), Relation = relation, AnimeRecord = currentAnimeList.Get(id) });
                    }
            }
            if (trNode.Element("tr") != null)
                result.AddRange(GetRelatedAnime(trNode.Element("tr"), currentAnimeList));

            return result;
        }

        private static List<RecommendedAnime> GetRecommendedAnime(string address, AnimeRecordCollection currentAnimeList)
        {
            List<RecommendedAnime> result = new List<RecommendedAnime>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(GetHtmlString(address));

            string xpath = "//div[@class='" + borderClass + "']";
            xpath += "/table/tr";

            HtmlNodeCollection recAnimeNodes = doc.DocumentNode.SelectNodes(xpath);
            if (recAnimeNodes == null)
                return result;

            foreach (HtmlNode recAnimeNode in recAnimeNodes)
            {
                RecommendedAnime recAnime = new RecommendedAnime();

                foreach (HtmlNode aNode in recAnimeNode.SelectNodes("td/div/a[descendant::strong]"))
                {
                    HtmlAttribute href = aNode.Attributes.ToList().Find(a => a.Name == "href");
                    string idString = GetIdFromHref(href);
                    if (idString == null)
                        continue;

                    int id = 0;
                    if (int.TryParse(idString, out id))
                    {
                        recAnime.Id = id;
                        recAnime.AnimeRecord = currentAnimeList.Get(id);
                        recAnime.Name = GetInnerText(aNode.Element("strong"));
                        break;
                    }
                }

                foreach (HtmlNode recNode in recAnimeNode.SelectNodes(".//div[contains(@class,'" + borderClass + "')]"))
                {
                    Recommendation rec = new Recommendation();
                    rec.Text = GetInnerText(recNode.Element("div"));
                    rec.Author = GetInnerText(recNode.SelectSingleNode("div/a"));

                    recAnime.Recommendations.Add(rec);
                }

                result.Add(recAnime);
            }

            return result;
        }

        #endregion
    }

    public enum ChangeAnimeAction
    {
        Add,
        Update,
        Delete
    }
}
