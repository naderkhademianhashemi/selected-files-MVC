using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllCategory()
        {
            Thread.Sleep(8000);
            using (var db = new NorthWindEntities())
            {
                var model = db.Categories.OrderBy(q => q.CategoryName)
                    .Select(q => new CategoryViewModel
                    {
                        CategoryId = q.CategoryID,
                        CategoryName = q.CategoryName,
                        Description = q.Description
                    }).ToList();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult AddCategory(string categoryName, string description)
        {
            try
            {
                using (var db = new NorthWindEntities())
                {
                    var category = new Category
                    {
                        CategoryName = categoryName,
                        Description = description,
                    };
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return Json(new MyAjaxResult { IsSuccess = true });
                }
            }
            catch
            {
                return Json(new MyAjaxResult { IsSuccess = false, Message = "خطا در ذخیره گروه جدید" });
            }
        }
    }
}