using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController() {/*for dependency Injection Not Implemented*/ }

        public ActionResult Index()
        {
            if (HttpContext.Request.Cookies["id"] != null)
            {
                //read Cookie
                var id = HttpContext.Request.Cookies["id"].Value;
                HttpContext.Response.Cookies["id"].Value = "202";
            }
            else
            {
                var cookie = new HttpCookie("id", "202");
                HttpContext.Response.Cookies.Add(cookie);
            }
            return View();
        }
        public async Task<ActionResult> GetAllCategory()
        {
            //Thread.Sleep(2000);
            var service = new GenericService<Category>();
            var result = await service.GetAllAsync();

            var model = result.Select(q => new CategoryViewModel
            {
                CategoryId = q.CategoryID,
                CategoryName = q.CategoryName,
                Description = q.Description
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
            //using (var db = new NorthwindEntities())
            //{
            //    var model = db.Categories.OrderBy(q => q.CategoryName)
            //        .Select(q => new CategoryViewModel
            //        {
            //            CategoryId = q.CategoryID,
            //            CategoryName = q.CategoryName,
            //            Description = q.Description
            //        }).ToList();

            //    return Json(model, JsonRequestBehavior.AllowGet);
            //}
        }
        [HttpPost]
        public async Task<ActionResult> AddCategory(string categoryName, string description)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = categoryName,
                    Description = description,
                };
                var service = new GenericService<Category>();
                await service.InsertAsync(category);
                return Json(new MyAjaxResult { IsSuccess = true });
                //using (var db = new NorthwindEntities())
                //{
                //    var category = new Category
                //    {
                //        CategoryName = categoryName,
                //        Description = description,
                //    };
                //    db.Categories.Add(category);
                //    db.SaveChanges();

                //    return Json(new MyAjaxResult { IsSuccess = true });
                //}
            }
            catch
            {
                return Json(new MyAjaxResult { IsSuccess = false, Message = "خطا در ذخیره گروه جدید" });
            }
        }

        public ActionResult RemoveCategory(int id)
        {
            try
            {
                using (var db = new masterEntities())
                {
                    var category = db.Categories.FirstOrDefault(q => q.CategoryID == id);
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return Json(new MyAjaxResult { IsSuccess = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new MyAjaxResult { IsSuccess = false, Message = "خطا در ذخیره گروه جدید" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}