using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private AllInOneEntities db = new AllInOneEntities();

        // GET: Admin
        public ActionResult Index(string p)
        {
            var products = from d in db.Product select d;
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(m => m.Name.Contains(p) || m.Explanation.Contains(p));
            }

            if(products.Count()==0)
            {
                ViewBag.Title = "Aradığınız ürün bulunamadı";
            }

            return View(products.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName");
            ViewBag.ColorId = new SelectList(db.Color, "ColorId", "ColorName");
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName");
            ViewBag.GenusId = new SelectList(db.Genus, "GenusId", "GenusName");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductCode,Name,Explanation,Price,Stock,CategoryId,GenusId,GenderId,ColorId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Color, "ColorId", "ColorName", product.ColorId);
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName", product.GenderId);
            ViewBag.GenusId = new SelectList(db.Genus, "GenusId", "GenusName", product.GenusId);
            return View(product);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Color, "ColorId", "ColorName", product.ColorId);
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName", product.GenderId);
            ViewBag.GenusId = new SelectList(db.Genus, "GenusId", "GenusName", product.GenusId);
            return View(product);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductCode,Name,Explanation,Price,Stock,CategoryId,GenusId,GenderId,ColorId")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Color, "ColorId", "ColorName", product.ColorId);
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName", product.GenderId);
            ViewBag.GenusId = new SelectList(db.Genus, "GenusId", "GenusName", product.GenusId);
            return View(product);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
