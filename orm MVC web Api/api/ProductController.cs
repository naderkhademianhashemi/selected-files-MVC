using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.api
{
    public class ProductController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            using (var db = new NorthwindEntities())
            {
                var products = db.Products.OrderBy(q => q.ProductName).
                    Select(q => new ProductViewModel
                    {
                        Id = q.ProductID, 
                        ProductName = q.ProductName,
                        Price = q.UnitPrice.Value,
                    }).ToList();
                return Json(products);
            }
        }

        public IHttpActionResult GetById(int id)
        {
            using (var db = new NorthwindEntities())
            {
                var product = db.Products.FirstOrDefault(q => q.ProductID == id);
                var model = new ProductViewModel
                {
                    Id = product.ProductID,
                    ProductName = product.ProductName,
                    Price = product.UnitPrice.Value,
                };
                return Json(model);
            }
        }
    }
}
