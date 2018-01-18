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
    public partial class FormAnimeEdit : Form
    {
        private AnimeRecord _record;

        public FormAnimeEdit(AnimeRecord record)
        {
            InitializeComponent();

            cbStatus.Items.Add("В процессе");
            cbStatus.Items.Add("Завершено");
            cbStatus.Items.Add("Отложено");
            cbStatus.Items.Add("Отвергнуто");
            cbStatus.Items.Add("Запланировано");

            _record = record;
            Text = record.Name;

            switch (record.UserStatus)
            {
                case UserStatus.Completed: cbStatus.SelectedIndex = 1; break;
                case UserStatus.Dropped: cbStatus.SelectedIndex = 3; break;
                case UserStatus.OnHold: cbStatus.SelectedIndex = 2; break;
                case UserStatus.Planned: cbStatus.SelectedIndex = 4; break;
                case UserStatus.Watching: cbStatus.SelectedIndex = 0; break;
            }

            nudUserScore.Value = record.UserScore;
            nudWatched.Maximum = record.Quantity != 0 ? record.Quantity : 1000000;
            nudWatched.Value = record.Watched;

            dtpStart.Checked = record.UserStartDate.HasValue;
            if (record.UserStartDate.HasValue)
                dtpStart.Value = record.UserStartDate.Value.Date;
            else
                dtpStart.Value = DateTime.Today;

            dtpEnd.Checked = record.UserEndDate.HasValue;
            if (record.UserEndDate.HasValue)
                dtpEnd.Value = record.UserEndDate.Value.Date;
            else
                dtpEnd.Value = DateTime.Today;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            switch (cbStatus.SelectedIndex)
            {
                case 0: _record.UserStatus = UserStatus.Watching; break;
                case 1: _record.UserStatus = UserStatus.Completed; break;
                case 2: _record.UserStatus = UserStatus.OnHold; break;
                case 3: _record.UserStatus = UserStatus.Dropped; break;
                case 4: _record.UserStatus = UserStatus.Planned; break;
                default: _record.UserStatus = UserStatus.Unknown; break;
            }

            _record.UserScore = (int)nudUserScore.Value;
            _record.Watched = (int)nudWatched.Value;

            if (dtpStart.Checked)
                _record.UserStartDate = dtpStart.Value.Date;
            else
                _record.UserStartDate = null;

            if (dtpEnd.Checked)
                _record.UserEndDate = dtpEnd.Value.Date;
            else
                _record.UserEndDate = null;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
