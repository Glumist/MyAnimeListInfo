using MalApi;
using MalApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MyAnimeListInfo
{
    public class MalHelper
    {
        private static string malClientId = "c2665424ae7c971e13478aa8361cb64d";

        private static OAuthToken _authToken;
        private static OAuthToken AuthToken
        {
            get => _authToken;
            set => _authToken = value;
        }

        public async Task<List<AnimeRecord>> GetUpdateList()
        {
            MalClient client = await GetMalClient();

            int totalEntries = (await client.User()).Statistics.TotalCount;
            OnProgressMaximumDefined(totalEntries);

            List<AnimeRecord> animeRecords = new List<AnimeRecord>();

            for (int page = 0; page * 100 <= totalEntries; page++)
            {
                var list = await client.Anime().OfUser().WithLimit(100).WithOffset(page * 100).WithFields(AnimeFieldNames.UserStatus).Find();
                foreach (var animeEntry in list.Data)
                    animeRecords.Add(new AnimeRecord(animeEntry));
                OnProgressChanged(page * 100);
            }

            List<AnimeRecord> toAdd = AnimeRecordCollection.SelectNotInList(animeRecords);
            OnProgressMaximumDefined(toAdd.Count);
            for (int i = 0; i < toAdd.Count; i++)
            {
                await UpdateAnime(toAdd[i]);

                OnProgressChanged(i);
            }

            return animeRecords;
        }

        public static async Task<List<AnimeNews>> UpdateAnime(AnimeRecord record)
        {
            MalClient client = await GetMalClient();

            Anime anime = await client.Anime().WithId(record.Id)
                    .WithFields(AnimeFieldNames.Title,
                                AnimeFieldNames.MediaType,
                                AnimeFieldNames.TotalEpisodes,
                                AnimeFieldNames.Status,
                                AnimeFieldNames.StartDate,
                                AnimeFieldNames.EndDate,
                                AnimeFieldNames.AverageEpisodeDuration,
                                AnimeFieldNames.AlternativeTitles,
                                AnimeFieldNames.RelatedAnime,
                                AnimeFieldNames.Recommendations,
                                AnimeFieldNames.Genres,
                                AnimeFieldNames.Rank,
                                AnimeFieldNames.Synopsis,
                                AnimeFieldNames.Mean,
                                AnimeFieldNames.Popularity
                    ).Find();

            return record.CopyAnimeInfo(anime);
        }

        public static async Task<List<AnimeRecord>> SearchAnime(string text)
        {
            MalClient client = await GetMalClient();

            List<Anime> animeRecords = (await client.Anime().WithName(text)
                .WithFields(
                    AnimeFieldNames.Synopsis,
                    AnimeFieldNames.MediaType,
                    AnimeFieldNames.TotalEpisodes,
                    AnimeFieldNames.StartDate,
                    AnimeFieldNames.EndDate
                ).Find()).Data;
            List<AnimeRecord> result = new List<AnimeRecord>();

            foreach (Anime anime in animeRecords)
            {
                AnimeRecord havingRecord = AnimeRecordCollection.Get(anime.Id);
                if (havingRecord != null)
                {
                    result.Add(havingRecord);
                    continue;
                }

                AnimeRecord record = new AnimeRecord();
                record.Id = anime.Id;
                record.Name = anime.Title;
                record.Synopsis = anime.Synopsis;
                record.Type = "" + anime.MediaType;
                record.Quantity = anime.TotalEpisodes.HasValue ? anime.TotalEpisodes.Value : 0;
                record.ImageAddress = anime.MainPicture.Medium;

                if (!string.IsNullOrWhiteSpace(anime.StartDate))
                    if (DateTime.TryParse(anime.StartDate, out DateTime startDate))
                        record.StartDate = startDate;
                if (!string.IsNullOrWhiteSpace(anime.EndDate))
                    if (DateTime.TryParse(anime.EndDate, out DateTime endDate))
                        record.EndDate = endDate;

                result.Add(record);
            }

            return result;
        }

        public static async Task AddAnime(int id)
        {
            MalClient client = await GetMalClient();

            await client.Anime().WithId(id).UpdateStatus().WithStatus(AnimeStatus.PlanToWatch).Publish();
        }

        public static async Task ChangeAnime(AnimeRecord record)
        {
            MalClient client = await GetMalClient();
            IUpdateAnimeRequest request = client.Anime().WithId(record.Id).UpdateStatus()
                .WithStatus(GetAnimeStatus(record.UserStatus))
                .WithScore((Score)record.UserScore)
                .WithEpisodesWatched(record.Watched);
            if (record.UserStartDate.HasValue)
                request = request.WithStartDate(record.UserStartDate.Value);
            if (record.UserEndDate.HasValue)
                request = request.WithFinishDate(record.UserEndDate.Value);

            await request.Publish();
        }

        public static async Task DeleteAnime(int id)
        {
            MalClient client = await GetMalClient();

            await client.Anime().WithId(id).RemoveFromList();
        }

        private static AnimeStatus GetAnimeStatus(UserStatus status)
        {
            switch (status)
            {
                case UserStatus.Completed:  return AnimeStatus.Completed;
                case UserStatus.Dropped:  return AnimeStatus.Dropped;
                case UserStatus.OnHold: return AnimeStatus.OnHold;
                case UserStatus.Planned: return AnimeStatus.PlanToWatch;
                case UserStatus.Watching: return AnimeStatus.Watching;
                default: return AnimeStatus.None;
            }
        }

        private static async Task<MalClient> GetMalClient()
        {
            MalClient client = new MalClient();
            client.SetClientId(malClientId);
            OAuthToken token = await GetAuthToken();
            if (token == null)
                throw new Exception("No token");
            client.SetAccessToken(token.AccessToken);

            return client;
        }

        private static async Task<OAuthToken> GetAuthToken()
        {
            if (AuthToken == null)
                await Auth();
            else if (AuthToken.IsExpired)
                await RefreshAuth();
            return AuthToken;
        }

        private static async Task Auth()
        {
            string url = MalAuthHelper.GetAuthUrl(malClientId);
            //Clipboard.SetText(url);
            MessageBox.Show("Одобрите использование и скопируйте адрес после переадресации.");
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });

            FormAskString form = new FormAskString("Введите код", false);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            string[] answerParts = form.ResultText.Split('?');
            string code = "";
            if (answerParts.Length == 1)
                code = form.ResultText;
            else
            {
                string[] parameters = answerParts[1].Split('&');
                foreach (string parameter in parameters)
                {
                    string[] paramParts = parameter.Split('=');
                    if (paramParts[0] == "code")
                    {
                        code = paramParts[1];
                        break;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(code))
                throw new Exception("No code");

            AuthToken = await MalAuthHelper.DoAuth(malClientId, code);
        }

        private static async Task RefreshAuth()
        {
            AuthToken = await MalAuthHelper.RefreshToken(malClientId, AuthToken.RefreshToken);
        }

        public event EventHandler<int> ProgressMaximumDefined;
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected virtual void OnProgressMaximumDefined(int max)
        {
            if (ProgressMaximumDefined != null)
                ProgressMaximumDefined(this, max);
        }

        public event EventHandler<int> ProgressChanged;
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected virtual void OnProgressChanged(int progress)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, progress);
        }

    }
}