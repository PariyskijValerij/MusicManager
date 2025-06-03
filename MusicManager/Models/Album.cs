namespace MusicManager.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ArtistId { get; set; }
        public string ImagePath { get; set; }

        public static Album? GetAlbumById(AppData appData, int albumId)
        {
            return appData.Albums.FirstOrDefault(s => s.Id == albumId);
        }

        public static Album? GetByImageKey(AppData appData, string imageKey)
        {
            if (int.TryParse(imageKey, out int id))
            {
                return appData.Albums.FirstOrDefault(a => a.Id == id);
            }
            return null;
        }
    }
}
