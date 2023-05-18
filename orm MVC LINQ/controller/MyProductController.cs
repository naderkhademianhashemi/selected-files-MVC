using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyProductController : Controller
    {
        //http://linq101.nilzorblog.com/linq101-lambda.php
        List<Product> _productList = new List<Product>()
        {
            new Product {CategoryId = 101,Price = 1500, ProductId = 1, ProductName="Snowa" },
            new Product {CategoryId = 101,Price = 2500, ProductId = 2, ProductName="Ssamsung" },
            new Product {CategoryId = 101,Price = 1700, ProductId = 3, ProductName="LG" },
        };
        // GET: MyProduct
        public ActionResult Index()
        {
            var result = from p in _productList
                         where p.Price > 1500
                         orderby p.Price descending
                         select p;//new {Title = p.ProductName, Id =  p.ProductId };

            var result2 = _productList.Where(q => q.Price > 1500)
                .OrderByDescending(q => q.Price).Select(q => new {q.ProductId, q.ProductName });

            return View(result);
        }
        public ActionResult Details(int id)
        {
            var product = _productList.FirstOrDefault(q => q.ProductId == id);
            var product2 = _productList.SingleOrDefault(q => q.ProductId == id);

            return View(product);
        }
        public ActionResult TopProducts()
        {
            var result = _productList.OrderByDescending(q => q.Price).Take(2);
            return View(result);
        }
    }
}