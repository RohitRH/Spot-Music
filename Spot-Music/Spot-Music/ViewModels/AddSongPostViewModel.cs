using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.ViewModels
{
    public class AddSongPostViewModel
    {
        public string SongName { get; set; }
        public DateTime ReleasedDate { get; set; }
        public IFormFile Image { get; set; }
        public List<string> Artists { get; set; }
    }
}
