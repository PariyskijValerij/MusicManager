namespace MusicManager.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }
         
        public string Description { get; set; } = "";

        public string ImagePath { get; set; }

        public string? ExternalLink { get; set; }

        public static Artist? GetArtistById(AppData appData, int artistId)
        {
            return appData.Artists.FirstOrDefault(s => s.Id == artistId);
        }

        public static Artist? GetByImageKey(AppData appData, string imageKey)
        {
            if (int.TryParse(imageKey, out int id))
            {
                return appData.Artists.FirstOrDefault(a => a.Id == id);
            }
            return null;
        }

        public static Artist? GetBySongId(AppData appData, int? artistId)
        {
            if (artistId == null)
                return null;

            return appData.Artists.FirstOrDefault(a => a.Id == artistId.Value);
        }
    }
}
