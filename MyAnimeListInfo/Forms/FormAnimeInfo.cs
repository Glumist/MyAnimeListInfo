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
    public partial class FormAnimeInfo : Form
    {
        public FormAnimeInfo(AnimeRecord record)
        {
            InitializeComponent();
            UserControlAnimeInfo animeInfo = new UserControlAnimeInfo();
            Controls.Add(animeInfo);
            animeInfo.Dock = DockStyle.Fill;
            animeInfo.SetAnime(record);
        }
    }
}
