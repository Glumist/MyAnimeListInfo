using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyAnimeListInfo
{
    public partial class UserControlAnimeInfo : UserControl
    {
        AnimeRecord _record = null;
        BackgroundWorker bgwImageLoader;
        AnimeRecordCollection _animeList;

        public UserControlAnimeInfo()
        {
            InitializeComponent();

            dgvAltTitles.AutoGenerateColumns = false;
            dgvRelatedAnime.AutoGenerateColumns = false;
            dgvRecommended.AutoGenerateColumns = false;
            dgvGenres.AutoGenerateColumns = false;

            bgwImageLoader = new BackgroundWorker();
            bgwImageLoader.DoWork += BgwImageLoader_DoWork;
            bgwImageLoader.RunWorkerCompleted += BgwImageLoader_RunWorkerCompleted;
        }

        public void SetAnime(AnimeRecordCollection animeList, AnimeRecord record)
        {
            _animeList = animeList;
            if (_record == record)
                Refresh(true);
            else
            {
                _record = record;
                Refresh(false);
            }
        }

        private void Refresh(bool same = false)
        {
            tbName.Text = _record.Name;
            tbType.Text = _record.Type;
            tbQuantity.Text = _record.Progress;
            tbEpisodeDuration.Text = _record.EpisodeDuration;
            tbStatus.Text = _record.Status;
            tbUserStatus.Text = _record.UserStatusString;
            tbStartDate.Text = _record.StartDate.HasValue ? _record.StartDate.Value.ToShortDateString() : "";
            tbEndDate.Text = _record.EndDate.HasValue ? _record.EndDate.Value.ToShortDateString() : "";
            tbSynopsis.Text = _record.Synopsis;
            dgvAltTitles.DataSource = new List<AlternativeTitle>(_record.AlternativeTitles);
            dgvRelatedAnime.DataSource = new List<RelatedAnime>(_record.RelatedAnime);
            dgvRecommended.DataSource = new List<RecommendedAnime>(_record.RecommendedAnime);
            dgvGenres.DataSource = (new List<String>(_record.Genres)).Select(x => new { GenreName = x }).ToList();

            tsbAdd.Visible = _record.UserStatus == UserStatus.Unknown;
            tsbEdit.Visible = _record.UserStatus != UserStatus.Unknown;
            tsbDelete.Visible = _record.UserStatus != UserStatus.Unknown;
            tsbAddWatched.Visible = _record.UserStatus != UserStatus.Unknown;
            tsbAddWatched.Enabled = _record.Quantity == 0 || _record.Quantity > _record.Watched;

            if (!same)
            {
                string path = GetPicDirectory();
                string fileName = GetFilename(_record.Id);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (File.Exists(fileName))
                    SetImage(Image.FromFile(fileName));
                else
                    bgwImageLoader.RunWorkerAsync(_record);
            }
        }

        private void SetImage(Image image)
        {
            pbImage.Image = image;
            scPic.SplitterDistance = image.Width;
            scTabs.SplitterDistance = image.Height;
        }

        private void BgwImageLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null && e.Argument is AnimeRecord)
            {
                AnimeRecord record = e.Argument as AnimeRecord;
                if (!string.IsNullOrWhiteSpace(record.ImageAddress) && record.Id > 0)
                {
                    HtmlHelper.DownloadAnimeImage(record.ImageAddress, GetFilename(record.Id));
                    e.Result = record;
                }
            }
        }

        private void BgwImageLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is AnimeRecord)
                SetImage(Image.FromFile(GetFilename((e.Result as AnimeRecord).Id)));
        }

        private string GetPicDirectory()
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Pics");
        }

        private string GetFilename(int id)
        {
            return Path.Combine(GetPicDirectory(), "" + id + ".jpg");
        }

        private void dgvRelatedAnime_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvRelatedAnime.SelectedRows.Count > 0)
            {
                RelatedAnime relatedAnime = dgvRelatedAnime.SelectedRows[0].DataBoundItem as RelatedAnime;
                if (relatedAnime == null)
                    return;

                if (relatedAnime.AnimeRecord == null)
                {
                    relatedAnime.AnimeRecord = new AnimeRecord() { Id = relatedAnime.Id };
                    HtmlHelper.GetAnimeInfo(relatedAnime.AnimeRecord, _animeList);
                }

                FormAnimeInfo form = new FormAnimeInfo(relatedAnime.AnimeRecord, _animeList);
                form.Show();
            }
        }

        private void dgvRecommended_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecommended.SelectedRows.Count > 0 && dgvRecommended.SelectedRows[0].Index != -1)
            {
                RecommendedAnime recAnime = dgvRecommended.SelectedRows[0].DataBoundItem as RecommendedAnime;
                new FormRecommendedAnime(recAnime, _animeList).Show();
            }
        }

        #region Menu

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FormMain.Password))
                return;

            try
            {
                _record.UserStatus = UserStatus.Planned;
                HtmlHelper.ChangeAnime(ChangeAnimeAction.Add, _record, Settings.Load().Username, FormMain.Password);
                Refresh();
                _animeList.AddAndSave(_record);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + Environment.NewLine + ex.Message);
                _record.UserStatus = UserStatus.Unknown;
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            FormAnimeEdit form = new FormAnimeEdit(_record);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            ChangeAnimeAction action = _record.UserStatus == UserStatus.Unknown ? ChangeAnimeAction.Delete : ChangeAnimeAction.Update;
            
            if (string.IsNullOrWhiteSpace(FormMain.Password))
                return;

            try
            {
                HtmlHelper.ChangeAnime(action, _record, Settings.Load().Username, FormMain.Password);
                Refresh();
                _animeList.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + Environment.NewLine + ex.Message);
                tsbRefresh_Click(sender, e);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FormMain.Password))
                return;

            try
            {
                HtmlHelper.ChangeAnime(ChangeAnimeAction.Delete, _record, Settings.Load().Username, FormMain.Password);
                _record.UserStatus = UserStatus.Unknown;
                _record.UserStartDate = null;
                _record.UserEndDate = null;
                _record.UserScore = 0;
                _record.Watched = 0;
                Refresh();
                _animeList.DeleteAndSave(_record);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + Environment.NewLine + ex.Message);
            }
        }

        private void tsbAddWatched_Click(object sender, EventArgs e)
        {
            if (_record.Quantity != 0 && _record.Quantity <= _record.Watched)
                return;
            
            if (string.IsNullOrWhiteSpace(FormMain.Password))
                return;

            UserStatus oldStatus = _record.UserStatus;
            DateTime? oldStart = _record.UserStartDate;
            DateTime? oldEnd = _record.UserEndDate;
            if (_record.Watched == 0)
            {
                _record.UserStatus = UserStatus.Watching;
                _record.UserStartDate = DateTime.Today;
            }

            _record.Watched++;

            if (_record.Watched == _record.Quantity)
            {
                _record.UserStatus = UserStatus.Completed;
                _record.UserEndDate = DateTime.Today;
            }

            try
            {
                HtmlHelper.ChangeAnime(ChangeAnimeAction.Update, _record, Settings.Load().Username, FormMain.Password);
                Refresh();
                _animeList.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + Environment.NewLine + ex.Message);
                _record.Watched--;
                _record.UserStatus = oldStatus;
                _record.UserStartDate = oldStart;
                _record.UserEndDate = oldEnd;
                tsbRefresh_Click(sender, e);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            HtmlHelper.GetAnimeInfo(_record, _animeList);
            _animeList.Save();
            Refresh();
        }

        private void tsbOpenInBrowser_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(HtmlHelper.AnimeInfoAddress + _record.Id);
        }

        #endregion
    }
}
