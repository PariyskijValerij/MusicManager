namespace MusicManager.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        public int Year { get; set; }

        public string ImagePath { get; set; }

        public string? ExternalLink { get; set; }

        public static Song? GetSongById(AppData appData, int songId)
        {
            return appData.Songs.FirstOrDefault(s => s.Id == songId);
        }

        public static Song? GetByImageKey(AppData appData, string imageKey)
        {
            if (int.TryParse(imageKey, out int id))
            {
                return appData.Songs.FirstOrDefault(s => s.Id == id);
            }
            return null;
        }
    }
}
