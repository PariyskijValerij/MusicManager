using MusicManager.Models;
using Newtonsoft.Json;

namespace MusicManager
{
    public partial class MainForm : Form
    {
        private List<Artist> artists = new List<Artist>();
        private Dictionary<int, List<string>> artistSongs = new Dictionary<int, List<string>>();
        private int artistIdCounter = 1;
        private string selectedArtistImagePath = "";

        private List<Song> songs = new List<Song>();
        private int songIdCounter = 1;

        private List<Album> albums = new();
        private List<AlbumSongLink> albumSongLinks = new();
        private int albumIdCounter = 1;

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
            listViewArtists.SelectedItems.Clear();
            listViewAllSongs.SelectedItems.Clear();
            listViewArtistSongs.SelectedItems.Clear();
            listViewAlbums.SelectedItems.Clear();
            listViewAlbumSongs.SelectedItems.Clear();
            RefreshSongList();
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            var form = new AddArtistForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                string name = form.ArtistName;
                string imageFileName = "Images/default_artist.png";

                if (!string.IsNullOrEmpty(form.ImagePath) && (File.Exists(form.ImagePath)))
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

        private void btnEditArtist_Click(object sender, EventArgs e)
        {
            if (listViewArtists.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = listViewArtists.SelectedItems[0];
            int artistId = (int)selectedItem.Tag;
            var artist = artists.FirstOrDefault(a => a.Id == artistId);
            if (artist == null)
            {
                return;
            }

            var form = new AddArtistForm(artist);

            if (form.ShowDialog() == DialogResult.OK)
            {
                artist.Name = form.ArtistName;

                if (!string.IsNullOrEmpty(form.ImagePath) && File.Exists(form.ImagePath))
                {
                    string imagesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    Directory.CreateDirectory(imagesFolder);

                    string newFileName = $"artist_{artist.Id}" + Path.GetExtension(form.ImagePath);
                    string newPath = Path.Combine(imagesFolder, newFileName);

                    if (!string.Equals(form.ImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(form.ImagePath, newPath, true);
                    }
                    artist.ImagePath = newPath;
                }

                RefreshArtistList();
                SaveData();
            }
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

        private void listViewArtists_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewArtistSongs.Items.Clear();
            imageListSongs.Images.Clear();

            if (listViewArtists.SelectedItems.Count == 0)
            {
                return;
            }

            int artistId = (int)listViewArtists.SelectedItems[0].Tag;
            var artistSongsList = songs.Where(s => s.ArtistId == artistId).OrderBy(s => s.Title);

            foreach (var song in artistSongsList)
            {
                string imageKey = song.Id.ToString();
                string imagePath = File.Exists(song.ImagePath) ? song.ImagePath :
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");

                if (!imageListSongs.Images.ContainsKey(imageKey))
                {
                    try
                    {
                        using (var temp = Image.FromFile(imagePath))
                        {
                            imageListSongs.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        using (var temp = Image.FromFile("Images/default_song.png"))
                        {
                            imageListSongs.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                }

                var item = new ListViewItem(song.Title)
                {
                    ImageKey = imageKey,
                    Tag = song.Id
                };
                listViewArtistSongs.Items.Add(item);
            }
        }

        private void listViewArtistSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var song = songs.FirstOrDefault(s => s.Id.ToString() == e.Item.ImageKey);
            var artist = artists.FirstOrDefault(a => a.Id == song?.ArtistId);

            Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font artistFont = new Font("Segoe UI", 8, FontStyle.Regular);
            Font yearFont = new Font("Segoe UI", 7, FontStyle.Italic);
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
            e.Graphics.DrawString(song.Year.ToString(), yearFont, new SolidBrush(Color.Silver), new PointF(textX, textY + 40));
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

        private void btnEditSong_Click(object sender, EventArgs e)
        {
            if (listViewAllSongs.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = listViewAllSongs.SelectedItems[0];
            int songId = (int)selectedItem.Tag;

            var song = songs.FirstOrDefault(s => s.Id == songId);
            if (song == null) return;

            var form = new AddSongForm(artists, song);

            if (form.ShowDialog() == DialogResult.OK)
            {
                song.Title = form.SongTitle;
                song.ArtistId = form.SelectedArtistId;
                song.Year = form.ReleaseYear;

                if (!string.IsNullOrEmpty(form.ImagePath) && File.Exists(form.ImagePath))
                {
                    string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    Directory.CreateDirectory(imageFolder);

                    string newFileName = $"song_{song.Id}" + Path.GetExtension(form.ImagePath);
                    string newPath = Path.Combine(imageFolder, newFileName);

                    if (!string.Equals(form.ImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(form.ImagePath, newPath, true);
                    }
                    song.ImagePath = newPath;
                }

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
                        using (var temp = Image.FromFile(imagePath))
                        {
                            imageListSongs.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        using (var temp = Image.FromFile("Images/default_song.png"))
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

        private void listViewAllSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewSongAlbums.Items.Clear();

            if (listViewAllSongs.SelectedItems.Count == 0)
            {
                return;
            }

            int songId = (int)listViewAllSongs.SelectedItems[0].Tag;
            var albumIds = albumSongLinks
                .Where(link => link.SongId == songId)
                .Select(link => link.AlbumId)
                .Distinct()
                .ToList();

            var songAlbums = albums.Where(a => albumIds.Contains(a.Id)).OrderBy(a => a.Title);

            foreach (var album in songAlbums)
            {
                string imageKey = album.Id.ToString();
                string imagePath = File.Exists(album.ImagePath) ? album.ImagePath :
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_album.png");

                if (!imageListAlbums.Images.ContainsKey(imageKey))
                {
                    try
                    {
                        using (var temp = Image.FromFile(imagePath))
                        {
                            imageListAlbums.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        using (var temp = Image.FromFile("Images/default_album.png"))
                        {
                            imageListAlbums.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                }

                var item = new ListViewItem(album.Title)
                {
                    ImageKey = imageKey,
                    Tag = album.Id
                };
                listViewSongAlbums.Items.Add(item);
            }
        }

        private void listViewSongAlbums_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var album = albums.FirstOrDefault(a => a.Id.ToString() == e.Item.ImageKey);
            Artist artist = null;
            string artistName = "Власний альбом";

            if (album != null && album.ArtistId != null)
            {
                artist = artists.FirstOrDefault(a => a.Id == album.ArtistId);
                if (artist != null)
                {
                    artistName = artist.Name;
                }
            }

            if (album == null)
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

            Image img = imageListAlbums.Images[e.Item.ImageKey];
            Rectangle imageRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 64, 64);
            e.Graphics.DrawImage(img, imageRect);

            int textX = imageRect.Right + 10;
            int textY = imageRect.Top;

            e.Graphics.DrawString(album.Title, titleFont, new SolidBrush(textColor), new PointF(textX, textY));
            e.Graphics.DrawString(artistName, artistFont, new SolidBrush(Color.LightGray), new PointF(textX, textY + 22));
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
            Font yearFont = new Font("Segoe UI", 7, FontStyle.Italic);
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
            e.Graphics.DrawString(song.Year.ToString(), yearFont, new SolidBrush(Color.Silver), new PointF(textX, textY + 40));
        }

        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            var form = new AddAlbumForm(artists);

            if (form.ShowDialog() == DialogResult.OK)
            {
                string title = form.AlbumTitle;
                int? artistId = form.SelectedArtistId;
                string albumImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_album.png");

                if (!string.IsNullOrEmpty(form.ImagePath) && File.Exists(form.ImagePath))
                {
                    string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    Directory.CreateDirectory(imageFolder);

                    string newFileName = $"album_{albumIdCounter}" + Path.GetExtension(form.ImagePath);
                    string newPath = Path.Combine(imageFolder, newFileName);

                    File.Copy(form.ImagePath, newPath, true);
                    albumImagePath = newPath;
                }

                var newalbum = new Album
                {
                    Id = albumIdCounter++,
                    Title = title,
                    ArtistId = artistId,
                    ImagePath = albumImagePath
                };

                albums.Add(newalbum);

                RefreshAlbumList();
                SaveData();
            }
        }

        private void btnDeleteAlbum_Click(object sender, EventArgs e)
        {
            if (listViewAlbums.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a album to delete.");
                return;
            }

            var selectedItem = listViewAlbums.SelectedItems[0];
            int albumId = (int)selectedItem.Tag;

            var albumToRemove = albums.FirstOrDefault(s => s.Id == albumId);

            if (albumToRemove != null)
            {
                albums.Remove(albumToRemove);
            }

            RefreshAlbumList();
            SaveData();
        }

        private void btnEditAlbum_Click(object sender, EventArgs e)
        {
            if (listViewAlbums.SelectedItems.Count == 0)
            {
                return;
            }

            var selectedItem = listViewAlbums.SelectedItems[0];
            int albumId = (int)selectedItem.Tag;

            var album = albums.FirstOrDefault(a => a.Id == albumId);
            if (album == null) return;

            var form = new AddAlbumForm(artists, album);

            if (form.ShowDialog() == DialogResult.OK)
            {
                album.Title = form.AlbumTitle;
                album.ArtistId = form.SelectedArtistId;

                if (!string.IsNullOrEmpty(form.ImagePath) && File.Exists(form.ImagePath))
                {
                    string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    Directory.CreateDirectory(imageFolder);

                    string newFileName = $"album_{album.Id}" + Path.GetExtension(form.ImagePath);
                    string newPath = Path.Combine(imageFolder, newFileName);

                    if (!string.Equals(form.ImagePath, newPath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(form.ImagePath, newPath, true);
                    }
                    album.ImagePath = newPath;
                }

                RefreshAlbumList();
                SaveData();
            }
        }

        private void btnAddSongToAlbum_Click(object sender, EventArgs e)
        {
            if (listViewAlbums.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an album to add songs to.");
                return;
            }

            int albumId = (int)listViewAlbums.SelectedItems[0].Tag;
            var album = albums.First(a => a.Id == albumId);
            List<Song> availableSongs;

            if (album.ArtistId == null)
            {
                availableSongs = songs;
            }
            else
            {
                availableSongs = songs.Where(s => s.ArtistId == album.ArtistId).ToList();
            }

            var existingSongIds = albumSongLinks.Where(link => link.AlbumId == albumId).Select(link => link.SongId).ToList();
            var selectSongForm = new SelectSongForm(availableSongs, artists, existingSongIds);

            if (selectSongForm.ShowDialog() == DialogResult.OK && selectSongForm.SelectedSongId.HasValue)
            {
                int selectedSongId = selectSongForm.SelectedSongId.Value;
                albumSongLinks.Add(new AlbumSongLink { AlbumId = albumId, SongId = selectedSongId });
                SaveData();
            }
            ShowSongsForAlbum(albumId);
        }

        private void listViewAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAlbums.SelectedItems.Count == 0)
            {
                listViewAlbumSongs.Items.Clear();
                imageListAlbumSongs.Images.Clear();
                return;
            }

            int albumId = (int)listViewAlbums.SelectedItems[0].Tag;
            ShowSongsForAlbum(albumId);
        }

        private void ShowSongsForAlbum(int albumId)
        {
            listViewAlbumSongs.Items.Clear();
            imageListAlbumSongs.Images.Clear();

            var songIds = albumSongLinks.Where(link => link.AlbumId == albumId).Select(link => link.SongId).ToList();

            var albumsSongs = songs.Where(song => songIds.Contains(song.Id)).ToList();

            foreach (var song in albumsSongs.OrderBy(s => s.Title))
            {
                var artist = artists.FirstOrDefault(a => a.Id == song.ArtistId);
                string imageKey = song.Id.ToString();
                string imagePath = File.Exists(song.ImagePath) ? song.ImagePath :
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");

                if (!imageListAlbumSongs.Images.ContainsKey(imageKey))
                {
                    try
                    {
                        using (var temp = Image.FromFile(imagePath))
                        {
                            imageListAlbumSongs.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        using (var img = Image.FromFile("Images/default_song.png"))
                        {
                            imageListAlbumSongs.Images.Add(imageKey, new Bitmap(img));
                        }
                    }
                }

                var item = new ListViewItem
                {
                    Text = song.Title,
                    ImageKey = imageKey,
                    Tag = song.Id
                };
                listViewAlbumSongs.Items.Add(item);
            }

        }

        private void listViewAlbumSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var song = songs.FirstOrDefault(s => s.Id.ToString() == e.Item.ImageKey);
            var artist = artists.FirstOrDefault(a => a.Id == song?.ArtistId);

            if (song == null || artist == null)
            {
                return;
            }

            Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font artistFont = new Font("Segoe UI", 8, FontStyle.Regular);
            Font yearFont = new Font("Segoe UI", 7, FontStyle.Italic);
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
            e.Graphics.DrawString(song.Year.ToString(), yearFont, new SolidBrush(Color.Silver), new PointF(textX, textY + 40));
        }

        private void btnRemoveSongFromAlbum_Click(object sender, EventArgs e)
        {
            if (listViewAlbums.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an album first.");
                return;
            }
            if (listViewAlbumSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a song to remove from the album.");
                return;
            }

            int albumId = (int)listViewAlbums.SelectedItems[0].Tag;
            int songId = (int)listViewAlbumSongs.SelectedItems[0].Tag;

            var link = albumSongLinks.FirstOrDefault(l => l.AlbumId == albumId && l.SongId == songId);
            if (link != null)
            {
                albumSongLinks.Remove(link);
                ShowSongsForAlbum(albumId);
                SaveData();
            }
        }

        private void RefreshAlbumList()
        {
            listViewAlbums.Items.Clear();
            imageListAlbums.Images.Clear();

            foreach (var album in albums.OrderBy(a => a.Title))
            {
                var artist = artists.FirstOrDefault(a => a.Id == album.ArtistId);

                string imageKey = album.Id.ToString();
                string imagePath = File.Exists(album.ImagePath) ? album.ImagePath :
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");

                if (!imageListAlbums.Images.ContainsKey(imageKey))
                {
                    try
                    {
                        using (var temp = Image.FromFile(imagePath))
                        {
                            imageListAlbums.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        using (var img = Image.FromFile("Images/default_album.png"))
                        {
                            imageListAlbums.Images.Add(imageKey, new Bitmap(img));
                        }
                    }
                }


                var item = new ListViewItem
                {
                    Text = album.Title,
                    ImageKey = imageKey,
                    Tag = album.Id
                };

                listViewAlbums.Items.Add(item);

            }
        }

        private void listViewAlbums_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var album = albums.FirstOrDefault(a => a.Id.ToString() == e.Item.ImageKey);
            Artist artist = null;
            string artistName = "Власний альбом";

            if (album != null && album.ArtistId != null)
            {
                artist = artists.FirstOrDefault(a => a.Id == album.ArtistId);
                if (artist != null)
                {
                    artistName = artist.Name;
                }
            }

            if (album == null)
            {
                return;
            }

            Font titleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font artistFont = new Font("Segoe UI", 8, FontStyle.Regular);
            //Font yearFont = new Font("Segoe UI", 7, FontStyle.Italic);
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

            Image img = imageListAlbums.Images[e.Item.ImageKey];
            Rectangle imageRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 64, 64);
            e.Graphics.DrawImage(img, imageRect);

            int textX = imageRect.Right + 10;
            int textY = imageRect.Top;

            e.Graphics.DrawString(album.Title, titleFont, new SolidBrush(textColor), new PointF(textX, textY));
            e.Graphics.DrawString(artistName, artistFont, new SolidBrush(Color.LightGray), new PointF(textX, textY + 22));
            //e.Graphics.DrawString(album.Year.ToString(), yearFont, new SolidBrush(Color.Silver), new PointF(textX, textY + 40));
        }

        private void SaveData()
        {
            var appData = new AppData
            {
                Artists = this.artists,
                ArtistSongs = this.artistSongs,
                Songs = this.songs,
                ArtistIdCounter = this.artistIdCounter,
                SongIdCounter = this.songIdCounter,
                Albums = this.albums,
                AlbumSongLinks = this.albumSongLinks,
                AlbumIdCounter = this.albumIdCounter
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
                this.albums = appData.Albums ?? new List<Album>();
                this.albumSongLinks = appData.AlbumSongLinks ?? new List<AlbumSongLink>();
                this.albumIdCounter = appData.AlbumIdCounter;

                foreach (var album in this.albums)
                {
                    if (album.ArtistId == 0)
                    {
                        album.ArtistId = null;
                    }
                }

                RefreshArtistList();
                RefreshSongList();
                RefreshAlbumList();
            }
        }
    }
}
