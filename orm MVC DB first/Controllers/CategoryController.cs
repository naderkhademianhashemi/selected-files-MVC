using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //var result = db.Categories.OrderBy(q => q.CategoryName)
                //    .Select(q => new CategoryViewModel
                //    { CategoryId = q.CategoryID, CategoryName = q.CategoryName }).ToList();

                var result = db.Categories.OrderBy(q => q.CategoryName).ToList();
                var model = new List<CategoryViewModel>();
                CategoryViewModel categoryViewModel;
                foreach (var item in result)
                {
                    categoryViewModel = new CategoryViewModel();
                    categoryViewModel.CategoryId = item.CategoryID; // method miladi to shamsi
                    categoryViewModel.CategoryName = item.CategoryName;

                    model.Add(categoryViewModel);
                }

                return View(model);
            }
          
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (NorthwindEntities db = new NorthwindEntities())
                {
                    var category = new Category
                    {
                        CategoryID = model.CategoryId,
                        CategoryName = model.CategoryName
                    };

                    //add to dbcontext
                    db.Categories.Add(category);

                    //save changes
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "داده های ارسالی را کامل نمائید");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //if(db.Categories.Any(q => q.CategoryID == id))
                //{

                //}
                var category = db.Categories.SingleOrDefault(q => q.CategoryID == id);
                if (category != null)
                {
                    var model = new CategoryViewModel
                    {
                        CategoryId = category.CategoryID,
                        CategoryName = category.CategoryName,
                    };

                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("", "رکورد مورد نظر پیدا نشد");
                    return View();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (NorthwindEntities db = new NorthwindEntities())
                {
                    var category = db.Categories.SingleOrDefault(q => q.CategoryID == model.CategoryId);
                    category.CategoryName = model.CategoryName;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(model);
            }
        }

        NorthwindEntities _db = new NorthwindEntities();
        public ActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(q => q.CategoryID == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "آیتم مورد نظر پیدا نشد");
                 return RedirectToAction("Index");
            }
        }
    }
}