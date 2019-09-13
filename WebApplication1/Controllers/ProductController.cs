using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        AllInOneEntities db = new AllInOneEntities();

        // GET: Product/ProductCategory
        public ActionResult ProductCategory(int id)
        {            
            var products = from s in db.Product select s;
            products = products.Where(x => x.CategoryId == id);
            
            return View(products.ToList());
        }

        // GET: Product/ProductFilter
        public ActionResult ProductFilter()
        {
            var filter = from d in db.Product select d;

            return View();
        }

        // GET: Product/ProductDetail
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

        // GET: Product/SearchProduct
        public ActionResult SearchProduct(string p)
        {
            var products = from d in db.Product select d;
            if (!string.IsNullOrEmpty(p.ToString()))
            {
                products = products.Where(m => m.Name.Contains(p.ToString()) || m.Explanation.Contains(p.ToString()));
            }
            else
            {
                ViewBag.Title = "Aradığınız ürün bulunamadı";
            }
            return View(products.ToList());
        }


        [HttpGet]
        public ActionResult Basket()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Basket (int p)
        {
           




            return View();
        }
    }
}