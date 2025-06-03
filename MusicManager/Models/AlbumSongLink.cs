namespace MusicManager.Models
{
    public class AlbumSongLink
    {
        public int AlbumId { get; set; }
        public int SongId { get; set; }

        public static AlbumSongLink? GetByAlbumAndSong(AppData appData, int albumId, int songId)
        {
            return appData.AlbumSongLinks.FirstOrDefault(l => l.AlbumId == albumId && l.SongId == songId);
        }
    }
}
