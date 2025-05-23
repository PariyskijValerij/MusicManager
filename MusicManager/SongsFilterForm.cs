using MusicManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicManager
{
    public partial class SongsFilterForm : Form
    {
        public string SongTitle => textTitle.Text.Trim();
        public int? SelectedArtistId => (comboArtist.SelectedItem is Artist artist) ? artist.Id : null;

        public int? YearMin => int.TryParse(txtYearMin.Text, out var y) ? y : (int?)null;
        public int? YearMax => int.TryParse(txtYearMax.Text, out var y) ? y : (int?)null;

        private List<Artist> artists;

        public SongsFilterForm(List<Artist> artists)
        {
            InitializeComponent();
            this.artists = artists;

            var autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(artists.Select(a => a.Name).ToArray());
            comboArtist.AutoCompleteCustomSource = autoSource;

            comboArtist.DataSource = artists;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";
            comboArtist.SelectedIndex = -1;
        }

        public void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
