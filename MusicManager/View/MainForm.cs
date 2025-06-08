using MusicManager.Models;

namespace MusicManager
{
    public partial class MainForm : Form
    {
        private AppData appData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listViewArtists.LargeImageList = imageListArtists;
            LoadData();
        }


        /////////////
        ///Artists///
        /////////////
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
            listViewArtists.SelectedItems.Clear();
            var form = new AddArtistForm(appData);

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshArtistList();
                RefreshSongList();
            }
        }

        private void btnDeleteArtist_Click(object sender, EventArgs e)
        {
            if (listViewArtists.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an artist to delete.");
                return;
            }

            var selectedItem = listViewArtists.SelectedItems[0];
            int selectedId = (int)selectedItem.Tag;

            var artistToRemove = Artist.GetArtistById(appData, selectedId);


            if (artistToRemove != null)
            {
                var confirm = MessageBox.Show(
                    $"Do you really want to remove the artist \"{artistToRemove.Name}\"?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                confirm = MessageBox.Show(
    $"All his songs will also be deleted \"{artistToRemove.Name}\"?",
    "Confirm",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                var removedSongIds = appData.Songs.Where(s => s.ArtistId == selectedId).Select(s => s.Id).ToList();
                appData.Songs.RemoveAll(s => s.ArtistId == selectedId);
                appData.AlbumSongLinks.RemoveAll(link => removedSongIds.Contains(link.SongId));

                appData.Artists.Remove(artistToRemove);
                appData.ArtistSongs.Remove(selectedId);
            }

            txtArtistDescription.Text = "";
            listViewArtistSongs.Items.Clear();
            imageListArtists.Images.Clear();
            RefreshArtistList();
            RefreshSongList();
            SaveData();
        }

        private void btnEditArtist_Click(object sender, EventArgs e)
        {
            if (listViewArtists.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an artist to edit.");
                return;
            }

            var selectedItem = listViewArtists.SelectedItems[0];
            int artistId = (int)selectedItem.Tag;
            var artist = Artist.GetArtistById(appData, artistId);
            if (artist == null)
            {
                return;
            }

            var form = new AddArtistForm(appData, artist);

            if (form.ShowDialog() == DialogResult.OK)
            {
                txtArtistDescription.Text = "";
                RefreshArtistList();
            }
        }

        private void btnFilterArtists_Click(object sender, EventArgs e)
        {
            string filter = txtArtistFilter.Text.Trim();
            listViewArtists.Items.Clear();
            imageListArtists.Images.Clear();

            var filteredArtists = string.IsNullOrEmpty(filter) ?
                appData.Artists : appData.Artists.Where(a => a.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var artist in filteredArtists)
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

        private void btnClearArtistsFilters_Click(object sender, EventArgs e)
        {
            txtArtistFilter.Text = "";
            RefreshArtistList();
        }

        private void listViewArtists_DoubleClick(object sender, EventArgs e)
        {
            if (listViewArtists.SelectedItems.Count == 0)
            {
                return;
            }

            int artistId = (int)listViewArtists.SelectedItems[0].Tag;
            var artist = Artist.GetArtistById(appData, artistId);

            if (artist == null)
            {
                MessageBox.Show("Artist not found.");
                return;
            }

            if (string.IsNullOrWhiteSpace(artist.ExternalLink))
            {
                MessageBox.Show("This song is not linked to any external source.");
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = artist.ExternalLink,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
        }

        private void listViewArtists_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var artist = Artist.GetByImageKey(appData, e.Item.ImageKey);
            if (artist == null) return;

            string linkStatus = string.IsNullOrWhiteSpace(artist.ExternalLink) ? "[Unlinked]" : "[Linked]";
            string displayTitle = $"{artist.Name} {linkStatus}";

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
            e.Graphics.DrawString(displayTitle, nameFont, new SolidBrush(textColor), new PointF(textX, textY));
        }

        private void listViewArtists_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewArtistSongs.Items.Clear();
            imageListSongs.Images.Clear();

            if (listViewArtists.SelectedItems.Count == 0)
            {
                txtArtistDescription.Text = "";
                return;
            }

            int artistId = (int)listViewArtists.SelectedItems[0].Tag;
            var artist = Artist.GetArtistById(appData, artistId);
            var artistSongsList = appData.Songs.Where(s => s.ArtistId == artistId).OrderBy(s => s.Title);

            if (artist != null)
            {
                txtArtistDescription.Text = artist.Description ?? "";
            }
            else
            {
                txtArtistDescription.Text = "";
            }

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

        private void listViewArtistSongs_DoubleClick(object sender, EventArgs e)
        {
            if (listViewArtistSongs.SelectedItems.Count == 0)
            {
                return;
            }

            var item = listViewArtistSongs.SelectedItems[0];
            int songId = (int)item.Tag;
            var song = Song.GetSongById(appData, songId);

            if (song == null)
            {
                MessageBox.Show("Song not found.");
                return;
            }

            if (string.IsNullOrWhiteSpace(song.ExternalLink))
            {
                MessageBox.Show("This song is not linked to any external source.");
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = song.ExternalLink,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
        }

        private void listViewArtistSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var song = Song.GetByImageKey(appData, e.Item.ImageKey);
            var artist = Artist.GetBySongId(appData, song?.ArtistId);

            string linkStatus = string.IsNullOrWhiteSpace(song.ExternalLink) ? "[Unlinked]" : "[Linked]";
            string displayTitle = $"{song.Title} {linkStatus}";

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

            e.Graphics.DrawString(displayTitle, titleFont, new SolidBrush(textColor), new PointF(textX, textY));
            e.Graphics.DrawString(artist.Name, artistFont, new SolidBrush(Color.LightGray), new PointF(textX, textY + 22));
            e.Graphics.DrawString(song.Year.ToString(), yearFont, new SolidBrush(Color.Silver), new PointF(textX, textY + 40));
        }

        private void RefreshArtistList()
        {
            listViewArtists.Items.Clear();
            imageListArtists.Images.Clear();

            foreach (var artist in appData.Artists.OrderBy(a => a.Name))
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


        /////////////
        ////Songs////
        /////////////
        private void btnAddSong_Click(object sender, EventArgs e)
        {
            var form = new AddSongForm(appData);

            if (form.ShowDialog() == DialogResult.OK)
            {
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

            var songToRemove = Song.GetSongById(appData, songId);

            if (songToRemove != null)
            {
                var confirm = MessageBox.Show(
                    $"You really want to delete a song \"{songToRemove.Title}\"?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                appData.Songs.Remove(songToRemove);
                if (appData.ArtistSongs.TryGetValue(songToRemove.ArtistId, out var list))
                {
                    list.Remove(songToRemove.Title);
                }
            }

            listViewSongAlbums.Items.Clear();
            imageListSongs.Images.Clear();
            RefreshSongList();
            SaveData();
        }

        private void btnEditSong_Click(object sender, EventArgs e)
        {
            if (listViewAllSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a song to edit.");
                return;
            }

            var selectedItem = listViewAllSongs.SelectedItems[0];
            int songId = (int)selectedItem.Tag;

            var song = Song.GetSongById(appData, songId);
            if (song == null) return;

            var form = new AddSongForm(appData, song);

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshSongList();
            }
        }
        private void btnFilterSongs_Click(object sender, EventArgs e)
        {
            var filterForm = new SongsFilterForm(appData, listViewAllSongs, imageListSongs);
            filterForm.ShowDialog();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            RefreshSongList();
        }

        public void RefreshSongList()
        {
            listViewAllSongs.Items.Clear();
            imageListSongs.Images.Clear();

            foreach (var song in appData.Songs.OrderBy(s => s.Title))
            {
                var artist = Artist.GetBySongId(appData, song.ArtistId);
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
            var albumIds = appData.AlbumSongLinks
                .Where(link => link.SongId == songId)
                .Select(link => link.AlbumId)
                .Distinct()
                .ToList();

            var songAlbums = appData.Albums.Where(a => albumIds.Contains(a.Id)).OrderBy(a => a.Title);

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

        private void listViewAllSongs_DoubleClick(object sender, EventArgs e)
        {
            if (listViewAllSongs.SelectedItems.Count == 0)
            {
                return;
            }

            var item = listViewAllSongs.SelectedItems[0];
            int songId = (int)item.Tag;
            var song = Song.GetSongById(appData, songId);

            if (song == null)
            {
                MessageBox.Show("Song not found.");
                return;
            }

            if (string.IsNullOrWhiteSpace(song.ExternalLink))
            {
                MessageBox.Show("This song is not linked to any external source.");
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = song.ExternalLink,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
        }

        private void listViewAllSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var song = Song.GetByImageKey(appData, e.Item.ImageKey);
            var artist = Artist.GetBySongId(appData, song?.ArtistId);

            string linkStatus = string.IsNullOrWhiteSpace(song.ExternalLink) ? "[Unlinked]" : "[Linked]";
            string displayTitle = $"{song.Title} {linkStatus}";

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

            e.Graphics.DrawString(displayTitle, titleFont, new SolidBrush(textColor), new PointF(textX, textY));
            e.Graphics.DrawString(artist.Name, artistFont, new SolidBrush(Color.LightGray), new PointF(textX, textY + 22));
            e.Graphics.DrawString(song.Year.ToString(), yearFont, new SolidBrush(Color.Silver), new PointF(textX, textY + 40));
        }

        private void listViewSongAlbums_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var album = Album.GetByImageKey(appData, e.Item.ImageKey);
            Artist artist = null;
            string artistName = "Власний альбом";

            if (album != null && album.ArtistId != null)
            {
                artist = Artist.GetArtistById(appData, album.ArtistId.Value);
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


        //////////////
        ////Albums////
        //////////////
        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            var form = new AddAlbumForm(appData);

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshAlbumList();
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

            var albumToRemove = Album.GetAlbumById(appData, albumId);

            if (albumToRemove != null)
            {
                var confirm = MessageBox.Show(
    $"You really want to delete an album \"{albumToRemove.Title}\"?",
    "Confirm",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                appData.AlbumSongLinks.RemoveAll(link => link.AlbumId == albumId);
                appData.Albums.Remove(albumToRemove);
            }

            listViewAlbumSongs.Items.Clear();
            imageListAlbums.Images.Clear();
            RefreshAlbumList();
            SaveData();
        }

        private void btnEditAlbum_Click(object sender, EventArgs e)
        {
            if (listViewAlbums.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a album to edit.");
                return;
            }

            var selectedItem = listViewAlbums.SelectedItems[0];
            int albumId = (int)selectedItem.Tag;

            var album = Album.GetAlbumById(appData, albumId);
            if (album == null) return;

            var form = new AddAlbumForm(appData, album);

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshAlbumList();
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
            var album = appData.Albums.First(a => a.Id == albumId);

            var existingSongIds = appData.AlbumSongLinks.Where(link => link.AlbumId == albumId).Select(link => link.SongId).ToList();
            var selectSongForm = new SelectSongForm(appData, existingSongIds, album.ArtistId);

            if (selectSongForm.ShowDialog() == DialogResult.OK && selectSongForm.SelectedSongId.HasValue)
            {
                int selectedSongId = selectSongForm.SelectedSongId.Value;
                appData.AlbumSongLinks.Add(new AlbumSongLink { AlbumId = albumId, SongId = selectedSongId });
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

            var songIds = appData.AlbumSongLinks.Where(link => link.AlbumId == albumId).Select(link => link.SongId).ToList();

            var albumsSongs = appData.Songs.Where(song => songIds.Contains(song.Id)).ToList();

            foreach (var song in albumsSongs.OrderBy(s => s.Title))
            {
                var artist = Artist.GetBySongId(appData, song.ArtistId);
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

        private void listViewAlbumSongs_DoubleClick(object sender, EventArgs e)
        {
            if (listViewAlbumSongs.SelectedItems.Count == 0)
            {
                return;
            }

            var item = listViewAlbumSongs.SelectedItems[0];
            int songId = (int)item.Tag;
            var song = Song.GetSongById(appData, songId);

            if (song == null)
            {
                MessageBox.Show("Song not found.");
                return;
            }

            if (string.IsNullOrWhiteSpace(song.ExternalLink))
            {
                MessageBox.Show("This song is not linked to any external source.");
                return;
            }

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = song.ExternalLink,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
        }

        private void listViewAlbumSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var song = Song.GetByImageKey(appData, e.Item.ImageKey);
            var artist = Artist.GetBySongId(appData, song?.ArtistId);

            string linkStatus = string.IsNullOrWhiteSpace(song.ExternalLink) ? "[Unlinked]" : "[Linked]";
            string displayTitle = $"{song.Title} {linkStatus}";

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

            e.Graphics.DrawString(displayTitle, titleFont, new SolidBrush(textColor), new PointF(textX, textY));
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

            var link = AlbumSongLink.GetByAlbumAndSong(appData, albumId, songId);
            if (link != null)
            {
                var song = Song.GetSongById(appData, songId);
                var confirm = MessageBox.Show(
                    $"Do you really want to delete a song \"{song?.Title}\" from album?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                imageListAlbumSongs.Images.Clear();
                appData.AlbumSongLinks.Remove(link);
                ShowSongsForAlbum(albumId);
                SaveData();
            }
        }

        private void btnFilterAlbums_Click(object sender, EventArgs e)
        {
            string filter = txtAlbumFilter.Text.Trim();
            listViewAlbums.Items.Clear();
            imageListAlbums.Images.Clear();

            var filteredAlbums = string.IsNullOrEmpty(filter) ?
                appData.Albums : appData.Albums.Where(a => a.Title.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var album in filteredAlbums)
            {
                string path = File.Exists(album.ImagePath)
                    ? album.ImagePath
                    : "Images/default_album.png";

                try
                {
                    using (var temp = Image.FromFile(path))
                    {
                        imageListAlbums.Images.Add(album.Id.ToString(), new Bitmap(temp));
                    }
                }
                catch
                {
                    using (var temp = Image.FromFile("Images/default_artist.png"))
                    {
                        imageListAlbums.Images.Add(album.Id.ToString(), new Bitmap(temp));
                    }
                }

                var item = new ListViewItem
                {
                    Text = "",
                    ImageKey = album.Id.ToString(),
                    Tag = album.Id
                };

                listViewAlbums.Items.Add(item);
            }
        }

        private void btnClearAlbumsFilter_Click(object sender, EventArgs e)
        {
            txtAlbumFilter.Text = "";
            RefreshAlbumList();
            listViewAlbumSongs.Clear();
        }

        private void RefreshAlbumList()
        {
            listViewAlbums.Items.Clear();
            imageListAlbums.Images.Clear();

            foreach (var album in appData.Albums.OrderBy(a => a.Title))
            {
                var artist = Artist.GetArtistById(appData, album.ArtistId ?? 0);

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
            var album = Album.GetByImageKey(appData, e.Item.ImageKey);
            Artist artist = null;
            string artistName = "My album";

            if (album != null && album.ArtistId != null)
            {
                artist = Artist.GetArtistById(appData, album.ArtistId.Value);
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



        ///////////////////////////
        ////Load and Save Data/////
        ///////////////////////////
        private void SaveData()
        {
            appData.Save("data.json");
        }

        private void LoadData()
        {
            appData = AppData.Load("data.json");
            RefreshArtistList();
            RefreshSongList();
            RefreshAlbumList();
        }
    }
}
