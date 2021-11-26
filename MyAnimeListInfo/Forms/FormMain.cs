using System;
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
using JikanDotNet;

namespace MyAnimeListInfo
{
    public partial class FormMain : Form
    {
        Settings settings;
        //AnimeRecordCollection animeList;
        //AnimeNewsCollection newsList;
        bool inUpdate = false;
        Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager TaskbarProgress = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;

        private static string _password;
        public static string Password
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_password))
                    _password = GetPassword();
                return _password;
            }
            set { _password = value; }
        }

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
            string userName = settings.Username.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Не заполнено поле 'Пользователь' в настройках");
                return;
            }
            tsmiRefresh.Enabled = false;

            IJikan jikan = new Jikan(true);
            int? totalEntries = (await jikan.GetUserProfile(userName)).AnimeStatistics.TotalEntries;
            if (!totalEntries.HasValue)
                return;
            ShowProgress(totalEntries.Value);
            List<AnimeRecord> animeRecords = new List<AnimeRecord>();
            for (int page = 1; page * 300 <= totalEntries.Value; page++)
            {
                UserAnimeList list = await jikan.GetUserAnimeList(userName, page);
                foreach (AnimeListEntry animeEntry in list.Anime)
                    animeRecords.Add(new AnimeRecord(animeEntry));
            }
            //List<AnimeRecord> animeRecords = await Task.Run(() => HtmlHelper.GetAnimeListXml(userName));
            List<AnimeRecord> toAdd = AnimeRecordCollection.SelectNotInList(animeRecords);
            ShowProgress(toAdd.Count);
            for (int i = 0; i < toAdd.Count; i++)
            {
                //await Task.Run(() => HtmlHelper.GetAnimeInfo(toAdd[i]));
                Anime anime = await jikan.GetAnime(toAdd[i].Id);
                if (anime != null)
                    toAdd[i].CopyAnimeInfo(anime);
                else
                    await Task.Run(() => HtmlHelper.GetAnimeInfo(toAdd[i]));

                UpdateProgress(i, toAdd.Count);
            }

            inUpdate = true;
            int updated = AnimeRecordCollection.Update(animeRecords);

            HideProgress();

            RefreshTables();
            MessageBox.Show("Обновлено " + updated + " записей");
            if (updated > 0)
                AnimeRecordCollection.Save();

            inUpdate = false;
            tsmiRefresh.Enabled = true;
        }

        private async void UpdateAnimeAsync()
        {
            tsmiRefresh.Enabled = false;
            ShowProgress(AnimeRecordCollection.Count);
            try
            {
                for (int i = 0; i < AnimeRecordCollection.Count; i++)
                {
                    List<AnimeNews> news = await Task.Run(() => HtmlHelper.GetAnimeInfo(AnimeRecordCollection.GetInstance().AnimeList[i]));
                    if (AnimeRecordCollection.GetInstance().AnimeList[i].UserStatus != UserStatus.Dropped)
                        AnimeNewsCollection.GetInstance().Add(news);
                    UpdateProgress(i, AnimeRecordCollection.Count);
                }
                HideProgress();

                AnimeRecordCollection.Save();
                AnimeNewsCollection.Save();
                RefreshTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tsmiRefresh.Enabled = true;
        }

        #region ShowProgress

        private void ShowProgress(int max)
        {
            if (ShowInTaskbar)
            {
                TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
                TaskbarProgress.SetProgressValue(0, max);
            }
            tspbLoading.Visible = true;
            tspbLoading.Value = 0;
            tspbLoading.Maximum = max;
        }

        private void UpdateProgress(int current, int max)
        {
            tspbLoading.Value = current;
            if (ShowInTaskbar)
                TaskbarProgress.SetProgressValue(current, max);
        }

        private void HideProgress()
        {
            if (ShowInTaskbar)
                TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            tspbLoading.Visible = false;
        }

        #endregion

        #region Tables

        private void RefreshTables()
        {
            dgvAnimeList.AutoGenerateColumns = false;
            dgvSearch.AutoGenerateColumns = false;
            dgvNews.AutoGenerateColumns = false;

            colListUserStatus.Visible = false;
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
                colListUserStatus.Visible = true;

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

            DataGridView dgv = GetCurrentTable();
            if (dgv == null)
                return;
            if (dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                AnimeRecord record = null;
                if (dgv.SelectedRows[0].DataBoundItem is AnimeRecord)
                    record = dgv.SelectedRows[0].DataBoundItem as AnimeRecord;
                else if (dgv.SelectedRows[0].DataBoundItem is AnimeNews)
                    record = (dgv.SelectedRows[0].DataBoundItem as AnimeNews).AnimeRecord;
                if (record != null)
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

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshInfo();
        }

        private void dgvSearch_SelectionChanged(object sender, EventArgs e)
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

        private void Search()
        {
            if (!string.IsNullOrWhiteSpace(tstbSearchText.Text))
            {
                if (string.IsNullOrWhiteSpace(Password))
                    return;

                dgvSearch.DataSource = HtmlHelper.SearchForAnime(tstbSearchText.Text.Trim(), settings.Username, Password);
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

        #endregion
    }
}

// TODO: список аним, связанных с анимами с определенным рейтингом 
// TODO: список аним, рекомендованных анимам с определенным рейтингом
// TODO: переработать ежесуточное обновление
// BUG: null exception в списке новостей
// TODO: сравнение с другими пользователями
// TODO: дерево связанных аним
// TODO: прогрессбар в графе прогресс

/*
получить список анимы 
проверить каких не было в списке 
проверить в связанных, если есть - взять инфу
докачать инфу по новым
проверить отсутствующие в связанных и докачать
обновить инфу в списках
*/
