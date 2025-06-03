using MusicManager.Models;

namespace MusicManager
{
    public partial class AddArtistForm : Form
    {
        private readonly AppData appData;
        private readonly Artist artistToEdit;
        private readonly bool isEditMode;
        private string selectedImagePath = "";

        public AddArtistForm(AppData appData)
        {
            InitializeComponent();
            this.appData = appData;
            isEditMode = false;

            InitializeForm(null);
        }

        public AddArtistForm(AppData appData, Artist artistToEdit)
        {
            InitializeComponent();
            this.appData = appData;
            this.artistToEdit = artistToEdit;
            isEditMode = true;

            InitializeForm(artistToEdit);
        }

        private void InitializeForm(Artist artist)
        {
            txtArtistName.Text = artist?.Name ?? "";
            txtDescription.Text = artist?.Description ?? "";
            txtLink.Text = artist?.ExternalLink ?? "";
            selectedImagePath = artist?.ImagePath ?? "";

            if (!string.IsNullOrWhiteSpace(selectedImagePath) && File.Exists(selectedImagePath))
            {
                LoadImage(selectedImagePath);
            }
            else
            {
                LoadDefaultImage();
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
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
            string name = txtArtistName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string link = string.IsNullOrWhiteSpace(txtLink.Text) ? null : txtLink.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter an artist name.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(link) && !Uri.IsWellFormedUriString(link, UriKind.Absolute))
            {
                MessageBox.Show("Please enter a valid URL.");
                return;
            }

            string imagePath = SaveImage();

            if (isEditMode)
            {
                UpdateArtist(name, description, link, imagePath);
            }
            else
            {
                CreateArtist(name, description, link, imagePath);
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
            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_artist.png");
            if (File.Exists(defaultPath))
            {
                using( var img = Image.FromFile(defaultPath))
                {
                    pictureBoxArtist.Image = new Bitmap(img);
                }
            }
        }

        private void LoadImage(string path)
        {
            if (File.Exists(path))
            {
                using(var img = Image.FromFile(path))
                {
                    pictureBoxArtist.Image = new Bitmap(img);
                }
            }
        }

        private string SaveImage()
        {
            string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            Directory.CreateDirectory(imagesFolder);

            if (string.IsNullOrWhiteSpace(selectedImagePath) || !File.Exists(selectedImagePath))
                return Path.Combine("Images", "default_artist.png");

            string fileName = $"artist_{(isEditMode ? artistToEdit.Id : appData.ArtistIdCounter)}" + Path.GetExtension(selectedImagePath);
            string newPath = Path.Combine(imagesFolder, fileName);

            if (!string.Equals(selectedImagePath, newPath, StringComparison.OrdinalIgnoreCase))
            {
                File.Copy(selectedImagePath, newPath, true);
            }

            return newPath;
        }

        private void UpdateArtist(string name, string desc, string link, string imagePath)
        {
            artistToEdit.Name = name;
            artistToEdit.Description = desc;
            artistToEdit.ExternalLink = link;
            artistToEdit.ImagePath = imagePath;
        }

        private void CreateArtist(string name, string desc, string link, string imagePath)
        {
            var newArtist = new Artist
            {
                Id = appData.ArtistIdCounter++,
                Name = name,
                Description = desc,
                ExternalLink = link,
                ImagePath = imagePath
            };

            appData.Artists.Add(newArtist);
            appData.ArtistSongs[newArtist.Id] = new List<string>();
        }
    }
}
