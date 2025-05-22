using MusicManager.Models;

namespace MusicManager
{
    public partial class AddSongForm : Form
    {
        public string SongTitle => txtTitle.Text.Trim();
        public int SelectedArtistId => (int)comboArtist.SelectedValue;
        public int ReleaseYear => (int)numericYear.Value;
        public string ImagePath => selectedImagePath;

        private List<Artist> artists;
        private string selectedImagePath = "";

        public AddSongForm(List<Artist> artists)
        {
            InitializeComponent();
            this.artists = artists;

            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");
            if (File.Exists(defaultPath))
            {
                pictureBoxImage.Image = new Bitmap(defaultPath);
            }
        }

        public AddSongForm(List<Artist> artists, Song songToEdit)
        {
            InitializeComponent();
            this.artists = artists;

            comboArtist.DataSource = artists;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";

            txtTitle.Text = songToEdit.Title;
            numericYear.Value = songToEdit.Year;
            selectedImagePath = songToEdit.ImagePath;

            if (File.Exists(selectedImagePath))
            {
                using (var img = Image.FromFile(selectedImagePath))
                {
                    pictureBoxImage.Image = new Bitmap(img);
                }
            }

            comboArtist.SelectedValue = songToEdit.ArtistId;
        }

        private void AddSongForm_Load(object sender, EventArgs e)
        {
            comboArtist.DataSource = artists;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";
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
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a song title.");
                return;
            }

            if (comboArtist.SelectedItem == null)
            {
                MessageBox.Show("Please select an artist.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

}
