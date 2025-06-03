using MusicManager.Models;

namespace MusicManager
{
    public partial class AddAlbumForm : Form
    {
        private readonly AppData appData;
        private readonly Album? albumToEdit;
        private readonly bool isEditMode;
        private string selectedImagePath = "";

        public AddAlbumForm(AppData appData)
        {
            InitializeComponent();
            this.appData = appData;
            isEditMode = false;

            InitializeForm();
        }

        public AddAlbumForm(AppData appData, Album albumToEdit)
        {
            InitializeComponent();
            this.appData = appData;
            this.albumToEdit = albumToEdit;
            isEditMode = true;

            InitializeForm(albumToEdit);
        }

        private void InitializeForm(Album? album = null)
        {
            InitializeArtistsCombo();

            txtTitle.Text = album?.Title ?? "";
            selectedImagePath = album?.ImagePath ?? "";

            if (File.Exists(selectedImagePath))
                LoadImage(selectedImagePath);
            else
                LoadDefaultImage();

            comboArtist.SelectedValue = album?.ArtistId ?? 0;
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
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter an album title.");
                return;
            }

            int selectedArtistId = (int)comboArtist.SelectedValue;
            int? artistId = selectedArtistId == 0 ? null : selectedArtistId;
            string imagePath = SaveImage();

            if (isEditMode && albumToEdit != null)
                UpdateAlbum(albumToEdit, title, artistId, imagePath);
            else
                CreateAlbum(title, artistId, imagePath);

            appData.Save("data.json");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InitializeArtistsCombo()
        {
            var artistsWithNone = new List<Artist>
            {
                new Artist { Id = 0, Name = "Unknown artist" }
            };
            artistsWithNone.AddRange(appData.Artists);

            comboArtist.DataSource = artistsWithNone;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";
        }

        private void LoadDefaultImage()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_album.png");
            LoadImage(path);
        }

        private void LoadImage(string path)
        {
            if (File.Exists(path))
            {
                using var img = Image.FromFile(path);
                pictureBoxImage.Image = new Bitmap(img);
            }
        }

        private string SaveImage()
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            Directory.CreateDirectory(folder);

            if (string.IsNullOrWhiteSpace(selectedImagePath) || !File.Exists(selectedImagePath))
                return Path.Combine("Images", "default_album.png");

            string fileName = $"album_{(isEditMode ? albumToEdit!.Id : appData.AlbumIdCounter)}" + Path.GetExtension(selectedImagePath);
            string newPath = Path.Combine(folder, fileName);

            if (!string.Equals(selectedImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                File.Copy(selectedImagePath, newPath, true);

            return newPath;
        }

        private void UpdateAlbum(Album album, string title, int? artistId, string imagePath)
        {
            album.Title = title;
            album.ArtistId = artistId;
            album.ImagePath = imagePath;
        }

        private void CreateAlbum(string title, int? artistId, string imagePath)
        {
            var album = new Album
            {
                Id = appData.AlbumIdCounter++,
                Title = title,
                ArtistId = artistId,
                ImagePath = imagePath
            };
            appData.Albums.Add(album);
        }
    }
}
