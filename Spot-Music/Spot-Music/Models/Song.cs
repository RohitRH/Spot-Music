using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Required,Display(Name ="Song Name"),MinLength(3)]
        public string SongName { get; set; }

        [Required,DataType(DataType.DateTime),Display(Name ="Released Date")]
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public double Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public List<Songs_Artists> songs_Artists { get; set; }

        public virtual ICollection<Users_Songs> Users_Songs { get; set; }
    }
}
