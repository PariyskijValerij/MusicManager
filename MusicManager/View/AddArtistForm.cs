using MusicManager.Models;
using static System.Windows.Forms.LinkLabel;

namespace MusicManager
{
    public partial class AddArtistForm : Form
    {
        private string selectedImagePath = "";

        private Artist artistToEdit;
        private bool isEditMode;
        private AppData appData;

        public AddArtistForm(AppData appData)
        {
            InitializeComponent();
            this.appData = appData;
            isEditMode = false;

            LoadDefaultImage();
        }

        public AddArtistForm(AppData appData, Artist artistToEdit)
        {
            InitializeComponent();
            this.appData = appData;
            this.artistToEdit = artistToEdit;
            isEditMode = true;

            txtArtistName.Text = artistToEdit.Name;
            txtLink.Text = artistToEdit.ExternalLink ?? "";
            selectedImagePath = artistToEdit.ImagePath;

            if (File.Exists(selectedImagePath))
            {
                using (var img = Image.FromFile(selectedImagePath))
                {
                    pictureBoxArtist.Image = new Bitmap(img);
                }
            }
            else
            {
                LoadDefaultImage();
            }
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
                    pictureBoxArtist.Image = new Bitmap(img);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArtistName.Text))
            {
                MessageBox.Show("Please enter an artist name.");
                return;
            }

            string name = txtArtistName.Text.Trim();
            string artistLink = string.IsNullOrWhiteSpace(txtLink.Text) ? null : txtLink.Text.Trim();
            if (!string.IsNullOrWhiteSpace(artistLink) && !Uri.IsWellFormedUriString(artistLink, UriKind.Absolute))
            {
                MessageBox.Show("Please enter a valid URL.");
                return;
            }

            string imageFileName = Path.Combine("Images", "default_artist.png");
            string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            Directory.CreateDirectory(imagesFolder);

            if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                string newFileName;
                string newPath;

                if (isEditMode)
                {
                    newFileName = $"artist_{artistToEdit.Id}" + Path.GetExtension(selectedImagePath);
                    newPath = Path.Combine(imagesFolder, newFileName);

                    if (!string.Equals(selectedImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(selectedImagePath, newPath, true);
                    }

                    artistToEdit.Name = name;
                    artistToEdit.ExternalLink = artistLink;
                    artistToEdit.ImagePath = newPath;
                }
                else
                {
                    newFileName = $"artist_{appData.ArtistIdCounter}" + Path.GetExtension(selectedImagePath);
                    newPath = Path.Combine(imagesFolder, newFileName);
                    File.Copy(selectedImagePath, newPath, true);

                    var newArtist = new Artist
                    {
                        Id = appData.ArtistIdCounter++,
                        Name = name,
                        ImagePath = newPath,
                        ExternalLink = artistLink
                    };

                    appData.Artists.Add(newArtist);
                    appData.ArtistSongs[newArtist.Id] = new List<string>();
                }
            }
            else if (isEditMode)
            {
                artistToEdit.Name = name;
                artistToEdit.ExternalLink = artistLink;
            }
            else
            {
                var artist = new Artist
                {
                    Id = appData.ArtistIdCounter++,
                    Name = name,
                    ImagePath = imageFileName,
                    ExternalLink = artistLink
                };

                appData.Artists.Add(artist);
                appData.ArtistSongs[artist.Id] = new List<string>();
            }
            appData.Save("data.json");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddArtistForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadDefaultImage()
        {
            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_artist.png");
            if (File.Exists(defaultPath))
            {
                pictureBoxArtist.Image = new Bitmap(defaultPath);
            }
        }
    }
}
