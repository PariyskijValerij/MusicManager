namespace MusicManager.Models
{
    public class AppData
    {
        public List<Artist> Artists { get; set; }
        public Dictionary<int, List<string>> ArtistSongs { get; set; }
        public List<Song> Songs { get; set; }
        public int ArtistIdCounter { get; set; }
        public int SongIdCounter { get; set; }
        public List<Album> Albums { get; set; }
        public List<AlbumSongLink> AlbumSongLinks { get; set; }
        public int AlbumIdCounter { get; set; }
    }
}
