using MusicManager.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;

namespace MusicManager
{
    public partial class MainForm : Form
    {
        private List<Artist> artists = new List<Artist>();
        private Dictionary<int, List<string>> artistSongs = new Dictionary<int, List<string>>();
        private int artistIdCounter = 1;

        private List<Song> songs = new List<Song>();
        private int songIdCounter = 1;

        private string selectedArtistImagePath = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listViewArtists.LargeImageList = imageListArtists;

            LoadData();
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridArtistSongs.DataSource = null;
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            var form = new AddArtistForm();

            if(form.ShowDialog() == DialogResult.OK)
            {
                string name = form.ArtistName;
                string imageFileName = "Images/default_artist.png";

                if(!string.IsNullOrEmpty(form.ImagePath) && (File.Exists(form.ImagePath)))
                {
                    string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    Directory.CreateDirectory(imagesFolder);

                    string newFileName = $"artist_{artistIdCounter}" + Path.GetExtension(form.ImagePath);
                    string newPath = Path.Combine(imagesFolder + newFileName);

                    File.Copy(form.ImagePath, newPath, true);
                    imageFileName = newPath;
                }

                var artist = new Artist
                {
                    Id = artistIdCounter,
                    Name = name,
                    ImagePath = imageFileName
                };

                artists.Add(artist);
                artistSongs[artist.Id] = new List<string>();

                RefreshArtistList();
                SaveData();
            }
        }

        private void btnDeleteArtist_Click(object sender, EventArgs e)
        {
            if (listViewArtists.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = listViewArtists.SelectedItems[0];
            int selectedId = (int)selectedItem.Tag;

            var artistToRemove = artists.FirstOrDefault(a => a.Id == selectedId);

            if (artistToRemove != null)
            {
                artists.Remove(artistToRemove);
                artistSongs.Remove(selectedId);
                RefreshArtistList();
            }

            SaveData();
        }

        private void btnChangeArtistImage_Click(object sender, EventArgs e)
        {
            if(listViewArtists.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = listViewArtists.SelectedItems[0];
            int artistId = (int)selectedItem.Tag;
            var artist = artists.FirstOrDefault(a => a.Id == artistId);
            if(artist == null)
            {
                return;
            }

            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Select New Artist Image";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = ofd.FileName;
                string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");

                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                string newFileName = $"artist_{artist.Id}" + Path.GetExtension(selectedPath);
                string newPath = Path.Combine(imagesFolder, newFileName);

                try
                {
                    File.Copy(selectedPath, newPath, true);
                    artist.ImagePath = newPath;

                    RefreshArtistList();
                    SaveData();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error updating image: " + ex.Message);
                }
            }
        }

        private void listViewArtists_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RefreshArtistList()
        {
            listViewArtists.Items.Clear();
            imageListArtists.Images.Clear();

            foreach (var artist in artists.OrderBy(a => a.Name))
            {
                string path = File.Exists(artist.ImagePath)
                    ? artist.ImagePath
                    : "Images/default_artist.png";

                try
                {
                    using (var temp = Image.FromFile(path))
                    {
                        imageListArtists.Images.Add(artist.Id.ToString(), new Bitmap(temp));
                    }

                }
                catch
                {
                    using (var temp = Image.FromFile("Images/default_artist.png"))
                    {
                        imageListArtists.Images.Add(artist.Id.ToString(), new Bitmap(temp));
                    }
                }

                var item = new ListViewItem
                {
                    Text = "",
                    ImageKey = artist.Id.ToString(),
                    Tag = artist.Id
                };

                listViewArtists.Items.Add(item);
            }
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            var form = new AddSongForm(artists);

            if (form.ShowDialog() == DialogResult.OK)
            {
                string title = form.SongTitle;
                int artistId = form.SelectedArtistId;
                int year = form.ReleaseYear;
                string songImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");

                if (!string.IsNullOrEmpty(form.ImagePath) && File.Exists(form.ImagePath))
                {
                    string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    Directory.CreateDirectory(imagesFolder);

                    string newFileName = $"song_{songIdCounter}" + Path.GetExtension(form.ImagePath);
                    string newPath = Path.Combine(imagesFolder, newFileName);

                    File.Copy(form.ImagePath, newPath, true);
                    songImagePath = newPath;
                }

                var newSong = new Song
                {
                    Id = songIdCounter++,
                    Title = title,
                    ArtistId = artistId,
                    Year = year,
                    ImagePath = songImagePath
                };

                songs.Add(newSong);
                artistSongs[artistId].Add(title);

                RefreshSongList();
                SaveData();
            }
        }

        public void RefreshSongList()
        {
            listViewAllSongs.Items.Clear();
            imageListSongs.Images.Clear();

            foreach (var song in songs.OrderBy(s => s.Title))
            {
                var artist = artists.FirstOrDefault(a => a.Id == song.ArtistId);
                if (artist == null) continue;

                string imageKey = song.Id.ToString();
                string imagePath = File.Exists(song.ImagePath) ? song.ImagePath :
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");

                if (!imageListSongs.Images.ContainsKey(imageKey))
                {
                    try
                    {
                        using(var temp = Image.FromFile(imagePath))
                        {
                            imageListSongs.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        using(var temp = Image.FromFile("Images/default_song.png"))
                        {
                            imageListSongs.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                }

                var item = new ListViewItem
                {
                    Text = "",
                    ImageKey = imageKey,
                    Tag = song.Id
                };

                listViewAllSongs.Items.Add(item);
            }
        }

        private void btnDeleteSong_Click(object sender, EventArgs e)
        {
            if (listViewAllSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a song to delete.");
                return;
            }

            var selectedItem = listViewAllSongs.SelectedItems[0];
            int songId = (int)selectedItem.Tag;

            var songToRemove = songs.FirstOrDefault(s => s.Id == songId);

            if (songToRemove != null)
            {
                songs.Remove(songToRemove);
                if (artistSongs.TryGetValue(songToRemove.ArtistId, out var list))
                {
                    list.Remove(songToRemove.Title);
                }
;
            }

            RefreshSongList();
            SaveData();
        }

        private void listViewAllSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var song = songs.FirstOrDefault(s => s.Id.ToString() == e.Item.ImageKey);
            var artist = artists.FirstOrDefault(a => a.Id == song?.ArtistId);

            if (song == null || artist == null)
            {
                return;
            }

            Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font artistFont = new Font("Segoe UI", 8, FontStyle.Regular);
            Color textColor = Color.White;

            Color backColor = e.Item.Selected ? Color.FromArgb(100, 100, 100) : e.Item.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);

            if (e.Item.Selected)
            {
                Rectangle borderRect = e.Bounds;
                borderRect.Inflate(-1, -1);
                using Pen borderPen = new Pen(Color.White, 2);
                e.Graphics.DrawRectangle(borderPen, borderRect);
            }

            Image img = imageListSongs.Images[e.Item.ImageKey];
            Rectangle imageRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 64, 64);
            e.Graphics.DrawImage(img, imageRect);

            int textX = imageRect.Right + 10;
            int textY = imageRect.Top;

            e.Graphics.DrawString(song.Title, titleFont, new SolidBrush(textColor), new PointF(textX, textY));
            e.Graphics.DrawString(artist.Name, artistFont, new SolidBrush(Color.LightGray), new PointF(textX, textY + 22));
        }

        private void listViewArtists_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var artist = artists.FirstOrDefault(a => a.Id.ToString() == e.Item.ImageKey);
            if (artist == null) return;

            Font nameFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Color textColor = Color.White;

            Color backColor = e.Item.Selected ? Color.FromArgb(100, 100, 100) : e.Item.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);

            if (e.Item.Selected)
            {
                Rectangle borderRect = e.Bounds;
                borderRect.Inflate(-1, -1);
                using Pen borderPen = new Pen(Color.White, 2);
                e.Graphics.DrawRectangle(borderPen, borderRect);
            }

            Image img = imageListArtists.Images[e.Item.ImageKey];
            Rectangle imageRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 64, 64);
            e.Graphics.DrawImage(img, imageRect);

            int textX = imageRect.Right + 10;
            int textY = imageRect.Top + 20;
            e.Graphics.DrawString(artist.Name, nameFont, new SolidBrush(textColor), new PointF(textX, textY));
        }

        private void SaveData()
        {
            var appData = new AppData
            {
                Artists = this.artists,
                ArtistSongs = this.artistSongs,
                Songs = this.songs,
                ArtistIdCounter = this.artistIdCounter,
                SongIdCounter = this.songIdCounter
            };

            string json = JsonConvert.SerializeObject(appData, Formatting.Indented);
            File.WriteAllText("data.json", json);
        }

        private void LoadData()
        {
            if (File.Exists("data.json"))
            {
                string json = File.ReadAllText("data.json");
                var appData = JsonConvert.DeserializeObject<AppData>(json);

                this.artists = appData.Artists ?? new List<Artist>();
                this.artistSongs = appData.ArtistSongs ?? new Dictionary<int, List<string>>();
                this.songs = appData.Songs ?? new List<Song>();
                this.artistIdCounter = appData.ArtistIdCounter;
                this.songIdCounter = appData.SongIdCounter;

                RefreshArtistList();
                RefreshSongList();
            }
        }
    }
}
