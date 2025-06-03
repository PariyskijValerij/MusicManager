using Newtonsoft.Json;

namespace MusicManager.Models
{
    public class AppData
    {
        public List<Artist> Artists { get; set; }
        public Dictionary<int, List<string>> ArtistSongs { get; set; }
        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }
        public List<AlbumSongLink> AlbumSongLinks { get; set; }
        public int ArtistIdCounter { get; set; }
        public int SongIdCounter { get; set; }
        public int AlbumIdCounter { get; set; }

        public static AppData Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new AppData();
            }

            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<AppData>(json) ?? new AppData();

            data.Artists ??= new List<Artist>();
            data.Songs ??= new List<Song>();
            data.Albums ??= new List<Album>();
            data.AlbumSongLinks ??= new List<AlbumSongLink>();

            foreach (var album in data.Albums)
            {
                if (album.ArtistId == 0)
                {
                    album.ArtistId = null;
                }
            }

            return data;
        }

        public void Save(string filePath)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public AppData()
        {
            Artists = new();
            Songs = new();
            Albums = new();
            AlbumSongLinks = new();
        }
    }
}
