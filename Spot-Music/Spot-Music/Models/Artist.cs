using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        
        [Required]
        [Display(Name ="Artist Name")]
        public string ArtistName { get; set; }
        
        [DataType(DataType.DateTime),Required]
        public DateTime DOB { get; set; }
        
        [MinLength(10),MaxLength(100),Required]
        public string Bio { get; set; }
        public List<Songs_Artists> songs_Artists { get; set; }
    }
}
