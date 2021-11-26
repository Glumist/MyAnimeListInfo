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
        RecommendedAnime _recAnime;

        public FormRecommendedAnime(RecommendedAnime recAnime)
        {
            InitializeComponent();

            _recAnime = recAnime;
            
            if (recAnime.AnimeRecord != null)
                animeInfo.SetAnime(_recAnime.AnimeRecord);
            else
                LoadAnime(recAnime.Id);

            dataGridView1.DataSource = new List<Recommendation>(_recAnime.Recommendations);
        }

        private async void LoadAnime(int id)
        {
            AnimeRecord anime = new AnimeRecord() { Id = id };
            await Task.Run(() => HtmlHelper.GetAnimeInfo(anime));
            animeInfo.SetAnime(anime);
        }
    }
}
