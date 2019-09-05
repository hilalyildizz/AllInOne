using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HomePage()     ////Home page
        {
            return View();
        }
               
        public ActionResult Basket()
        {
            return View();
        }

        
    }
}