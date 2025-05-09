using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManager.Models
{
    public class AppData
    {
        public List<Artist> Artists { get; set; }
        public Dictionary<int, List<string>> ArtistSongs { get; set; }
        public List<Song> Songs { get; set; }
        public int ArtistIdCounter { get; set; }
        public int SongIdCounter { get; set; }
    }
}
