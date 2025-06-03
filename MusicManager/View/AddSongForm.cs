using MusicManager.Models;
using static System.Windows.Forms.LinkLabel;

namespace MusicManager
{
    public partial class AddSongForm : Form
    {
        private string selectedImagePath = "";

        private AppData appData;
        private Song songToEdit;
        private bool isEditMode;

        public AddSongForm(AppData appData)
        {
            InitializeComponent();
            this.appData = appData;
            isEditMode = false;

            comboArtist.DataSource = appData.Artists;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";

            numericYear.Value = DateTime.Now.Year;
            LoadDefaultImage();
        }

        public AddSongForm(AppData appData, Song songToEdit)
        {
            InitializeComponent();
            this.appData = appData;
            this.songToEdit = songToEdit;
            isEditMode = true;

            comboArtist.DataSource = appData.Artists;
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";

            txtTitle.Text = songToEdit.Title;
            txtLink.Text = songToEdit.ExternalLink ?? "";
            numericYear.Value = songToEdit.Year;
            comboArtist.SelectedValue = songToEdit.ArtistId;
            selectedImagePath = songToEdit.ImagePath;

            if (File.Exists(selectedImagePath))
            {
                using (var img = Image.FromFile(selectedImagePath))
                {
                    pictureBoxSong.Image = new Bitmap(img);
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
                    pictureBoxSong.Image = new Bitmap(img);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a song title.");
                return;
            }

            string title = txtTitle.Text.Trim();
            string songLink = string.IsNullOrWhiteSpace(txtLink.Text) ? null : txtLink.Text.Trim();

            if (!string.IsNullOrWhiteSpace(songLink) && !Uri.IsWellFormedUriString(songLink, UriKind.Absolute))
            {
                MessageBox.Show("Please enter a valid URL (e.g., https://example.com).");
                return;
            }

            int artistId = (int)comboArtist.SelectedValue;
            int year = (int)numericYear.Value;
            string imageFileName = Path.Combine("Images", "default_song.png");
            string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            Directory.CreateDirectory(imagesFolder);

            if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {

                string newFileName;
                string newPath;

                if (isEditMode)
                {
                    newFileName = $"song_{songToEdit.Id}" + Path.GetExtension(selectedImagePath);
                    newPath = Path.Combine(imagesFolder, newFileName);

                    if (!string.Equals(selectedImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(selectedImagePath, newPath, true);
                    }

                    songToEdit.Title = title;
                    songToEdit.ArtistId = artistId;
                    songToEdit.Year = year;
                    songToEdit.ImagePath = newPath;
                    songToEdit.ExternalLink = songLink;
                }
                else
                {
                    newFileName = $"song_{appData.SongIdCounter}" + Path.GetExtension(selectedImagePath);
                    newPath = Path.Combine(imagesFolder, newFileName);
                    if (!string.Equals(selectedImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(selectedImagePath, newPath, true);
                    }
                    imageFileName = newPath;


                    var song = new Song
                    {
                        Id = appData.SongIdCounter++,
                        Title = title,
                        ArtistId = artistId,
                        Year = year,
                        ImagePath = imageFileName,
                        ExternalLink = songLink
                    };

                    appData.Songs.Add(song);
                }
            }
            else if (isEditMode)
            {
                songToEdit.Title = title;
                songToEdit.ArtistId = artistId;
                songToEdit.Year = year;
                songToEdit.ExternalLink = songLink;
            }
            else
            {
                var newSong = new Song
                {
                    Id = appData.SongIdCounter++,
                    Title = title,
                    ArtistId = artistId,
                    Year = year,
                    ImagePath = imageFileName,
                    ExternalLink = songLink
                };

                appData.Songs.Add(newSong);
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

        private void LoadDefaultImage()
        {
            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");
            if (File.Exists(defaultPath))
            {
                using (var img = Image.FromFile(defaultPath))
                {
                    pictureBoxSong.Image = new Bitmap(img);
                }
            }
        }
    }
}
