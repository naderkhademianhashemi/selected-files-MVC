using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        //[AllowAnonymous]
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
                //save in db

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}