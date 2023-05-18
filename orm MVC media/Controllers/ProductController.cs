using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.DomainModels;
using WebApplication1.Models.ViewModels;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        FADContext _db = new FADContext();
        public ActionResult Index()
        {
            var products = _db.Products.OrderByDescending(q => q.Price);
            var model = new List<ProductViewModel>();
            ProductViewModel product;

            foreach (var item in products)
            {
                product = new ProductViewModel();
                product.CategoryId = item.CategoryId;
                product.ProductName = item.ProductName;
                product.Price = item.Price;
                product.Id = item.Id;
                product.PhotoUrl = item.PhotoUrl;

                if (item.Thumbnail != null)
                    product.ThumbnailBase64 = Convert.ToBase64String(item.Thumbnail);

                model.Add(product);
            }

            return View(model);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(ProductViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var product = new Product();
        //        product.CategoryId = model.CategoryId;
        //        product.Price = model.Price;
        //        product.ProductName = model.ProductName;

        //        //step1 
        //        if (model.ThumbnailFile != null)
        //        {
        //            //step2
        //            //100 kb
        //            if(model.ThumbnailFile.ContentLength > 100000)
        //            {
        //                ModelState.AddModelError("", "حجم فایل ارسالی بیشتر از 100 کیلوبایت است");
        //                ViewBag.Categories = new SelectList(_db.Categories, "Id", "CategoryName", model.CategoryId);
        //                return View(model);
        //            }
        //            //get file extension
        //            string[] temp = model.ThumbnailFile.FileName.Split('.');
        //            string extension = temp[temp.Length - 1];

        //            //generate new name
        //            string newFileName = $"{Guid.NewGuid().ToString()}.{extension}";

        //            //generate new name with  File oldName
        //            string newFileName2 = $"{temp[0]}_{Guid.NewGuid().ToString()}.{extension}";

        //            //save file in hard
        //            string folderPath = Server.MapPath("\\Media");
        //            model.ThumbnailFile.SaveAs($"{folderPath}\\{newFileName}");

        //            product.PhotoUrl = $"\\Media\\{newFileName}";

        //            //save file in db
        //            product.Thumbnail = StreamUtility.CovnertToByteArray(model.ThumbnailFile.InputStream);

        //            _db.Products.Add(product);
        //            _db.SaveChanges();

        //            return RedirectToAction("Index");
        //        }

        //    }

        //    ViewBag.Categories = new SelectList(_db.Categories, "Id", "CategoryName", model.CategoryId);
        //    return View(model);
        //}
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_db.Categories, "Id", "CategoryName");

            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                product.CategoryId = model.CategoryId;
                product.Price = model.Price;
                product.ProductName = model.ProductName;
                //step1 
                if (model.ThumbnailFile != null)
                {
                    //step2
                    if (model.ThumbnailFile.ContentLength > 100000)//100 kb
                    {
                        ModelState.AddModelError("", "حجم فایل ارسالی بیشتر از 100 کیلوبایت است");
                        ViewBag.Categories = new SelectList(_db.Categories, "Id", "CategoryName", model.CategoryId);
                        return View(model);
                    }//if_3
                    //get file extension
                    string[] temp = model.ThumbnailFile.FileName.Split('.');
                    string extension = temp[temp.Length - 1];
                    //generate new name
                    //string newFileName = $"{Guid.NewGuid().ToString()}.{extension}";
                    //generate new name with  File oldName
                    string newFileName2 = $"{temp[0]}_{Guid.NewGuid().ToString()}.{extension}";
                    product.PhotoUrl = newFileName2;
                    //save file in db
                    product.Thumbnail = StreamUtility.CovnertToByteArray(model.ThumbnailFile.InputStream);
                    _db.Products.Add(product);
                    _db.SaveChanges();
                    //save file in hard
                    string folderPath = Server.MapPath($"\\Media\\Product\\{product.Id}");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }//if_4
                    model.ThumbnailFile.SaveAs($"{folderPath}\\{newFileName2}");
                    return RedirectToAction("Index");
                }//if_2
            }//if_1
            ViewBag.Categories = new SelectList(_db.Categories, "Id", "CategoryName", model.CategoryId);
            return View(model);
        }
    }
}