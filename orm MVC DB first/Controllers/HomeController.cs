using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (NorthwindEntities db = new Models.NorthwindEntities())
            {
                var result = db.Categories.OrderBy(q => q.CategoryName)
                    .Select(q => new CategoryViewModel
                    { CategoryName = q.CategoryName, CategoryId = q.CategoryID })
                    .ToList();

                return View(result);

            }

               
        }

        public ActionResult Products()
        {
            using (NorthwindEntities db = new Models.NorthwindEntities())
            {
                var result = db.Products.OrderBy(q => q.ProductName )  
                    .Select(q => new ProductViewModel { ProductName = q.ProductName , ProductID =q.ProductID  })
                    .ToList();

                return View(result);

            }


        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}