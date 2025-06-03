using MusicManager.Models;
using System.Data;

namespace MusicManager
{
    public partial class SongsFilterForm : Form
    {
        private AppData appData;
        private ListView targetListView;
        private ImageList targetImageList;

        public SongsFilterForm(AppData appData, ListView targetListView, ImageList targetImageList)
        {
            InitializeComponent();
            this.appData = appData;
            this.targetListView = targetListView;
            this.targetImageList = targetImageList;

            comboArtist.DataSource = new List<Artist>(appData.Artists);
            comboArtist.DisplayMember = "Name";
            comboArtist.ValueMember = "Id";
            comboArtist.SelectedIndex = -1;

            var autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(appData.Artists.Select(a => a.Name).ToArray());
            comboArtist.AutoCompleteCustomSource = autoSource;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string titleFilter = textTitle.Text.Trim();
            int? artistIdFilter = comboArtist.SelectedItem is Artist artist ? artist.Id : (int?)null;
            int? yearMin = int.TryParse(txtYearMin.Text, out var y1) ? y1 : null;
            int? yearMax = int.TryParse(txtYearMax.Text, out var y2) ? y2 : null;

            var filteredSongs = appData.Songs.AsEnumerable();

            if (!string.IsNullOrEmpty(titleFilter))
            {
                filteredSongs = filteredSongs.Where(s => s.Title.Contains(titleFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (artistIdFilter.HasValue)
            {
                filteredSongs = filteredSongs.Where(s => s.ArtistId == artistIdFilter.Value);
            }

            if (yearMin.HasValue)
            {
                filteredSongs = filteredSongs.Where(s => s.Year >= yearMin.Value);
            }

            if (yearMax.HasValue)
            {
                filteredSongs = filteredSongs.Where(s => s.Year <= yearMax.Value);
            }

            if (!filteredSongs.Any())
            {
                ShowError("Nothing Found");
                return;
            }

            targetListView.Items.Clear();
            targetImageList.Images.Clear();


            foreach (var song in filteredSongs.OrderBy(s => s.Title))
            {
                artist = appData.Artists.FirstOrDefault(a => a.Id == song.ArtistId);
                if (artist == null) continue;

                string imageKey = song.Id.ToString();
                string imagePath = File.Exists(song.ImagePath) ? song.ImagePath :
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default_song.png");

                if (!targetImageList.Images.ContainsKey(imageKey))
                {
                    try
                    {
                        using (var temp = Image.FromFile(imagePath))
                        {
                            targetImageList.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                    catch
                    {
                        using (var temp = Image.FromFile("Images/default_song.png"))
                        {
                            targetImageList.Images.Add(imageKey, new Bitmap(temp));
                        }
                    }
                }

                var item = new ListViewItem
                {
                    Text = "",
                    ImageKey = imageKey,
                    Tag = song.Id
                };

                targetListView.Items.Add(item);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }
    }
}
