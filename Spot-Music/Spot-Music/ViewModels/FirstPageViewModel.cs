using System;
using Spot_Music.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.ViewModels
{
    public class FirstPageViewModel
    {
        public List<Song> TopSongs { get; set; }
        public List<TopArtistViewMode> TopArtists { get; set; }
        public List<List<string>> ArtistsOfTopSongs { get; set; }
        public List<List<string>> SongsOfTopArtists { get; set; }
        public List<Users_Songs> users { get; set; }
    }
}
