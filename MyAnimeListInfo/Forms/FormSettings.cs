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
    public partial class FormSettings : Form
    {
        private Settings _settings;

        public FormSettings(Settings settings)
        {
            InitializeComponent();

            _settings = settings;

            tbUserName.Text = settings.Username;
            tbUserPassword.Text = settings.UserPassword;
            nudScoreForRelated.Value = settings.ScoreForRelated > 10 ? 10 : (settings.ScoreForRelated < 0 ? 0 : settings.ScoreForRelated);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            _settings.Username = tbUserName.Text;
            _settings.UserPassword = tbUserPassword.Text;
            _settings.ScoreForRelated = (int)nudScoreForRelated.Value;

            DialogResult = DialogResult.OK;
        }
    }
}
