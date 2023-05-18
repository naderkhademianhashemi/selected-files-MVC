using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var model = new List<Product>
            {
                new Product {CategoryName = "Digital", Id = 101, Price = 1500,
                    ProductName ="Snowa", SupplierEmail = "test@gmail.com" },
                    new Product {CategoryName = "Digital", Id = 101, Price = 1500,
                    ProductName ="Snowa", SupplierEmail = "test@gmail.com" },
            };
            return View(model);
        }

        public ActionResult Create()
        {
            ModelState.AddModelError("", "لطفا بروید صبح ثبت نام کنید");
            ModelState.AddModelError("", "لطفا قبل از ثبت نام نیت کنید");
            ModelState.AddModelError("", "لطفا ثبت نام نکنید");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string productName, string categoryName, int price)
        {
            return View();
        }
        public ActionResult C2()
        {
            return View();
        }
    }
}