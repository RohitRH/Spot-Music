using Spot_Music.Models;
using Spot_Music.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Repository
{
    public interface IMusicRepository
    {
        IEnumerable<Song> GetSongs();

        List<TopArtistViewMode> GetArtists();

        List<List<string>> GetArtistsOfTopSongs(List<Song> songs);

        List<List<string>> GetSongsOfTopArtists(List<TopArtistViewMode> artists);

        void StoreSongsData(AddSongPostViewModel songdata);

        int StoreArtistData(AddArtistPostViewModel artists);

        List<Users_Songs> GetRatedSongs(string user);

        void RateSong(string SongId,string RatingValue,string user);
    }

}
