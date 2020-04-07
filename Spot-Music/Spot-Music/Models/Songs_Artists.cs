using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Models
{
    public class Songs_Artists
    {
        [Key]
        public int SongId { get; set; }
        [Key]
        public int ArtistId { get; set; }

        public Song Song { get; set; }
        public Artist Artist { get; set; }
    }
}
