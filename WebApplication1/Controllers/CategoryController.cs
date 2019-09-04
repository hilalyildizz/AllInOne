using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private AllInOneEntities db = new AllInOneEntities();

        // GET: Category
        public ActionResult Index()
        {
            var urun = db.Urun.Include(u => u.Cins).Include(u => u.Cinsiyet).Include(u => u.Kategori).Include(u => u.Renk);
            return View(urun.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.cinsID = new SelectList(db.Cins, "cinsID", "cins1");
            ViewBag.cinsiyetID = new SelectList(db.Cinsiyet, "cinsiyetID", "cinsiyet1");
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi");
            ViewBag.renkID = new SelectList(db.Renk, "renkID", "renk1");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "urunID,urunKodu,adi,aciklama,fiyat,stokMiktari,kategoriID,cinsID,cinsiyetID,renkID")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urun.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cinsID = new SelectList(db.Cins, "cinsID", "cins1", urun.cinsID);
            ViewBag.cinsiyetID = new SelectList(db.Cinsiyet, "cinsiyetID", "cinsiyet1", urun.cinsiyetID);
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi", urun.kategoriID);
            ViewBag.renkID = new SelectList(db.Renk, "renkID", "renk1", urun.renkID);
            return View(urun);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.cinsID = new SelectList(db.Cins, "cinsID", "cins1", urun.cinsID);
            ViewBag.cinsiyetID = new SelectList(db.Cinsiyet, "cinsiyetID", "cinsiyet1", urun.cinsiyetID);
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi", urun.kategoriID);
            ViewBag.renkID = new SelectList(db.Renk, "renkID", "renk1", urun.renkID);
            return View(urun);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "urunID,urunKodu,adi,aciklama,fiyat,stokMiktari,kategoriID,cinsID,cinsiyetID,renkID")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cinsID = new SelectList(db.Cins, "cinsID", "cins1", urun.cinsID);
            ViewBag.cinsiyetID = new SelectList(db.Cinsiyet, "cinsiyetID", "cinsiyet1", urun.cinsiyetID);
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriAdi", urun.kategoriID);
            ViewBag.renkID = new SelectList(db.Renk, "renkID", "renk1", urun.renkID);
            return View(urun);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
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
