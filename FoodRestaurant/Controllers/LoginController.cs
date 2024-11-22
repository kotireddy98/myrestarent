using FoodRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodRestaurant.Controllers
{
    public class LoginController : Controller
    {

        public class Users
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public ActionResult Login()
        {
            return View();
        }

        private static readonly List<Users> list = new List<Users>
        {
            new Users { Username = "Admin", Password = "12345" },
            new Users { Username = "Gopi", Password = "12345" },
            new Users { Username = "Kota", Password = "12345" }
        };



        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var userd = list.Find(u => u.Username == username && u.Password == password);

            var user = list.Find(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase)
                                                 && u.Password == password);

            if (user != null)
            {
                Session["LoggedInUser"] = user.Username;

                return RedirectToAction("Home", "Home");
            }
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }
    }
}