using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealMonkey.Models;
using MealMonkey.ViewModel;
using Microsoft.AspNet.Identity;

namespace MealMonkey.Controllers
{
    public class ProductsController : Controller
    {
        private masterEntities mdb = new masterEntities();
        private ProductEntities db = new ProductEntities();


        // GET: Products
        public ActionResult Index()
        {
            return View(db.MM_Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MM_Products mM_Products = db.MM_Products.Find(id);
            if (mM_Products == null)
            {
                return HttpNotFound();
            }
            TempData["ProductId"] = id;
            //TempData["UserId"] = User.Identity.GetUserId();
            TempData["UserId"] = 33;
            return View(mM_Products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Description,Price,Quantity,ImageUrl,CategoryId,IsActive,CreatedDate")] MM_Products mM_Products)
        {
            if (ModelState.IsValid)
            {
                db.MM_Products.Add(mM_Products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mM_Products);
        }

        public ActionResult CartTable()
        {
            dynamic dy = new ExpandoObject();
            dy.Carts = getCarts();
            dy.Products = getProducts();



  

            return View(dy); 
        }
        //Helping Methods
        public List<MM_Carts> getCarts()
        {
            List<MM_Carts> Carts = mdb.MM_Carts.ToList();
            return Carts;

        }
        public List<MM_Products> getProducts()
        {
            List<MM_Products> Products = db.MM_Products.ToList();
            return Products;

        }
        //Edit Converted to cart
        // GET: Products/Cart/5

        //Create cart
        public ActionResult Cart(int? id)
        {
            return View();
        }

        // POST: Products/Cart/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cart([Bind(Include ="Cartid,Productid,Quantity,UserId")] MM_Carts mM_Carts)
        {
            MM_Carts temp = new MM_Carts();


            if (ModelState.IsValid)
            {
                temp.ProductId = Convert.ToInt32( TempData["ProductId"]);
                temp.UserId = Convert.ToInt32(TempData["UserId"] );
                temp.CartId = mM_Carts.CartId;
                temp.Quantity = mM_Carts.Quantity;
                

                mdb.MM_Carts.Add(temp);
                
                
                mdb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mM_Carts);
        }
        // GET: Products/CartDelete/5
        public ActionResult CartDelete(int? id)
        {
            MM_Carts mM_Cart = mdb.MM_Carts.Find(id);
            mdb.MM_Carts.Remove(mM_Cart);
            mdb.SaveChanges();
            return RedirectToAction("CartTable");
            
        }
        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MM_Products mM_Products = db.MM_Products.Find(id);
            if (mM_Products == null)
            {
                return HttpNotFound();
            }
            return View(mM_Products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MM_Products mM_Products = db.MM_Products.Find(id);
            db.MM_Products.Remove(mM_Products);
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
