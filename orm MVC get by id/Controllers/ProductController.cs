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
            return View();
        }

        public ActionResult GetById(int id)
        {
            var model = new Product
            {
                Id = 101,
                CategoryName = "Mobile",
                Price = 1400,
                ProductName = "GLX",
            };

            return View(model);

            //model.Id = 10;

        }

        public string GetTopProductName()
        {
            return "Snowa";
        }

        public int GetTopPrice()
        {
            return 1500;
        }

        public string GetProductNameById(int id)
        {
            return "GLX";
        }
    }
}