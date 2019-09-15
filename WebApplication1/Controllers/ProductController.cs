using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public ActionResult Basket()
        {
            var userId = User.Identity.GetUserId();
            var basket = db.Basket.Where(x => x.UserId == userId).ToList().LastOrDefault();

            return View(basket != null ? basket.BasketProducts.ToList() : null);
        }

        public async Task<ActionResult> AddToBasket(int id)
        {
            var product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var userId = User.Identity.GetUserId();
            var basket = db.Basket.Where(x => x.UserId == userId).ToList();
            if (basket == null || !basket.Any())
            {
                db.Basket.Add(new Basket { UserId = userId });
                await db.SaveChangesAsync();
            }

            var lastBasket = db.Basket.ToList().LastOrDefault();
            var basketProduct = db.BasketProducts.ToList()
                .FirstOrDefault(bp => bp.BasketId == lastBasket.BasketId && bp.ProductId == product.ProductId);
            if (basketProduct == null)
            {
                lastBasket.BasketProducts.Add(
                    new BasketProducts
                    {
                        BasketId = lastBasket.BasketId,
                        ProductId = product.ProductId,
                        ProductCount = 1
                    });
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ProductDetail), new { id = product.ProductId });
        }

        public async Task<ActionResult> ChangeProductCount(int basketProductId, int index)
        {
            var basketProduct = db.BasketProducts.Find(basketProductId);
            if (basketProduct == null)
            {
                return HttpNotFound();
            }

            basketProduct.ProductCount = index;
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Basket));
        }
    }
}
