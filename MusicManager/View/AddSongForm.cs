using MusicManager.Models;

namespace MusicManager
{
    public partial class AddSongForm : Form
    {
        private readonly AppData appData;
        private readonly Song? songToEdit;
        private readonly bool isEditMode;
        private string selectedImagePath = "";

        public AddSongForm(AppData appData)
        {
            InitializeComponent();
            this.appData = appData;
            isEditMode = false;

            InitializeForm();
        }

        public AddSongForm(AppData appData, Song songToEdit)
        {
            InitializeComponent();
            this.appData = appData;
            this.songToEdit = songToEdit;
            isEditMode = true;

            InitializeForm(songToEdit);
        }

        private void InitializeForm(Song? song = null)
        {
            comboArtist.DataSource = appData.Artists;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";

            txtTitle.Text = song?.Title ?? "";
            txtLink.Text = song?.ExternalLink ?? "";
            numericYear.Value = song?.Year ?? DateTime.Now.Year;
            comboArtist.SelectedValue = song?.ArtistId ?? Artist.GetArtistById(appData, 1)?.Id ?? 1;
            selectedImagePath = song?.ImagePath ?? "";

            if (File.Exists(selectedImagePath))
                LoadImage(selectedImagePath);
            else
                LoadDefaultImage();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new()
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                LoadImage(selectedImagePath);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string link = string.IsNullOrWhiteSpace(txtLink.Text) ? null : txtLink.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a song title.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(link) && !Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                MessageBox.Show("Please enter a valid URL (e.g., https://example.com).");
                return;
            }

            int artistId = (int)comboArtist.SelectedValue;
            int year = (int)numericYear.Value;
            string imagePath = SaveImage();

            if (isEditMode && songToEdit != null)
            {
                UpdateSong(songToEdit, title, artistId, year, link, imagePath);
            }
            else
            {
                CreateSong(title, artistId, year, link, imagePath);
            }

            appData.Save("data.json");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadDefaultImage()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");
            LoadImage(path);
        }

        private void LoadImage(string path)
        {
            if (File.Exists(path))
            {
                using var img = Image.FromFile(path);
                pictureBoxSong.Image = new Bitmap(img);
            }
        }

        private string SaveImage()
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            Directory.CreateDirectory(folder);

            if (string.IsNullOrWhiteSpace(selectedImagePath) || !File.Exists(selectedImagePath))
                return Path.Combine("Images", "default_song.png");

            string fileName = $"song_{(isEditMode ? songToEdit!.Id : appData.SongIdCounter)}" + Path.GetExtension(selectedImagePath);
            string newPath = Path.Combine(folder, fileName);

            if (!string.Equals(selectedImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                File.Copy(selectedImagePath, newPath, true);

            return newPath;
        }

        private void UpdateSong(Song song, string title, int artistId, int year, string? link, string imagePath)
        {
            song.Title = title;
            song.ArtistId = artistId;
            song.Year = year;
            song.ExternalLink = link;
            song.ImagePath = imagePath;
        }

        private void CreateSong(string title, int artistId, int year, string? link, string imagePath)
        {
            var song = new Song
            {
                Id = appData.SongIdCounter++,
                Title = title,
                ArtistId = artistId,
                Year = year,
                ExternalLink = link,
                ImagePath = imagePath
            };

            appData.Songs.Add(song);
        }
    }
}
