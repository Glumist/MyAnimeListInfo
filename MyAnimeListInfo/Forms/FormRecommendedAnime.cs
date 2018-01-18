using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeListInfo
{
    public partial class FormRecommendedAnime : Form
    {
        BackgroundWorker _animeLoader;
        RecommendedAnime _recAnime;
        AnimeRecordCollection _animeList;

        public FormRecommendedAnime(RecommendedAnime recAnime, AnimeRecordCollection animeList)
        {
            InitializeComponent();

            _animeLoader = new BackgroundWorker();
            _animeLoader.DoWork += AnimeLoader_DoWork;
            _animeLoader.RunWorkerCompleted += AnimeLoader_RunWorkerCompleted;

            _recAnime = recAnime;
            _animeList = animeList;
            
            if (recAnime.AnimeRecord != null)
                animeInfo.SetAnime(_animeList, _recAnime.AnimeRecord);
            else
                _animeLoader.RunWorkerAsync(recAnime.Id);

            dataGridView1.DataSource = new List<Recommendation>(_recAnime.Recommendations);
        }

        private void AnimeLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            _recAnime.AnimeRecord = new AnimeRecord() { Id = _recAnime.Id };
                HtmlHelper.GetAnimeInfo(_recAnime.AnimeRecord, _animeList);
        }

        private void AnimeLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            animeInfo.SetAnime(_animeList, _recAnime.AnimeRecord);
        }
    }
}
