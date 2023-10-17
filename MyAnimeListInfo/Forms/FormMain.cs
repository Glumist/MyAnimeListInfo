using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Threading;
//using JikanDotNet;
using MalApi;
using System.Security.AccessControl;
using BrightIdeasSoftware;

namespace MyAnimeListInfo
{
    public partial class FormMain : Form
    {
        Settings settings;
        //AnimeRecordCollection animeList;
        //AnimeNewsCollection newsList;
        bool inUpdate = false;
        //Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager TaskbarProgress = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;

        MalHelper malHelper;

        /*private static string _password;
        public static string Password
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_password))
                    _password = GetPassword();
                return _password;
            }
            set => _password = value;
        }*/

        public FormMain()
        {
            InitializeComponent();

            tscbShowList.Items.Add("Все");
            tscbShowList.Items.Add("Текущие");
            tscbShowList.Items.Add("Завершенные");
            tscbShowList.Items.Add("Отложенные");
            tscbShowList.Items.Add("Отвергнутые");
            tscbShowList.Items.Add("Запланированные");
            tscbShowList.SelectedIndex = 0;

            ilTreeIcons.Images.Add("Watching", AnimeRecord.GetIconByStatus(UserStatus.Watching));
            ilTreeIcons.Images.Add("Completed", AnimeRecord.GetIconByStatus(UserStatus.Completed));
            ilTreeIcons.Images.Add("Dropped", AnimeRecord.GetIconByStatus(UserStatus.Dropped));
            ilTreeIcons.Images.Add("On-Hold", AnimeRecord.GetIconByStatus(UserStatus.OnHold));
            ilTreeIcons.Images.Add("Plan to Watch", AnimeRecord.GetIconByStatus(UserStatus.Planned));
            ilTreeIcons.Images.Add("Unknown", AnimeRecord.GetIconByStatus(UserStatus.Unknown));
            tlvTree.SmallImageList = ilTreeIcons;
            colTreeName.ImageGetter = new ImageGetterDelegate(AnimeRecordImageGetter);
            tlvTree.CanExpandGetter = new TreeListView.CanExpandGetterDelegate (AnimeRecordCanExpandGetter);
            tlvTree.ChildrenGetter = new TreeListView.ChildrenGetterDelegate (AnimeRecordChildrenGetter);

            malHelper = new MalHelper();
            malHelper.ProgressMaximumDefined += MalHelper_ProgressMaximumDefined;
            malHelper.ProgressChanged += MalHelper_ProgressChanged;
        }

        private void MalHelper_ProgressMaximumDefined(object sender, int e)
        {
            ShowProgress(e);
        }

        private void MalHelper_ProgressChanged(object sender, int e)
        {
            UpdateProgress(e);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitAsync();
        }

        private async void InitAsync()
        {
            settings = await Task.Run(() => Settings.Load());
            await Task.Run(() => AnimeRecordCollection.GetInstance());
            await Task.Run(() => AnimeNewsCollection.GetInstance());
            RefreshTables();
        }

        private async void UpdateListAsync()
        {
            /*string userName = settings.Username.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Не заполнено поле 'Пользователь' в настройках");
                return;
            }*/
            tsmiRefresh.Enabled = false;

            try
            {
                List<AnimeRecord> animeRecords = await malHelper.GetUpdateList();
                {
                    /*IJikan jikan = new Jikan();
                    int? totalEntries = (await jikan.GetUserStatisticsAsync(userName)).Data.AnimeStatistics.TotalEntries;
                    if (!totalEntries.HasValue)
                        return;
                    ShowProgress(totalEntries.Value);

                    MalClient client = new MalClient();
                    client.SetClientId(malClientId);
                    OAuthToken token = await GetAuthToken();
                    if (token == null)
                        throw new Exception("No token");
                    client.SetAccessToken(token.AccessToken);

                    for (int page = 0; page * 100 <= totalEntries.Value; page++)
                    {
                        var list = await client.Anime().OfUser(userName).WithLimit(100).WithOffset(page * 100).WithFields(AnimeFieldNames.UserStatus).Find();
                        foreach (var animeEntry in list.Data)
                            animeRecords.Add(new AnimeRecord(animeEntry));*/

                    /*var api = new MALAPI.API(); //Doesn't require authentication.                    
                    var list = api.UsersController.GetUserAnimeList(userName);
                    foreach (var animeEntry in list.Animes)
                        animeRecords.Add(new AnimeRecord(animeEntry));*/

                    /*MalApi.MyAnimeListApi myAnimeListApi  =  new MalApi.MyAnimeListApi();
                    myAnimeListApi.MalApiKey = "c2665424ae7c971e13478aa8361cb64d";
                    MalApi.MalUserLookupResults result = myAnimeListApi.GetAnimeListForUser(userName);
                    foreach (MyAnimeListEntry animeEntry in result.AnimeList)
                        animeRecords.Add(new AnimeRecord(animeEntry));*/

                    /*ICollection<AnimeListEntry> list = (await jikan.GetUserAnimeListAsync(userName)).Data;
                    foreach (AnimeListEntry animeEntry in list)
                        animeRecords.Add(new AnimeRecord(animeEntry));*/
                    /*}
                     //List<AnimeRecord> animeRecords = await Task.Run(() => HtmlHelper.GetAnimeListXml(userName));
                     List<AnimeRecord> toAdd = AnimeRecordCollection.SelectNotInList(animeRecords);
                     ShowProgress(toAdd.Count);
                     for (int i = 0; i < toAdd.Count; i++)
                     {
                         //await Task.Run(() => HtmlHelper.GetAnimeInfo(toAdd[i]));
                         AnimeFull anime = null;
                         try
                         {
                             anime = (await jikan.GetAnimeFullDataAsync(toAdd[i].Id)).Data;
                         }
                         catch { }

                         if (anime != null)
                             toAdd[i].CopyAnimeInfo(anime);
                         else
                             await Task.Run(() => HtmlHelper.GetAnimeInfo(toAdd[i]));

                         UpdateProgress(i, toAdd.Count);
                     }*/
                }
                inUpdate = true;
                int updated = AnimeRecordCollection.Update(animeRecords);

                RefreshTables();
                MessageBox.Show("Обновлено " + updated + " записей");
                if (updated > 0)
                    AnimeRecordCollection.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                HideProgress();

                inUpdate = false;
                tsmiRefresh.Enabled = true;
            }
        }

        private async void UpdateAnimeAsync()
        {
            tsmiRefresh.Enabled = false;
            ShowProgress(AnimeRecordCollection.Count);
            for (int i = 0; i < AnimeRecordCollection.Count; i++)
            {
                try
                {
                    List<AnimeNews> news = await MalHelper.UpdateAnime(AnimeRecordCollection.GetInstance().AnimeList[i]);
                    //Task.Run(() => HtmlHelper.GetAnimeInfo(AnimeRecordCollection.GetInstance().AnimeList[i]));
                    if (AnimeRecordCollection.GetInstance().AnimeList[i].UserStatus != UserStatus.Dropped)
                        AnimeNewsCollection.GetInstance().Add(news);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                UpdateProgress(i);//, AnimeRecordCollection.Count);
            }
            HideProgress();

            AnimeRecordCollection.Save();
            AnimeNewsCollection.Save();
            RefreshTables();
            tsmiRefresh.Enabled = true;
        }

        #region ShowProgress

        private void ShowProgress(int max)
        {
            if (ShowInTaskbar)
            {
                //TaskBarProgress.Progress.SetState(TaskBarProgress.Enums.TaskbarStates.Normal);
                //TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
                //TaskBarProgress.Progress.SetValue(0, max);
                //TaskbarProgress.SetProgressValue(0, max);
            }
            tspbLoading.Visible = true;
            tspbLoading.Value = 0;
            tspbLoading.Maximum = max;
        }

        private void UpdateProgress(int current)
        {
            tspbLoading.Value = current;
            //if (ShowInTaskbar)
            //TaskBarProgress.Progress.SetValue(current, tspbLoading.Maximum);
            //TaskbarProgress.SetProgressValue(current, tspbLoading.Maximum);
        }

        private void HideProgress()
        {
            //if (ShowInTaskbar)
            //TaskBarProgress.Progress.SetState(TaskBarProgress.Enums.TaskbarStates.NoProgress);
            //TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            tspbLoading.Visible = false;
        }

        #endregion

        #region Tables

        private void RefreshTables()
        {
            dgvAnimeList.AutoGenerateColumns = false;
            dgvSearch.AutoGenerateColumns = false;
            dgvNews.AutoGenerateColumns = false;

            colListUserScore.Visible = true;
            colListUserProgress.Visible = true;
            colListUserStartDate.Visible = true;
            colListUserEndDate.Visible = true;
            colListDays.Visible = true;
            colListRating.Visible = false;
            colListStartDate.Visible = false;
            colListEndDate.Visible = false;
            colListPopularity.Visible = false;
            colListQuantity.Visible = false;
            colListScore.Visible = false;

            if (AnimeRecordCollection.GetInstance() == null)
                return;
            List<AnimeRecord> filtered = new List<AnimeRecord>(AnimeRecordCollection.GetInstance().AnimeList);

            if (tscbShowList.SelectedIndex == 0)
            {
                filtered.Sort(AnimeRecord.CompareByUserStatus);
            }
            else if (tscbShowList.SelectedIndex == 1)
            {
                colListUserEndDate.Visible = false;

                filtered = filtered.FindAll(al => al.UserStatus == UserStatus.Watching);
                filtered.Sort(AnimeRecord.CompareByUserStartDate);
            }
            else if (tscbShowList.SelectedIndex == 2)
            {
                colListUserProgress.Visible = false;
                colListScore.Visible = true;

                filtered = filtered.FindAll(al => al.UserStatus == UserStatus.Completed);
                filtered.Sort(AnimeRecord.CompareByUserScore);
            }
            else if (tscbShowList.SelectedIndex == 3)
            {
                colListUserStartDate.Visible = false;
                colListUserEndDate.Visible = false;
                colListDays.Visible = false;

                filtered = filtered.FindAll(al => al.UserStatus == UserStatus.OnHold);
            }
            else if (tscbShowList.SelectedIndex == 4)
            {
                filtered = filtered.FindAll(al => al.UserStatus == UserStatus.Dropped);
            }
            else if (tscbShowList.SelectedIndex == 5)
            {
                colListUserScore.Visible = false;
                colListUserProgress.Visible = false;
                colListUserStartDate.Visible = false;
                colListUserEndDate.Visible = false;
                colListDays.Visible = false;
                colListRating.Visible = true;
                colListStartDate.Visible = true;
                colListEndDate.Visible = true;
                colListPopularity.Visible = true;
                colListQuantity.Visible = true;
                colListScore.Visible = true;

                filtered = filtered.FindAll(al => al.UserStatus == UserStatus.Planned);
                filtered.Sort(AnimeRecord.CompareByScore);
            }

            string filterText = tstbFilter.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(tstbFilter.Text))
                filtered = filtered.FindAll(f => f.Name.ToLower().Contains(filterText)
                    || f.AlternativeTitles.Exists(at => at.Title.ToLower().Contains(filterText)));

            dgvAnimeList.DataSource = filtered;

            dgvNews.DataSource = new List<AnimeNews>(AnimeNewsCollection.GetInstance().NewsList);
        }

        private void RefreshInfo()
        {
            if (inUpdate)
                return;

            AnimeRecord record = GetSelectedAnime();
            if (record != null)
            {
                pAnimeInfo.SetAnime(record);
                pEmpty.SendToBack();
            }
            else
                pEmpty.BringToFront();
        }

        private DataGridView GetCurrentTable()
        {
            if (tcMain.SelectedTab != null)
                foreach (Control control in tcMain.SelectedTab.Controls)
                    if (control is DataGridView)
                        return control as DataGridView;
            return null;
        }

        private AnimeRecord GetSelectedAnime()
        {
            DataGridView dgv = GetCurrentTable();
            if (dgv != null)
            {
                if (dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
                {
                    if (dgv.SelectedRows[0].DataBoundItem is AnimeRecord)
                        return dgv.SelectedRows[0].DataBoundItem as AnimeRecord;
                    else if (dgv.SelectedRows[0].DataBoundItem is AnimeNews)
                        return (dgv.SelectedRows[0].DataBoundItem as AnimeNews).AnimeRecord;
                }
            }
            else
            {
                if (tlvTree.SelectedObject != null)
                    if (tlvTree.SelectedObject is AnimeRecord)
                        return tlvTree.SelectedObject as AnimeRecord;
                    else
                    {
                        AnimeRecord result = (tlvTree.SelectedObject as RelatedAnime).AnimeRecord;
                        if (result == null)
                            result = new AnimeRecord(tlvTree.SelectedObject as RelatedAnime);
                        return result;
                    }
            }

            return null;
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        #endregion

        #region Menu

        private void tscbShowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTables();
        }

        private void tstbFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshTables();
        }

        private void tsmiRefreshInfo_Click(object sender, EventArgs e)
        {
            UpdateAnimeAsync();
        }

        private void tsmiRefreshUserStats_Click(object sender, EventArgs e)
        {
            UpdateListAsync();
        }

        private void tsmiRefreshFull_Click(object sender, EventArgs e)
        {
            AnimeRecordCollection.Clear();
            tsmiRefreshUserStats_Click(sender, e);
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            if (new FormSettings(settings).ShowDialog() == DialogResult.OK)
                settings.Save();
        }

        private void tsmiMarkRead_Click(object sender, EventArgs e)
        {
            AnimeNewsCollection.MarkRead();
            AnimeNewsCollection.Save();
        }

        private void tsmiRemoveAll_Click(object sender, EventArgs e)
        {
            AnimeNewsCollection.Clear();
            AnimeNewsCollection.Save();
        }

        private void tsSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Search();
        }

        private void tsbStartSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private async void Search()
        {
            if (!string.IsNullOrWhiteSpace(tstbSearchText.Text))
            {
                //if (string.IsNullOrWhiteSpace(Password))
                //    return;

                dgvSearch.DataSource = await MalHelper.SearchAnime(tstbSearchText.Text.Trim());
                //HtmlHelper.SearchForAnime(tstbSearchText.Text.Trim(), settings.Username, Password);
            }
        }

        private static string GetPassword()
        {
            Settings settings = Settings.Load();
            if (string.IsNullOrWhiteSpace(settings.Username))
            {
                MessageBox.Show("Не указан пользователь в настройках");
                return null;
            }

            string pass = settings.UserPassword;
            if (string.IsNullOrWhiteSpace(pass))
            {
                FormAskString form = new FormAskString("Введите пароль", true);
                if (form.ShowDialog() == DialogResult.OK)
                    pass = form.ResultText;
            }
            if (string.IsNullOrWhiteSpace(pass))
                return null;

            return pass;
        }

        private void tsmiStartNewTree_Click(object sender, EventArgs e)
        {
            AnimeRecord record = GetSelectedAnime();
            if (record == null)
                return;

            expandedAnimeRecordsIds = new List<int>();

            tlvTree.ClearObjects();
            tlvTree.AddObject(record);

            tcMain.SelectTab(tpTree);
        }

        #endregion

        #region Tree

        List<int> expandedAnimeRecordsIds;

        public object AnimeRecordImageGetter(object record)
        {
            AnimeRecord animeRecord;
            if (record is AnimeRecord)
                animeRecord = (AnimeRecord)record;
            else
                animeRecord = ((RelatedAnime)record).AnimeRecord;

            if (animeRecord == null || animeRecord.UserStatus == UserStatus.Unknown)
                return "Unknown";
            else
                return animeRecord.UserStatusString;
        }

        public bool AnimeRecordCanExpandGetter(object record)
        {
            AnimeRecord animeRecord;
            if (record is AnimeRecord)
                animeRecord = (AnimeRecord)record;
            else
            {
                animeRecord = ((RelatedAnime)record).AnimeRecord;

                if (animeRecord == null)
                {
                    animeRecord = new AnimeRecord() { Id = ((RelatedAnime)record).Id };
                    AnimeRecordCollection.AddRelated(animeRecord);
                    Task.Factory.StartNew(async() => {
                        await MalHelper.UpdateAnime(animeRecord);
                        tlvTree.RefreshObject(record);
                    });
                }
            }

            return expandedAnimeRecordsIds.Contains(animeRecord.Id) || 
                animeRecord.RelatedAnime.FindAll(ra => !expandedAnimeRecordsIds.Contains(ra.Id)).Count > 0;
        }

        public ArrayList AnimeRecordChildrenGetter(object record)
        {
            AnimeRecord animeRecord;
            if (record is AnimeRecord)
                animeRecord = (AnimeRecord)record;
            else
            {
                animeRecord = ((RelatedAnime)record).AnimeRecord;

                if (animeRecord == null)
                {
                    animeRecord = new AnimeRecord() { Id = ((RelatedAnime)record).Id };
                    AnimeRecordCollection.AddRelated(animeRecord);
                    Task.Factory.StartNew(async () => {
                        await MalHelper.UpdateAnime(animeRecord);
                        tlvTree.RefreshObject(record);
                    });
                }
            }

            if (!expandedAnimeRecordsIds.Contains(animeRecord.Id))
                expandedAnimeRecordsIds.Add(animeRecord.Id);

            return new ArrayList(animeRecord.RelatedAnime.FindAll(ra => !expandedAnimeRecordsIds.Contains(ra.Id)));
        }

        #endregion
    }
}

// TODO: список аним, связанных с анимами с определенным рейтингом 
// TODO: список аним, рекомендованных анимам с определенным рейтингом
// TODO: переработать ежесуточное обновление
// BUG: null exception в списке новостей
// TODO: сравнение с другими пользователями
// TODO: прогрессбар в графе прогресс

/*
получить список анимы 
проверить каких не было в списке 
проверить в связанных, если есть - взять инфу
докачать инфу по новым
проверить отсутствующие в связанных и докачать
обновить инфу в списках
*/