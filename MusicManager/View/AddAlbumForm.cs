using MusicManager.Models;

namespace MusicManager
{
    public partial class AddAlbumForm : Form
    {
        private AppData appData;
        private Album albumToEdit;
        private bool isEditMode;
        private string selectedImagePath = "";

        public AddAlbumForm(AppData appData)
        {
            InitializeComponent();
            this.appData = appData;
            isEditMode = false;

            InitArtistsCombo();
            LoadDefaultImage();
        }

        public AddAlbumForm(AppData appData, Album albumToEdit)
        {
            InitializeComponent();
            this.appData = appData;
            this.albumToEdit = albumToEdit;
            isEditMode = true;

            InitArtistsCombo();

            txtTitle.Text = albumToEdit.Title;
            selectedImagePath = albumToEdit.ImagePath;

            if (File.Exists(selectedImagePath))
            {
                using (var img = Image.FromFile(selectedImagePath))
                {
                    pictureBoxImage.Image = new Bitmap(img);
                }
            }
            else
            {
                LoadDefaultImage();
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
                using (var img = Image.FromFile(selectedImagePath))
                {
                    pictureBoxImage.Image = new Bitmap(img);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Please enter an album title.");
                return;
            }

            string title = txtTitle.Text.Trim();
            int selectedArtistId = (int)comboArtist.SelectedValue;
            int? artistId = selectedArtistId == 0 ? null : selectedArtistId;
            string imageFileName = Path.Combine("Images", "default_album.png");
            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            Directory.CreateDirectory(imageFolder);

            if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                string newFileName = $"album_{(isEditMode ? albumToEdit.Id : appData.AlbumIdCounter)}{Path.GetExtension(selectedImagePath)}";
                string newPath = Path.Combine(imageFolder, newFileName);

                if (!string.Equals(selectedImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                {
                    File.Copy(selectedImagePath, newPath, true);
                }
                imageFileName = newPath;
            }

            if (isEditMode)
            {
                albumToEdit.Title = title;
                albumToEdit.ArtistId = artistId;
                albumToEdit.ImagePath = imageFileName;
            }
            else
            {
                var album = new Album
                {
                    Id = appData.AlbumIdCounter++,
                    Title = title,
                    ArtistId = artistId,
                    ImagePath = imageFileName
                };
                appData.Albums.Add(album);
            }

            appData.Save("data.json");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitArtistsCombo()
        {
            var artistsWithNone = new List<Artist>
            {
                new Artist { Id = 0, Name = "Без виконавця" }
            };
            artistsWithNone.AddRange(appData.Artists);

            comboArtist.DataSource = artistsWithNone;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";
        }

        private void LoadDefaultImage()
        {
            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_album.png");
            if (File.Exists(defaultPath))
                pictureBoxImage.Image = new Bitmap(defaultPath);
        }
    }
}
