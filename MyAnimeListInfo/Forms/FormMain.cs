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

namespace MyAnimeListInfo
{
    public partial class FormMain : Form
    {
        Settings settings;
        AnimeRecordCollection animeList;
        AnimeNewsCollection newsList;
        bool inUpdate = false;
        Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager TaskbarProgress = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;

        BackgroundWorker bgwInitLoader;
        BackgroundWorker bgwListLoader;
        BackgroundWorker bgwInfoUpdater;

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

            dgvAnimeList.AutoGenerateColumns = false;
            dgvSearch.AutoGenerateColumns = false;
            dgvNews.AutoGenerateColumns = false;

            bgwInitLoader = new BackgroundWorker();
            bgwInitLoader.DoWork += BgwInitLoader_DoWork;
            bgwInitLoader.RunWorkerCompleted += BgwInitLoader_RunWorkerCompleted;

            bgwListLoader = new BackgroundWorker();
            bgwListLoader.DoWork += BgwListLoader_DoWork;
            bgwListLoader.RunWorkerCompleted += BgwListLoader_RunWorkerCompleted;
            bgwListLoader.ProgressChanged += BgwListLoader_ProgressChanged;
            bgwListLoader.WorkerReportsProgress = true;

            bgwInfoUpdater = new BackgroundWorker();
            bgwInfoUpdater.DoWork += BgwInfoUpdater_DoWork;
            bgwInfoUpdater.RunWorkerCompleted += BgwInfoUpdater_RunWorkerCompleted;
            bgwInfoUpdater.ProgressChanged += BgwListLoader_ProgressChanged;
            bgwInfoUpdater.WorkerReportsProgress = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            bgwInitLoader.RunWorkerAsync();
        }

        #region Background Workers

        private void BgwInitLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            settings = Settings.Load();
            animeList = AnimeRecordCollection.Load();
            newsList = AnimeNewsCollection.Load(animeList);
        }

        private void BgwInitLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshTables();
        }

        private void BgwListLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null && e.Argument is string)
            {
                List<AnimeRecord> animeRecords = HtmlHelper.GetAnimeListXml(e.Argument as string);
                //Dictionary<int, AnimeRecord> relatedDic = new Dictionary<int, AnimeRecord>();

                List<AnimeRecord> toAdd = animeList.SelectNotInList(animeRecords);
                for (int i = 0; i < toAdd.Count; i++)
                {
                    HtmlHelper.GetAnimeInfo(toAdd[i], animeList);

                    /*foreach (RelatedAnime related in toAdd[i].RelatedAnime)
                    {
                        if (related.AnimeRecord == null)
                            related.AnimeRecord = animeList.Get(related.Id);
                        if (related.AnimeRecord != null)
                            continue;

                        if (relatedDic.ContainsKey(related.Id))
                            related.AnimeRecord = relatedDic[related.Id];
                        else
                        {
                            AnimeRecord rel = new AnimeRecord() { Id = related.Id };
                            HtmlHelper.GetAnimeInfo(rel, animeList);
                            relatedDic.Add(related.Id, rel);
                        }
                    }*/

                    bgwListLoader.ReportProgress(i * 100 / toAdd.Count);
                }

                inUpdate = true;
                e.Result = animeList.Update(animeRecords);
            }
        }

        private void BgwListLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (tspbLoading.Value != e.ProgressPercentage)
            {
                tspbLoading.Value = e.ProgressPercentage;
                if (ShowInTaskbar)
                    TaskbarProgress.SetProgressValue(e.ProgressPercentage, 100);
            }
        }

        private void BgwListLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ShowInTaskbar)
                TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            tspbLoading.Visible = false;
            if (e.Result != null && e.Result is int)
            {
                RefreshTables();
                MessageBox.Show("Обновлено " + (int)e.Result + " записей");
                if ((int)e.Result > 0)
                    animeList.Save();
            }
            inUpdate = false;
            tsmiRefresh.Enabled = true;
        }

        private void BgwInfoUpdater_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < animeList.AnimeList.Count; i++)
            {
                List<AnimeNews> news = HtmlHelper.GetAnimeInfo(animeList.AnimeList[i], animeList);
                if (animeList.AnimeList[i].UserStatus != UserStatus.Dropped)
                    newsList.Add(news);
                bgwInfoUpdater.ReportProgress(i * 100 / animeList.AnimeList.Count);
            }
        }

        private void BgwInfoUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ShowInTaskbar)
                TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            tspbLoading.Visible = false;
            animeList.Save();
            newsList.Save();
            RefreshTables();
            tsmiRefresh.Enabled = true;
        }

        #endregion

        #region Tables

        private void RefreshTables()
        {
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

            if (animeList == null)
                return;
            List<AnimeRecord> filtered = new List<AnimeRecord>(animeList.AnimeList);

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

            dgvNews.DataSource = new List<AnimeNews>(newsList.NewsList);
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
                    pAnimeInfo.SetAnime(animeList, record);
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
            if (ShowInTaskbar)
            {
                TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
                TaskbarProgress.SetProgressValue(0, 100);
            }
            tsmiRefresh.Enabled = false;
            tspbLoading.Visible = true;
            tspbLoading.Value = 0;
            bgwInfoUpdater.RunWorkerAsync();
        }

        private void tsmiRefreshUserStats_Click(object sender, EventArgs e)
        {
            string userName = settings.Username.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Не заполнено поле 'Пользователь' в настройках");
                return;
            }

            if (ShowInTaskbar)
            {
                TaskbarProgress.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
                TaskbarProgress.SetProgressValue(0, 100);
            }
            tspbLoading.Visible = true;
            tspbLoading.Value = 0;
            tsmiRefresh.Enabled = false;
            bgwListLoader.RunWorkerAsync(userName);
        }

        private void tsmiRefreshFull_Click(object sender, EventArgs e)
        {
            animeList.Clear();
            tsmiRefreshUserStats_Click(sender, e);
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            if (new FormSettings(settings).ShowDialog() == DialogResult.OK)
                settings.Save();
        }

        private void tsmiMarkRead_Click(object sender, EventArgs e)
        {
            newsList.MarkRead();
            newsList.Save();
        }

        private void tsmiRemoveAll_Click(object sender, EventArgs e)
        {
            newsList.Clear();
            newsList.Save();
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

                dgvSearch.DataSource = HtmlHelper.SearchForAnime(animeList, tstbSearchText.Text.Trim(), settings.Username, Password);
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
