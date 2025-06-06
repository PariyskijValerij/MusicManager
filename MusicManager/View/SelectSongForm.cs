using MusicManager.Models;
using System.Data;

namespace MusicManager
{
    public partial class SelectSongForm : Form
    {
        public int? SelectedSongId { get; private set; }
        private readonly HashSet<int> existingSongIds;
        private AppData appData;
        private int? albumArtistId;

        public SelectSongForm(AppData appData, IEnumerable<int> existingSongIds, int? albumArtistId = null)
        {
            InitializeComponent();
            this.appData = appData;
            this.existingSongIds = new HashSet<int>(existingSongIds);
            this.albumArtistId = albumArtistId;

            var songsToShow = albumArtistId.HasValue
                ? appData.Songs.Where(s => s.ArtistId == albumArtistId.Value)
                : appData.Songs;

            LoadSongs(songsToShow);
        }

        private void LoadSongs(IEnumerable<Song> songs)
        {
            listViewSongs.Clear();
            imageListSongs.Images.Clear();

            foreach (var song in songs)
            {
                var artist = appData.Artists.FirstOrDefault(a => a.Id == song.ArtistId);
                string imageKey = song.Id.ToString();
                string imagePath = File.Exists(song.ImagePath)
       ? song.ImagePath
       : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");

                if (!imageListSongs.Images.ContainsKey(imageKey))
                {
                    try
                    {
                        using (var img = Image.FromFile(imagePath))
                        {
                            imageListSongs.Images.Add(imageKey, new Bitmap(img));
                        }
                    }
                    catch
                    {
                        using (var img = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png")))
                        {
                            imageListSongs.Images.Add(imageKey, new Bitmap(img));
                        }
                    }
                }

                var item = new ListViewItem(song.Title)
                {
                    Tag = song.Id,
                    ImageKey = imageKey
                };

                item.SubItems.Add(artist?.Name ?? "");
                item.SubItems.Add(song.Year.ToString());
                listViewSongs.Items.Add(item);
            }
        }

        private void listViewSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var song = appData.Songs.FirstOrDefault(s => s.Id.ToString() == e.Item.ImageKey);
            var artist = appData.Artists.FirstOrDefault(a => a.Id == song?.ArtistId);

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

        private void btnFilterSongs_Click(object sender, EventArgs e)
        {
            var filterForm = new SongsFilterForm(appData, listViewSongs, imageListSongs);
            filterForm.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listViewSongs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a song.");
                return;
            }
            int selectedSongId = (int)listViewSongs.SelectedItems[0].Tag;
            if (existingSongIds.Contains(selectedSongId))
            {
                MessageBox.Show("This song is already in album.");
                return;
            }

            SelectedSongId = selectedSongId;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
