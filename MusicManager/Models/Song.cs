namespace MusicManager.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        public int Year { get; set; }

        public string ImagePath { get; set; }
    }
}
