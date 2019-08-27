using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()     ////Home page
        {
            return View();
        }

        public ActionResult Electronic()     ////Electronic
        {
            return View();
        }

        public ActionResult ClothingShoes()         //Contact
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HomeLife()          ///About
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Basket()
        {
            return View();
        }
    }
}