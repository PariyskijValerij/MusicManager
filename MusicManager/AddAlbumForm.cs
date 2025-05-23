using MusicManager.Models;

namespace MusicManager
{
    public partial class AddAlbumForm : Form
    {
        public string AlbumTitle => txtTitle.Text.Trim();
        public int? SelectedArtistId => ((Artist)comboArtist.SelectedItem).Id == 0 ? (int?)null : ((Artist)comboArtist.SelectedItem).Id;
        public string ImagePath => selectedImagePath;

        private List<Artist> artists;
        private string selectedImagePath = "";

        public AddAlbumForm(List<Artist> artists)
        {
            InitializeComponent();
            this.artists = artists;

            var artistsWithNone = new List<Artist>
            {
                new Artist { Id = 0, Name = "Unknown Artist" }
            };
            artistsWithNone.AddRange(artists);

            comboArtist.DataSource = artistsWithNone;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";
            comboArtist.SelectedIndex = 0;

            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_album.png");
            if (File.Exists(defaultPath))
            {
                pictureBoxImage.Image = new Bitmap(defaultPath);
            }
        }   

        public AddAlbumForm(List<Artist> artists, Album albumToEdit)
        {
            InitializeComponent();
            this.artists = artists;

            var artistsWithNone = new List<Artist>
            {
                new Artist { Id = 0, Name = "Без виконавця" }
            };
            artistsWithNone.AddRange(artists);

            comboArtist.DataSource = artistsWithNone;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";

            txtTitle.Text = albumToEdit.Title;
            selectedImagePath = albumToEdit.ImagePath;

            if (File.Exists(selectedImagePath))
            {
                using (var img = Image.FromFile(selectedImagePath))
                {
                    pictureBoxImage.Image = new Bitmap(img);
                }
            }
            comboArtist.SelectedValue = albumToEdit.ArtistId ?? 0;
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                pictureBoxImage.Image = new Bitmap(selectedImagePath);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Please enter an album title.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
