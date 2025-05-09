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
    public partial class AddArtistForm : Form
    {
        public string ArtistName => txtArtistName.Text.Trim();
        public string ImagePath => selectedImagePath;

        private string selectedImagePath = "";

        public AddArtistForm()
        {
            InitializeComponent();

            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_artist.png");
            if (File.Exists(defaultPath))
            {
                pictureBoxArtist.Image = new Bitmap(defaultPath);
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                pictureBoxArtist.Image = new Bitmap(selectedImagePath);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArtistName.Text))
            {
                MessageBox.Show("Please enter an artist name.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
