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
    public partial class FormAskString : Form
    {
        public string ResultText;

        public FormAskString(string title, bool hidden)
        {
            InitializeComponent();

            Text = title;
            tbInput.UseSystemPasswordChar = hidden;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            ResultText = tbInput.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btOk_Click(sender, e);
        }
    }
}
