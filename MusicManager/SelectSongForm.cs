using MusicManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicManager
{
    public partial class SelectSongForm : Form
    {
        public int? SelectedSongId { get; private set; }
        private readonly HashSet<int> existingSongIds;

        private List<Artist> artists;
        private List<Song> songs;

        public SelectSongForm(List<Song> songs, List<Artist> artists, IEnumerable<int> existingSongIds)
        {
            InitializeComponent();
            this.existingSongIds = new HashSet<int>(existingSongIds);
            this.artists = artists;
            this.songs = songs;

            foreach (var song in songs)
            {
                var artist = artists.FirstOrDefault(a => a.Id == song.ArtistId);
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
                item.Tag = song.Id;
                listViewSongs.Items.Add(item);
            }
        }

        private void listViewSongs_DrawItem(object sender, DrawListViewItemEventArgs e)
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

        private void btnFilterSongs_Click(object sender, EventArgs e)
        {
            var filterForm = new SongsFilterForm(artists);
            while (true)
            {
                if (filterForm.ShowDialog() != DialogResult.OK)
                {
                    break;
                }

                var filteredSongs = songs.AsEnumerable();

                if (!string.IsNullOrEmpty(filterForm.SongTitle))
                {
                    filteredSongs = filteredSongs.Where(s => s.Title.Contains(filterForm.SongTitle, StringComparison.OrdinalIgnoreCase));
                }

                if (filterForm.SelectedArtistId.HasValue)
                {
                    filteredSongs = filteredSongs.Where(s => s.ArtistId == filterForm.SelectedArtistId.Value);
                }

                if (filterForm.YearMin.HasValue)
                {
                    filteredSongs = filteredSongs.Where(s => s.Year >= filterForm.YearMin.Value);
                }

                if (filterForm.YearMax.HasValue)
                {
                    filteredSongs = filteredSongs.Where(s => s.Year <= filterForm.YearMax.Value);
                }

                if (!filteredSongs.Any())
                {
                    filterForm.ShowError("Nothing Found");
                    continue;
                }

                listViewSongs.Items.Clear();

                foreach (var song in filteredSongs.OrderBy(s => s.Title))
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

                    listViewSongs.Items.Add(item);
                }
                break;
            }
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
                MessageBox.Show("This song is already selected.");
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
