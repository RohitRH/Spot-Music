using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.ViewModels
{
    public class AddSongViewModel
    {
        [Required, Display(Name = "Song Name"), MinLength(3)]
        public string SongName { get; set; }

        [Required, DataType(DataType.DateTime), Display(Name = "Released Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime DOB { get; set; }

        [MinLength(10), MaxLength(100), Required]
        public string Bio { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public List<ArtistSelectListViewModel> Artists { get; set; }
    }
}
