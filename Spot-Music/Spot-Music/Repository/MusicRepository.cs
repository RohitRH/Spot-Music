using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Spot_Music.Data;
using Spot_Music.Models;
using Spot_Music.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;
        public MusicRepository(MusicDbContext context, IHostingEnvironment hostingenvironment)
        {
            this.context = context;
            this.hostingEnvironment = hostingenvironment;
        }

        public List<TopArtistViewMode> GetArtists()
        {
            var x = context.Songs_Artists.Include(p => p.Song).Include(q => q.Artist).ToList().GroupBy(g => g.ArtistId).Select(h => new { avg = h.Average(m => m.Song.Rating), ArtistId = h.Key }).OrderByDescending(x => x.avg).Take(10).ToList();

            List<TopArtistViewMode> artists = new List<TopArtistViewMode>();
            foreach (var item in x)
            {
               
                Artist art = context.Artists.Find(item.ArtistId);
                
                artists.Add(new TopArtistViewMode { ArtistId = art.ArtistId, ArtistName = art.ArtistName, DOB = art.DOB });
                
            }
            
            return artists;
        }

        public List<List<string>> GetArtistsOfTopSongs(List<Song> songs)
        {
            List<List<string>> artist_names = new  List<List<string>>();
            List<Songs_Artists> x = context.Songs_Artists.Include(p => p.Song).Include(q => q.Artist).ToList();
            
            foreach (var i in songs)
            {
                List<string> data = new List<string>();
                foreach (var j in x)
                {
                    if (i.SongId == j.Song.SongId)
                    {
                        data.Add(j.Artist.ArtistName);
                    }
                }
                artist_names.Add(data);
            }
            return artist_names;
        }

        public List<Users_Songs> GetRatedSongs(string user)
        {
            var users = context.Users.Where(p => p.Email == user).FirstOrDefault();

            var users_Songs = context.Users_Songs.Where(q => q.UserId == users.UserId).ToList();

            return users_Songs;
        }

        public IEnumerable<Song> GetSongs()
        {
            return context.Songs.OrderByDescending(p=>p.Rating).Take(10);
        }

        public List<List<string>> GetSongsOfTopArtists(List<TopArtistViewMode> artists)
        {
            List<Songs_Artists> x = context.Songs_Artists.Include(p => p.Song).Include(q => q.Artist).ToList();

            List<List<string>> SongsOfTopArtists = new List<List<string>>();
            foreach (var i in artists)
            {
                List<string> data = new List<string>();
                foreach (var j in x)
                {
                    if (i.ArtistId == j.Artist.ArtistId)
                    {
                        data.Add(j.Song.SongName);
                    }

                }
                SongsOfTopArtists.Add(data);
                Console.WriteLine(i.ArtistName);
            }

            return SongsOfTopArtists;
        }

        public void RateSong(string SongId, string RatingValue, string user)
        {
            var users = context.Users.Where(p => p.Email == user).FirstOrDefault();
            context.Users_Songs.Add(new Users_Songs { SongId = Convert.ToInt32(SongId), UserId = users.UserId });
            context.SaveChanges();
            var songsData = context.Songs.FirstOrDefault(q => q.SongId == Convert.ToInt32(SongId));
            double updatedRating = ((songsData.Rating * songsData.NumberOfRatings) + Convert.ToInt32(RatingValue)) / (songsData.NumberOfRatings + 1);
            songsData.Rating = updatedRating;
            songsData.NumberOfRatings = songsData.NumberOfRatings + 1;
            context.SaveChanges();
        }

        public int StoreArtistData(AddArtistPostViewModel artists)
        {
            Artist art = new Artist()
            {
                ArtistName = artists.ArtistName,
                DOB = artists.DOB,
                Bio = artists.Bio
            };
            context.Artists.Add(art);
            context.SaveChanges();
            int aid = art.ArtistId;
            return aid;
        }

        public void StoreSongsData(AddSongPostViewModel songdata)
        {
            string uniqueFileName = null;
            if (songdata.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + songdata.Image.FileName;
                string filepath = Path.Combine(uploadsFolder, uniqueFileName);
                songdata.Image.CopyTo(new FileStream(filepath, FileMode.Create));
            }
            Song songs = new Song
            {
                SongName = songdata.SongName,
                ReleaseDate = songdata.ReleasedDate, //DateTime.ParseExact(songdata.ReleasedDate.ToString(), "yyyy-MM-dd", null),
                ImagePath = uniqueFileName,
                Rating = 0
            };
            Console.WriteLine(songs.ReleaseDate);
            context.Songs.Add(songs);
            context.SaveChanges();
            var sid = songs.SongId;
            List<Songs_Artists> song_artist_details = new List<Songs_Artists>();
            foreach (var item in songdata.Artists)
            {
                song_artist_details.Add(new Songs_Artists { SongId = sid, ArtistId = Convert.ToInt32(item) });
            }

            context.AddRange(song_artist_details);
            context.SaveChanges();
        }
    }
}
