using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spot_Music.Data;
using Spot_Music.Models;
using Spot_Music.ViewModels;
using Spot_Music.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Spot_Music.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMusicRepository Music;
        private readonly MusicDbContext context;
       
        public HomeController(ILogger<HomeController> logger, IMusicRepository Music, MusicDbContext context)
        {
            _logger = logger;
            this.Music = Music;
            this.context = context;
            
        }

        public IActionResult Index()
        {
            List<Song> TopSongs = Music.GetSongs().ToList();
            List<TopArtistViewMode> TopArtists = Music.GetArtists();

            List<Users_Songs> users_Songs = new List<Users_Songs>();
            
            if (HttpContext.Session.GetInt32("login")==null)
            {
                HttpContext.Session.SetInt32("login",0);
            }
            ViewBag.loggedin = HttpContext.Session.GetInt32("login");
            if (HttpContext.Session.GetInt32("login") == 1)
            {
                var user = HttpContext.Session.GetString("user");
                
                users_Songs = Music.GetRatedSongs(user);
            }
            FirstPageViewModel data = new FirstPageViewModel
            {
                TopSongs = TopSongs,
                TopArtists = TopArtists,
                ArtistsOfTopSongs = Music.GetArtistsOfTopSongs(TopSongs),
                SongsOfTopArtists = Music.GetSongsOfTopArtists(TopArtists),
                users = users_Songs
            };
            return View(data);
        }

        [HttpGet]
        public IActionResult AddSong()
        {
            if (HttpContext.Session.GetInt32("login")==0)
            {
                return RedirectToAction("Login","Users");
            }
            ViewBag.items =  context.Artists.Select(p=>new SelectListItem {Value = p.ArtistId.ToString() , Text = p.ArtistName }).ToList() ;
            ViewBag.loggedin = HttpContext.Session.GetInt32("login");
            return View();
        }

        [HttpPost]
        public IActionResult AddSong(AddSongPostViewModel songdata)
        {
            
            if (ModelState.IsValid)
            {
                Music.StoreSongsData(songdata);
            }
            
            return RedirectToAction("AddSong","Home");
        }
        [HttpPost]
        public IActionResult AddArtist([FromBody]AddArtistPostViewModel artists)
        {
            var aid = Music.StoreArtistData(artists);
            return Ok(aid);
        }

        [HttpPost]
        public IActionResult RateSong()
        {
            var SongId = Request.Form["SongId"];
            var RatingValue = Request.Form["Rating"];
            var user = HttpContext.Session.GetString("user");
           
            Music.RateSong(SongId,RatingValue,user);
            return RedirectToAction("Index","Home");
        }
       


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
