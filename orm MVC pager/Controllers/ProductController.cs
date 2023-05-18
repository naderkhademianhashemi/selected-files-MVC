using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        int _pageItemCount = 10;
        private NorthwindEntities db = new NorthwindEntities();
        public ActionResult Index(int? id = 1)
        {
            ViewBag.CurrentPage = id.Value;
            ViewBag.PageCount = Convert.ToInt32(Math.Round(db.Products.Count() / (double)_pageItemCount));

            int skipValue = (id.Value - 1) * _pageItemCount;

            var products = db.Products.Include(p => p.Category).Include(p => p.Supplier)
                .OrderBy(q => q.ProductName)
                .Skip(skipValue).Take(_pageItemCount);

            return View(products.ToList());
            //if (id == null)
            //{
            //    var products = db.Products.Include(p => p.Category).Include(p => p.Supplier);
            //    return View(products.ToList());
            //}
            //else
            //{
            //    int skipValue = (id.Value - 1) * _pageItemCount;

            //    var products = db.Products.Include(p => p.Category).Include(p => p.Supplier)
            //        .OrderBy(q => q.ProductName)
            //        .Skip(skipValue).Take(_pageItemCount);
            //    return View(products.ToList());
            //}
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,"+
            "UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
