using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using PagedList;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        AllInOneEntities db = new AllInOneEntities();
        public ActionResult Electronic()
        {
            ViewBag.Message = "Electronic Page";
            
            return View();
        }

        public ActionResult ClothingShoes()
        {
            ViewBag.Message = "Clothing Shoes Page";

            return View();
        }

        public ActionResult HomeLife()
        {
            ViewBag.Message = "Home Life Page";

            return View();
        }

        public ActionResult ProductDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}
