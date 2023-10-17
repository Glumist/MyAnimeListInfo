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
using System.Diagnostics;

namespace MyAnimeListInfo
{
    public partial class UserControlAnimeInfo : UserControl
    {
        AnimeRecord _record = null;
        //BackgroundWorker bgwImageLoader;
        //AnimeRecordCollection _animeList;

        public UserControlAnimeInfo()
        {
            InitializeComponent();

            dgvAltTitles.AutoGenerateColumns = false;
            dgvRelatedAnime.AutoGenerateColumns = false;
            dgvRecommended.AutoGenerateColumns = false;
            dgvGenres.AutoGenerateColumns = false;

            /*bgwImageLoader = new BackgroundWorker();
            bgwImageLoader.DoWork += BgwImageLoader_DoWork;
            bgwImageLoader.RunWorkerCompleted += BgwImageLoader_RunWorkerCompleted;*/
        }

        public void SetAnime(AnimeRecord record)
        {
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
                    Task.Factory.StartNew(async () => {
                        if (!string.IsNullOrWhiteSpace(_record.ImageAddress) && _record.Id > 0)
                        {
                            await HtmlHelper.DownloadAnimeImage(_record.ImageAddress, GetFilename(_record.Id));
                            SetImage(Image.FromFile(GetFilename(_record.Id)));
                        }
                        //await MalHelper.UpdateAnime(animeRecord);
                        //tlvTree.RefreshObject(record);
                    });
                //bgwImageLoader.RunWorkerAsync(_record);
            }
        }

        private void SetImage(Image image)
        {
            pbImage.Image = image;
            scPic.SplitterDistance = image.Width;
            scTabs.SplitterDistance = image.Height;
        }

        /*private async void BgwImageLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null && e.Argument is AnimeRecord)
            {
                try
                {
                    AnimeRecord record = e.Argument as AnimeRecord;
                    if (!string.IsNullOrWhiteSpace(record.ImageAddress) && record.Id > 0)
                    {
                        await HtmlHelper.DownloadAnimeImage(record.ImageAddress, GetFilename(record.Id));
                        e.Result = record;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+ex.StackTrace);
                }
            }
        }

        private void BgwImageLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is AnimeRecord)
                SetImage(Image.FromFile(GetFilename((e.Result as AnimeRecord).Id)));
        }*/

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

                ShowAnimeWindowAsync(relatedAnime.Id);
            }
        }

        private async void ShowAnimeWindowAsync(int id)
        {
            AnimeRecord anime = AnimeRecordCollection.Get(id);
            if (anime == null)
            {
                anime = new AnimeRecord() { Id = id };
                await MalHelper.UpdateAnime(anime);
                AnimeRecordCollection.AddRelated(anime);
                //await Task.Run(() => HtmlHelper.GetAnimeInfo(anime));
            }

            FormAnimeInfo form = new FormAnimeInfo(anime);
            form.Show();
        }

        private void dgvRecommended_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgvRecommended.SelectedRows.Count > 0 && dgvRecommended.SelectedRows[0].Index != -1)
            {
                RecommendedAnime recAnime = dgvRecommended.SelectedRows[0].DataBoundItem as RecommendedAnime;
                new FormRecommendedAnime(recAnime).Show();
            }*/
        }

        #region Menu

        private async void tsbAdd_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(FormMain.Password))
            //    return;

            try
            {
                _record.UserStatus = UserStatus.Planned;
                await MalHelper.AddAnime(_record.Id);
                //HtmlHelper.ChangeAnime(ChangeAnimeAction.Add, _record, Settings.Load().Username, FormMain.Password);
                Refresh();
                AnimeRecordCollection.AddAndSave(_record);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + Environment.NewLine + ex.Message);
                _record.UserStatus = UserStatus.Unknown;
            }
        }

        private async void tsbEdit_Click(object sender, EventArgs e)
        {
            FormAnimeEdit form = new FormAnimeEdit(_record);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            //ChangeAnimeAction action = _record.UserStatus == UserStatus.Unknown ? ChangeAnimeAction.Delete : ChangeAnimeAction.Update;
            
            //if (string.IsNullOrWhiteSpace(FormMain.Password))
            //    return;

            try
            {
                await MalHelper.ChangeAnime(_record);
                //HtmlHelper.ChangeAnime(action, _record, Settings.Load().Username, FormMain.Password);
                Refresh();
                AnimeRecordCollection.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + Environment.NewLine + ex.Message);
                tsbRefresh_Click(sender, e);
            }
        }

        private async void tsbDelete_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(FormMain.Password))
            //    return;

            try
            {
                await MalHelper.DeleteAnime(_record.Id);
                //HtmlHelper.ChangeAnime(ChangeAnimeAction.Delete, _record, Settings.Load().Username, FormMain.Password);
                _record.UserStatus = UserStatus.Unknown;
                _record.UserStartDate = null;
                _record.UserEndDate = null;
                _record.UserScore = 0;
                _record.Watched = 0;
                Refresh();
                AnimeRecordCollection.DeleteAndSave(_record);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:" + Environment.NewLine + ex.Message);
            }
        }

        private async void tsbAddWatched_Click(object sender, EventArgs e)
        {
            if (_record.Quantity != 0 && _record.Quantity <= _record.Watched)
                return;
            
            //if (string.IsNullOrWhiteSpace(FormMain.Password))
            //    return;

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
                await MalHelper.ChangeAnime(_record);
                //HtmlHelper.ChangeAnime(ChangeAnimeAction.Update, _record, Settings.Load().Username, FormMain.Password);
                Refresh();
                AnimeRecordCollection.Save();
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

        private async void tsbRefresh_Click(object sender, EventArgs e)
        {
            //HtmlHelper.GetAnimeInfo(_record);
            await MalHelper.UpdateAnime(_record);
            if (AnimeRecordCollection.Have(_record.Id))
                AnimeRecordCollection.Save();
            Refresh();
        }

        private void tsbOpenInBrowser_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(HtmlHelper.AnimeInfoAddress + _record.Id) { UseShellExecute = true });
            //System.Diagnostics.Process.Start(HtmlHelper.AnimeInfoAddress + _record.Id);
        }

        #endregion
    }
}