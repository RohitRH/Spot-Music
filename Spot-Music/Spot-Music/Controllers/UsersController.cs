using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spot_Music.Data;
using Spot_Music.Models;
using Spot_Music.ViewModels;
using Spot_Music.Repository;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Spot_Music.Controllers
{
    public class UsersController : Controller
    {
        // GET: /<controller>/

        private readonly IMusicRepository Music;
        private readonly MusicDbContext context;

        public UsersController( IMusicRepository Music, MusicDbContext context)
        {

            this.Music = Music;
            this.context = context;

        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users RegistrationDetails)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(RegistrationDetails);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
           return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel LoginDetails)
        {
            if (ModelState.IsValid)
            {
                var x = context.Users.Where(q => q.Email == LoginDetails.Email && q.Password == LoginDetails.Password).Count();
                if (x != 0)
                {
                    ViewBag.loggedin = true;
                    HttpContext.Session.SetString("user", LoginDetails.Email);
                    HttpContext.Session.SetInt32("login",1);
                    return RedirectToAction("Index", "Home");

                }
                ViewBag.Message = "Incorrect Email or Password";
                return View();
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetInt32("login", 0);
            return RedirectToAction("Index", "Home");
        }
    }
}
