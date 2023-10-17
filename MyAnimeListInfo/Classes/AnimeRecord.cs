//using JikanDotNet;
using MalApi;
using MyAnimeListInfo.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace MyAnimeListInfo
{
    public class AnimeRecord
    {
        #region Anime Info

        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _type = "";
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _quantity = 0;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private string _status = "";
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private DateTime? _startDate = null;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        private DateTime? _endDate = null;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        private string _episodeDuration = "";
        public string EpisodeDuration
        {
            get { return _episodeDuration; }
            set { _episodeDuration = value; }
        }

        private List<AlternativeTitle> _alternativeTitles;
        public List<AlternativeTitle> AlternativeTitles
        {
            get { return _alternativeTitles; }
            set { _alternativeTitles = value; }
        }

        private List<RelatedAnime> _relatedAnime;
        public List<RelatedAnime> RelatedAnime
        {
            get { return _relatedAnime; }
            set { _relatedAnime = value; }
        }

        private List<RecommendedAnime> _recommendedAnime;
        public List<RecommendedAnime> RecommendedAnime
        {
            get { return _recommendedAnime; }
            set { _recommendedAnime = value; }
        }

        private List<string> _genres;
        public List<string> Genres
        {
            get { return _genres; }
            set { _genres = value; }
        }

        private string _imageAddress = "";
        public string ImageAddress
        {
            get { return _imageAddress; }
            set { _imageAddress = value; }
        }

        private string _synopsis = "";
        public string Synopsis
        {
            get { return _synopsis; }
            set { _synopsis = value; }
        }

        #region Statistics

        private double _score = 0;
        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private int _rank = -1;
        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        private int _popularity = -1;
        public int Popularity
        {
            get { return _popularity; }
            set { _popularity = value; }
        }

        #endregion

        #endregion

        #region User Info

        private int _userScore = 0;
        public int UserScore
        {
            get { return _userScore; }
            set { _userScore = value; }
        }

        private int _watched = 0;
        public int Watched
        {
            get { return _watched; }
            set { _watched = value; }
        }

        private DateTime? _userStartDate = null;
        public DateTime? UserStartDate
        {
            get { return _userStartDate; }
            set { _userStartDate = value; }
        }

        private DateTime? _userEndDate = null;
        public DateTime? UserEndDate
        {
            get { return _userEndDate; }
            set { _userEndDate = value; }
        }

        private string _userStatus = "";
        [XmlElement("UserStatus")]
        public string UserStatusString
        {
            get { return _userStatus; }
            set { _userStatus = value; }
        }

        [XmlIgnore]
        public UserStatus UserStatus
        {
            get
            {
                switch (UserStatusString)
                {
                    case "Watching": return UserStatus.Watching;
                    case "Completed": return UserStatus.Completed;
                    case "Dropped": return UserStatus.Dropped;
                    case "On-Hold": return UserStatus.OnHold;
                    case "Plan to Watch": return UserStatus.Planned;
                    default: return UserStatus.Unknown;
                }
            }
            set
            {
                switch (value)
                {
                    case UserStatus.Watching: UserStatusString = "Watching"; break;
                    case UserStatus.Completed: UserStatusString = "Completed"; break;
                    case UserStatus.Dropped: UserStatusString = "Dropped"; break;
                    case UserStatus.OnHold: UserStatusString = "On-Hold"; break;
                    case UserStatus.Planned: UserStatusString = "Plan to Watch"; break;
                    default: UserStatusString = ""; break;
                }
            }
        }

        public Image UserStatusIcon { get { return GetIconByStatus(UserStatus); } }
        public string Duration
        {
            get
            {
                TimeSpan result;
                if (UserStartDate.HasValue)
                {
                    if (UserEndDate.HasValue)
                        result = UserEndDate.Value - UserStartDate.Value;
                    else
                        result = DateTime.Today - UserStartDate.Value;
                }
                else
                    return "";
                return "" + (result.TotalDays + 1);
            }
        }

        public string Progress { get { return "" + _watched + " / " + (_quantity > 0 ? "" + _quantity : "∞"); } }

        #endregion

        public AnimeRecord()
        {
            AlternativeTitles = new List<AlternativeTitle>();
            Genres = new List<string>();
            RelatedAnime = new List<RelatedAnime>();
            RecommendedAnime = new List<RecommendedAnime>();
        }

        public AnimeRecord(RelatedAnime related)
            : this()
        {
            Id = related.Id;
            Name = related.Name;
        }

        /*public AnimeRecord(AnimeListEntry animeListEntry)
            : this()
        {
            Id = (int)animeListEntry.Anime.MalId;
            UserScore = animeListEntry.Score;
            Watched = animeListEntry.EpisodesWatched ?? 0;
            UserStartDate = animeListEntry.WatchStartDate;
            UserEndDate = animeListEntry.WatchEndDate;
            switch (animeListEntry.WatchingStatus)
            {
                case UserAnimeWatchingStatus.Completed: UserStatus = UserStatus.Completed; break;
                case UserAnimeWatchingStatus.Dropped: UserStatus = UserStatus.Dropped; break;
                case UserAnimeWatchingStatus.OnHold: UserStatus = UserStatus.OnHold; break;
                case UserAnimeWatchingStatus.PlanToWatch: UserStatus = UserStatus.Planned; break;
                case UserAnimeWatchingStatus.Watching: UserStatus = UserStatus.Watching; break;
                default: UserStatus = UserStatus.Unknown; break;
            }
        }*/

        /*public AnimeRecord(MALAPI.Dto.AnimeListEntry animeEntry)
            : this()
        {
            Id = animeEntry.MyId;
            UserEndDate = (animeEntry.MyEndDate.Ticks != 0 ? animeEntry.MyEndDate : null);
            UserStartDate = (animeEntry.MyStartDate.Ticks != 0 ? animeEntry.MyEndDate : null);
            UserScore = animeEntry.MyScoreInt;
            Watched = animeEntry.MyWatchedEpisodesCount;
            switch (animeEntry.MyStatus)
            {
                case MALAPI.AnimeListStatus.Completed: UserStatus = UserStatus.Completed; break;
                case MALAPI.AnimeListStatus.Dropped: UserStatus = UserStatus.Dropped; break;
                case MALAPI.AnimeListStatus.Onhold: UserStatus = UserStatus.OnHold; break;
                case MALAPI.AnimeListStatus.PlanToWatch: UserStatus = UserStatus.Planned; break;
                case MALAPI.AnimeListStatus.Watching: UserStatus = UserStatus.Watching; break;
                default: UserStatus = UserStatus.Unknown; break;
            }
        }*/

        public AnimeRecord(MalApi.Anime animeEntry)
            : this()
        {
            Id = animeEntry.Id;
            UserEndDate = (animeEntry.UserStatus.FinishDate.Ticks != 0 ? animeEntry.UserStatus.FinishDate : null);
            UserStartDate = (animeEntry.UserStatus.StartDate.Ticks != 0 ? animeEntry.UserStatus.StartDate : null);
            Watched = animeEntry.UserStatus.WatchedEpisodes;
            switch (animeEntry.UserStatus.Score)
            {
                case MalApi.Score.Masterpiece: UserScore = 10; break;
                case MalApi.Score.Great: UserScore = 9; break;
                case MalApi.Score.VeryGood: UserScore = 8; break;
                case MalApi.Score.Good: UserScore = 7; break;
                case MalApi.Score.Fine: UserScore = 6; break;
                case MalApi.Score.Average: UserScore = 5; break;
                case MalApi.Score.Bad: UserScore = 4; break;
                case MalApi.Score.VeryBad: UserScore = 3; break;
                case MalApi.Score.Horrible: UserScore = 2; break;
                case MalApi.Score.Appalling: UserScore = 1; break;
                default: UserScore = 0; break;
            }
            switch (animeEntry.UserStatus.Status)
            {
                case MalApi.AnimeStatus.Completed: UserStatus = UserStatus.Completed; break;
                case MalApi.AnimeStatus.Dropped: UserStatus = UserStatus.Dropped; break;
                case MalApi.AnimeStatus.OnHold: UserStatus = UserStatus.OnHold; break;
                case MalApi.AnimeStatus.PlanToWatch: UserStatus = UserStatus.Planned; break;
                case MalApi.AnimeStatus.Watching: UserStatus = UserStatus.Watching; break;
                default: UserStatus = UserStatus.Unknown; break;
            }
        }

        /*public AnimeRecord(MyAnimeListEntry animeEntry)
            : this()
        {
            Id = animeEntry.AnimeInfo.AnimeId;
            UserEndDate = animeEntry.MyFinishDate.ToDateTime();
            UserStartDate = animeEntry.MyStartDate.ToDateTime();
            Watched = animeEntry.NumEpisodesWatched;
            UserScore = (int)animeEntry.Score;
            switch (animeEntry.Status)
            {
                case CompletionStatus.Completed: UserStatus = UserStatus.Completed; break;
                case CompletionStatus.Dropped: UserStatus = UserStatus.Dropped; break;
                case CompletionStatus.OnHold: UserStatus = UserStatus.OnHold; break;
                case CompletionStatus.PlanToWatch: UserStatus = UserStatus.Planned; break;
                case CompletionStatus.Watching: UserStatus = UserStatus.Watching; break;
                default: UserStatus = UserStatus.Unknown; break;
            }
        }*/

        public bool CopyUserInfo(AnimeRecord record)
        {
            bool updated = false;

            if (UserScore != record.UserScore)
            {
                UserScore = record.UserScore;
                updated = true;
            }

            if (Watched != record.Watched)
            {
                Watched = record.Watched;
                updated = true;
            }

            if (UserStartDate != record.UserStartDate)
            {
                UserStartDate = record.UserStartDate;
                updated = true;
            }

            if (UserEndDate != record.UserEndDate)
            {
                UserEndDate = record.UserEndDate;
                updated = true;
            }

            if (UserStatusString != record.UserStatusString)
            {
                UserStatusString = record.UserStatusString;
                updated = true;
            }

            return updated;
        }

        public bool CopyAnimeInfo(AnimeRecord record)
        {
            bool updated = false;

            if (Name != record.Name)
            {
                Name = record.Name;
                updated = true;
            }

            if (Type != record.Type)
            {
                Type = record.Type;
                updated = true;
            }

            if (Quantity != record.Quantity)
            {
                Quantity = record.Quantity;
                updated = true;
            }

            if (Status != record.Status)
            {
                Status = record.Status;
                updated = true;
            }

            if (StartDate != record.StartDate)
            {
                StartDate = record.StartDate;
                updated = true;
            }

            if (EndDate != record.EndDate)
            {
                EndDate = record.EndDate;
                updated = true;
            }

            if (EpisodeDuration != record.EpisodeDuration)
            {
                EpisodeDuration = record.EpisodeDuration;
                updated = true;
            }

            if (!AlternativeTitle.Equals(AlternativeTitles, record.AlternativeTitles))
            {
                AlternativeTitles = record.AlternativeTitles;
                updated = true;
            }

            if (MyAnimeListInfo.RelatedAnime.Equals(RelatedAnime, record.RelatedAnime))
            {
                RelatedAnime = record.RelatedAnime;
                updated = true;
            }

            if (Genres != record.Genres)
            {
                Genres = record.Genres;
                updated = true;
            }

            if (ImageAddress != record.ImageAddress)
            {
                ImageAddress = record.ImageAddress;
                updated = true;
            }

            if (Synopsis != record.Synopsis)
            {
                Synopsis = record.Synopsis;
                updated = true;
            }

            return updated;
        }

        /*public bool CopyAnimeInfo(AnimeFull record)
        {
            bool updated = false;

            if (Name != record.Title)
            {
                Name = record.Title;
                updated = true;
            }

            if (Type != record.Type)
            {
                Type = record.Type;
                updated = true;
            }

            if (record.Episodes.HasValue && Quantity != record.Episodes.Value)
            {
                Quantity = record.Episodes.Value;
                updated = true;
            }

            if (Status != record.Status)
            {
                Status = record.Status;
                updated = true;
            }

            if (StartDate != record.Aired.From)
            {
                StartDate = record.Aired.From;
                updated = true;
            }

            if (EndDate != record.Aired.To)
            {
                EndDate = record.Aired.To;
                updated = true;
            }

            if (EpisodeDuration != record.Duration)
            {
                EpisodeDuration = record.Duration;
                updated = true;
            }

            List<AlternativeTitle> newTitles = new List<AlternativeTitle>();
            newTitles.Add(new AlternativeTitle() { Language = "English", Title = record.TitleEnglish ?? "" });
            newTitles.Add(new AlternativeTitle() { Language = "Japanese", Title = record.TitleJapanese ?? "" });
            foreach (string title in record.TitleSynonyms)
                newTitles.Add(new AlternativeTitle() { Language = "", Title = record.TitleJapanese });
            if (!AlternativeTitle.Equals(AlternativeTitles, newTitles))
            {
                AlternativeTitles = newTitles;
                updated = true;
            }

            List<RelatedAnime> newRelated = MyAnimeListInfo.RelatedAnime.GetRelatedAnimes(record.Relations);
            if (MyAnimeListInfo.RelatedAnime.Equals(RelatedAnime, newRelated))
            {
                RelatedAnime = newRelated;
                updated = true;
            }

            List<string> newGenres = new List<string>();
            foreach (MalUrl genre in record.Genres)
                newGenres.Add(genre.Name);
            if (Genres != newGenres)
            {
                Genres = newGenres;
                updated = true;
            }

            if (ImageAddress != record.Images.JPG.ImageUrl)
            {
                ImageAddress = record.Images.JPG.ImageUrl;
                updated = true;
            }

            if (Synopsis != record.Synopsis)
            {
                Synopsis = record.Synopsis;
                updated = true;
            }

            return updated;
        }*/

        public List<AnimeNews> CopyAnimeInfo(MalApi.Anime record)
        {
            //bool updated = false;
            List<AnimeNews> news = new List<AnimeNews>();

            if (Name != record.Title)
            {
                Name = record.Title;
                news.Add(new AnimeNews(this, "Name", Name));
            }

            string type = "" + record.MediaType;
            if (!string.IsNullOrWhiteSpace(type) && Type != type)
            {
                Type = type;
                news.Add(new AnimeNews(this, "Type", Type));
            }

            if (record.TotalEpisodes.HasValue && Quantity != record.TotalEpisodes.Value)
            {
                Quantity = record.TotalEpisodes.Value;
                news.Add(new AnimeNews(this, "Quantity", "" + Quantity));
            }

            string status = "" + record.Status;
            if (!string.IsNullOrWhiteSpace(status) && Status != status)
            {
                Status = status;
                news.Add(new AnimeNews(this, "Status", Status));
            }

            if (!string.IsNullOrWhiteSpace(record.StartDate))
                if (DateTime.TryParse(record.StartDate, out DateTime startDate))
                    if (StartDate != startDate)
                    {
                        StartDate = startDate;
                        news.Add(new AnimeNews(this, "StartDate", startDate.ToShortDateString()));
                    }

            if (!string.IsNullOrWhiteSpace(record.EndDate))
                if (DateTime.TryParse(record.EndDate, out DateTime endDate))
                    if (EndDate != endDate)
                    {
                        EndDate = endDate;
                        news.Add(new AnimeNews(this, "EndDate", endDate.ToShortDateString()));
                    }

            if (EpisodeDuration != "" + record.AverageEpisodeDuration / 60)
            {
                EpisodeDuration = "" + (record.AverageEpisodeDuration / 60);
            }

            List<AlternativeTitle> newTitles = new List<AlternativeTitle>();
            newTitles.Add(new AlternativeTitle() { Language = "English", Title = record.AlternativeTitles.English ?? "" });
            newTitles.Add(new AlternativeTitle() { Language = "Japanese", Title = record.AlternativeTitles.Japanese ?? "" });
            foreach (string title in record.AlternativeTitles.Aliases)
                newTitles.Add(new AlternativeTitle() { Language = "", Title = title });
            if (!AlternativeTitle.Equals(AlternativeTitles, newTitles))
            {
                foreach (AlternativeTitle altTitle in newTitles)
                    if (!AlternativeTitles.Exists(at => at.Title == altTitle.Title && at.Language == altTitle.Language))
                        news.Add(new AnimeNews(this, "Alternative Title", altTitle.ToString()));
                AlternativeTitles = newTitles;
            }

            List<RelatedAnime> newRelated = MyAnimeListInfo.RelatedAnime.GetRelatedAnimes(record.RelatedAnime);
            if (!MyAnimeListInfo.RelatedAnime.Equals(RelatedAnime, newRelated))
            {
                foreach (RelatedAnime relatedTitle in newRelated)
                    if (!RelatedAnime.Exists(at => at.Id == relatedTitle.Id))
                        news.Add(new AnimeNews(this, "Related Anime", relatedTitle.ToString()));
                RelatedAnime = newRelated;
            }

            List<RecommendedAnime> newRecommended = MyAnimeListInfo.RecommendedAnime.GetRecommendedAnimes(record.Recommendations);
            if (!MyAnimeListInfo.RecommendedAnime.Equals(RecommendedAnime, newRecommended))
            {
                RecommendedAnime = newRecommended;
            }

            List<string> newGenres = new List<string>();
            foreach (MalApi.Genre genre in record.Genres)
                newGenres.Add(genre.Name);
            if (Genres != newGenres)
            {
                //foreach (string genre in newGenres)
                //    if (!Genres.Contains(genre))
                //        news.Add(new AnimeNews(this, "Genre", genre));
                Genres = newGenres;
            }

            if (ImageAddress != record.MainPicture.Medium)
            {
                ImageAddress = record.MainPicture.Medium;
                //news.Add(new AnimeNews(this, "ImageAddress", ""));
            }

            if (Synopsis != record.Synopsis)
            {
                Synopsis = record.Synopsis;
            }

            if (record.Rank.HasValue && Rank != record.Rank.Value)
            {
                Rank = record.Rank.Value;
            }

            if (record.MeanScore.HasValue && Score != record.MeanScore.Value)
            {
                Score = record.MeanScore.Value;
            }

            if (record.Popularity.HasValue && Popularity != record.Popularity.Value)
            {
                Popularity = record.Popularity.Value;
            }

            return news;
        }

        public override string ToString()
        {
            return Name;
        }

        public static Image GetIconByStatus(UserStatus status)
        {
            switch (status)
            {
                case UserStatus.Watching: return Resources.IconPlay;
                case UserStatus.Completed: return Resources.IconApply;
                case UserStatus.Dropped: return Resources.action_delete_sharp_thick;
                case UserStatus.OnHold: return Resources.iconClock;
                case UserStatus.Planned: return Resources.IconPlus;
                default: return Resources.IconQuestion;
            }
        }

        #region Compare

        public static int CompareByUserStatus(AnimeRecord a, AnimeRecord b)
        {
            if (a.UserStatus == b.UserStatus)
                return CompareByName(a, b);

            return (int)a.UserStatus - (int)b.UserStatus;
        }

        public static int CompareByUserStartDate(AnimeRecord a, AnimeRecord b)
        {
            if (a.UserStartDate.HasValue && b.UserStartDate.HasValue)
                return DateTime.Compare(a.UserStartDate.Value, b.UserStartDate.Value);

            if (a.UserStartDate.HasValue)
                return -1;
            if (b.UserStartDate.HasValue)
                return 1;

            return 0;
        }

        public static int CompareByUserEndDate(AnimeRecord a, AnimeRecord b)
        {
            if (a.UserEndDate.HasValue && b.UserEndDate.HasValue)
                return DateTime.Compare(a.UserEndDate.Value, b.UserEndDate.Value);

            if (a.UserEndDate.HasValue)
                return -1;
            if (b.UserEndDate.HasValue)
                return 1;

            return 0;
        }

        public static int CompareByScore(AnimeRecord a, AnimeRecord b)
        {
            return (int)((b.Score - a.Score) * 100);
        }

        public static int CompareByUserScore(AnimeRecord a, AnimeRecord b)
        {
            if (a.UserScore == b.UserScore)
                return CompareByScore(a, b);
            return b.UserScore - a.UserScore;
        }

        public static int CompareByName(AnimeRecord a, AnimeRecord b)
        {
            return string.Compare(a.Name, b.Name);
        }

        #endregion
    }

    public class AnimeRecordCollection
    {
        private static string fileName = "AnimeList.xml";
        private static AnimeRecordCollection _animeRecordCollection;

        private List<AnimeRecord> _animeList;
        public List<AnimeRecord> AnimeList
        {
            get { return _animeList; }
            set { _animeList = value; }
        }

        private Dictionary<int, AnimeRecord> _animeDictionary;
        [XmlIgnore]
        public Dictionary<int, AnimeRecord> AnimeDictionary
        {
            get { return _animeDictionary; }
            set { _animeDictionary = value; }
        }

        private Dictionary<int, AnimeRecord> _relatedAnimeDictionary;
        [XmlIgnore]
        public Dictionary<int, AnimeRecord> RelatedAnimeDictionary
        {
            get { return _relatedAnimeDictionary; }
            set { _relatedAnimeDictionary = value; }
        }

        private AnimeRecordCollection()
        {
            AnimeList = new List<AnimeRecord>();
            AnimeDictionary = new Dictionary<int, AnimeRecord>();
            RelatedAnimeDictionary = new Dictionary<int, AnimeRecord>();
        }

        public static AnimeRecordCollection GetInstance()
        {
            if (_animeRecordCollection == null)
                _animeRecordCollection = Load();
            return _animeRecordCollection;
        }

        public static int Update(List<AnimeRecord> animeRecords)
        {
            int count = 0;

            foreach (AnimeRecord record in animeRecords)
            {
                if (!Have(record.Id))
                {
                    GetInstance().AnimeList.Add(record);
                    GetInstance().AnimeDictionary.Add(record.Id, record);
                    count++;
                }
                else
                {
                    AnimeRecord oldRecord = GetInstance().AnimeDictionary[record.Id];
                    if (oldRecord.CopyUserInfo(record))
                        count++;
                }
            }

            List<AnimeRecord> toDelete = new List<AnimeRecord>();
            foreach (int id in GetInstance().AnimeDictionary.Keys)
                if (!animeRecords.Exists(ar => ar.Id == id))
                    toDelete.Add(GetInstance().AnimeDictionary[id]);

            count += toDelete.Count;
            foreach (AnimeRecord record in toDelete)
            {
                GetInstance().AnimeList.Remove(record);
                GetInstance().AnimeDictionary.Remove(record.Id);
                record.UserStatus = UserStatus.Unknown;
            }

            return count;
        }

        public static AnimeRecord Get(int id)
        {
            if (GetInstance().AnimeDictionary.ContainsKey(id))
                return GetInstance().AnimeDictionary[id];
            else if (GetInstance().RelatedAnimeDictionary.ContainsKey(id))
                return GetInstance().RelatedAnimeDictionary[id];
            return null;
        }

        public static bool Have(int id)
        { 
            return GetInstance().AnimeDictionary.ContainsKey(id);
        }

        public static int Count
        {
            get { return GetInstance().AnimeList.Count; }
        }

        public static void AddAndSave(AnimeRecord record)
        {
            if (Have(record.Id))
                return;

            GetInstance().AnimeList.Add(record);
            GetInstance().AnimeDictionary.Add(record.Id, record);

            Save();
        }

        public static void DeleteAndSave(AnimeRecord record)
        {
            if (!Have(record.Id))
                return;

            GetInstance().AnimeList.Remove(record);
            GetInstance().AnimeDictionary.Remove(record.Id);

            Save();
        }

        public static void AddRelated(AnimeRecord record)
        {
            if (!GetInstance().RelatedAnimeDictionary.ContainsKey(record.Id))
                GetInstance().RelatedAnimeDictionary.Add(record.Id, record);
        }

        public static List<AnimeRecord> SelectNotInList(List<AnimeRecord> records)
        {
            List<AnimeRecord> newRecords = new List<AnimeRecord>();
            foreach (AnimeRecord record in records)
                if (!GetInstance().AnimeDictionary.ContainsKey(record.Id))
                    newRecords.Add(record);
            return newRecords;
        }

        /*public static List<AnimeListEntry> SelectNotInList(ICollection<AnimeListEntry> records)
        {
            List<AnimeListEntry> newRecords = new List<AnimeListEntry>();
            foreach (AnimeListEntry record in records)
                if (!GetInstance().AnimeDictionary.ContainsKey((int)record.Anime.MalId))
                    newRecords.Add(record);
            return newRecords;
        }*/

        public static void Clear()
        {
            GetInstance().AnimeList.Clear();
            GetInstance().AnimeDictionary.Clear();
            GetInstance().RelatedAnimeDictionary.Clear();
        }

        public static void Save()
        {
            XmlSerializeHelper.SerializeAndSave(fileName, GetInstance());
        }

        private static AnimeRecordCollection Load()
        {
            AnimeRecordCollection result;
            try
            {
                result = fileName.LoadAndDeserialize<AnimeRecordCollection>();
            }
            catch
            {
                return new AnimeRecordCollection();
            }

            foreach (AnimeRecord record in result.AnimeList)
                result.AnimeDictionary[record.Id] = record;

            /*foreach (AnimeRecord record in result.AnimeList)
            {
                foreach (RelatedAnime related in record.RelatedAnime)
                    related.AnimeRecord = result.Get(related.Id);
                foreach (RecommendedAnime recommended in record.RecommendedAnime)
                    recommended.AnimeRecord = result.Get(recommended.Id);
            }*/

            result.AnimeList.Sort(AnimeRecord.CompareByName);

            return result;
        }
    }

    public class AlternativeTitle
    {
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _language = "";
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public override string ToString()
        {
            return Language + ": " + Title;
        }

        public static bool Equals(List<AlternativeTitle> a, List<AlternativeTitle> b)
        {
            foreach (AlternativeTitle at in a)
                if (!b.Exists(bt => bt.Title == at.Title && bt.Language == at.Language))
                    return false;
            foreach (AlternativeTitle bt in b)
                if (!a.Exists(at => bt.Title == at.Title && bt.Language == at.Language))
                    return false;

            return true;
        }
    }

    public class RelatedAnime
    {
        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _relation = "";
        public string Relation
        {
            get { return _relation; }
            set { _relation = value; }
        }

        public DateTime? StartDate { get { return AnimeRecord != null ? AnimeRecord.StartDate : null; } }

        public DateTime? EndDate { get { return AnimeRecord != null ? AnimeRecord.EndDate : null; } }

        public string Type { get { return AnimeRecord != null ? AnimeRecord.Type : ""; } }

        public Image UserStatusIcon { get { return AnimeRecord != null ? AnimeRecord.UserStatusIcon : Resources.IconQuestion; } }

        public RelatedAnime() { }

        /*public RelatedAnime(MalUrl mALUrl, string relation)
            : this()
        {
            Id = (int)mALUrl.MalId;
            Name = mALUrl.Name;
            Relation = relation;
        }*/

        public RelatedAnime(MalApi.RelatedAnime related)
            : this()
        {
            Id = related.Anime.Id;
            Name = related.Anime.Title;
            Relation = related.RelationTypeFormatted;
        }

        public override string ToString()
        {
            return Name;
        }

        //private AnimeRecord _record;
        [XmlIgnore]
        public AnimeRecord AnimeRecord
        {
            get { return AnimeRecordCollection.Get(Id); }
        }

        public UserStatus UserStatus { get { return AnimeRecord != null ? AnimeRecord.UserStatus : MyAnimeListInfo.UserStatus.Unknown; } }

        public static bool Equals(List<RelatedAnime> a, List<RelatedAnime> b)
        {
            foreach (RelatedAnime ra in a)
                if (!b.Exists(rb => rb.Id == ra.Id && rb.Name == ra.Name && rb.Relation == ra.Relation))
                    return false;

            foreach (RelatedAnime rb in b)
                if (!a.Exists(ra => rb.Id == ra.Id && rb.Name == ra.Name && rb.Relation == ra.Relation))
                    return false;

            return true;
        }

        /*public static List<RelatedAnime> GetRelatedAnimes(ICollection<JikanDotNet.RelatedEntry> relatedList)
        {
            List<RelatedAnime> result = new List<RelatedAnime>();
            foreach (RelatedEntry related in relatedList)
                foreach (MalUrl entry in related.Entry)
                    result.Add(new RelatedAnime(entry, related.Relation));

            return result;
        }*/

        public static List<RelatedAnime> GetRelatedAnimes(MalApi.RelatedAnime[] relatedList)
        {
            List<RelatedAnime> result = new List<RelatedAnime>();
            foreach (MalApi.RelatedAnime related in relatedList)
                result.Add(new RelatedAnime(related));

            return result;
        }
    }

    public class RecommendedAnime
    {
        private int _id = 0;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /*private List<Recommendation> _recommendations;
        public List<Recommendation> Recommendations
        {
            get { return _recommendations; }
            set { _recommendations = value; }
        }

        public int RecommendationsCount { get { return Recommendations.Count; } }*/

        private int _count = 0;
        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public Image UserStatusIcon { get { return AnimeRecord != null ? AnimeRecord.UserStatusIcon : Resources.IconQuestion; } }

        public RecommendedAnime()
        {
            //Recommendations = new List<Recommendation>();
        }

        public RecommendedAnime(MalApi.AnimeRecommendations recommendation)
            : this()
        {
            Id = recommendation.Anime.Id;
            Name = recommendation.Anime.Title;
            Count = recommendation.NumberOfRecommendations;
        }

        public override string ToString()
        {
            return Name;
        }

        //private AnimeRecord _record;
        [XmlIgnore]
        public AnimeRecord AnimeRecord
        {
            get { return AnimeRecordCollection.Get(Id); }
        }

        public UserStatus UserStatus { get { return AnimeRecord != null ? AnimeRecord.UserStatus : MyAnimeListInfo.UserStatus.Unknown; } }

        public static List<RecommendedAnime> GetRecommendedAnimes(MalApi.AnimeRecommendations[] recommendations)
        {
            List<RecommendedAnime> result = new List<RecommendedAnime>();
            foreach (MalApi.AnimeRecommendations recommendation in recommendations)
                result.Add(new RecommendedAnime(recommendation));

            return result;
        }

        public static bool Equals(List<RecommendedAnime> a, List<RecommendedAnime> b)
        {
            foreach (RecommendedAnime ra in a)
                if (!b.Exists(rb => rb.Id == ra.Id && rb.Name == ra.Name && rb.Count == ra.Count))
                    return false;

            foreach (RecommendedAnime rb in b)
                if (!a.Exists(ra => rb.Id == ra.Id && rb.Name == ra.Name && rb.Count == ra.Count))
                    return false;

            return true;
        }
    }

    /*public class Recommendation
    {
        private string _author = "";
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private string _text = "";
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }*/

    public enum UserStatus
    {
        Watching,
        Completed,
        OnHold,
        Dropped,
        Planned,
        Unknown
    }

    public enum Relation
    {
        InList,
        Related,
        Recommended,
        Unknown
    }

    public class AnimeNews
    {
        private int _recordId = 0;
        public int RecordId
        {
            get { return _recordId; }
            set { _recordId = value; }
        }

        //private AnimeRecord _record;
        [XmlIgnore]
        public AnimeRecord AnimeRecord
        {
            get { return AnimeRecordCollection.Get(RecordId); }
        }

        private string _field = "";
        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }

        private string _text = "";
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private bool _read = false;
        [XmlIgnore]
        public bool Read
        {
            get { return _read; }
            set { _read = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public AnimeNews()
        { }

        public AnimeNews(AnimeRecord record, string field, string text)
        {
            //_record = record;
            _field = field;
            _text = text;
            _recordId = record.Id;
            _date = DateTime.Now;
        }

        public static int Comparer(AnimeNews a, AnimeNews b)
        {
            return DateTime.Compare(b.Date, a.Date);
        }
    }

    public class AnimeNewsCollection
    {
        private static string fileName = "AnimeNews.xml";
        private static AnimeNewsCollection _animeNewsCollection;

        private List<AnimeNews> _newsList;
        public List<AnimeNews> NewsList
        {
            get { return _newsList; }
            set { _newsList = value; }
        }

        private AnimeNewsCollection()
        {
            _newsList = new List<AnimeNews>();
        }

        public static AnimeNewsCollection GetInstance()
        {
            if (_animeNewsCollection == null)
                _animeNewsCollection = Load();
            return _animeNewsCollection;
        }

        public void Add(List<AnimeNews> news)
        {
            NewsList.AddRange(news);
            NewsList.Sort(AnimeNews.Comparer);
        }

        public static void Clear()
        {
            GetInstance().NewsList.Clear();
        }

        public static void MarkRead()
        {
            GetInstance().NewsList.ForEach(n => n.Read = true);
        }

        public static void Save()
        {
            AnimeNewsCollection unreadNews = new AnimeNewsCollection();
            unreadNews.Add(GetInstance().NewsList.FindAll(n => !n.Read));
            XmlSerializeHelper.SerializeAndSave(fileName, unreadNews);
        }

        private static AnimeNewsCollection Load()
        {
            AnimeNewsCollection result;
            try
            {
                result = fileName.LoadAndDeserialize<AnimeNewsCollection>();
            }
            catch
            {
                return new AnimeNewsCollection();
            }

            return result;
        }
    }
}
