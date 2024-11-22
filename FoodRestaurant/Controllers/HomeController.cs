using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodRestaurant.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
    }
}