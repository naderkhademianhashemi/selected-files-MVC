using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Tools;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //control
            filterContext.ExceptionHandled = true;
            //log
            Logger.Error(filterContext.Exception);
            //generate new exception
            throw new Exception();
            //redirect to message action
            filterContext.Result = RedirectToAction("Index", "Error");
        }
        [HandleError(View ="Error", ExceptionType = typeof(NullReferenceException))]
        [HandleError(View ="Error2", ExceptionType = typeof(StackOverflowException))]
        public ActionResult Index(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            //throw new Exception();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //save in db
                    ModelState.AddModelError("", "لطفا همه فیلدها را کامل نمائید");
                }
                else
                {
                    //throw new Exception();
                    //generate error message
                    //return
                    ModelState.AddModelError("", "لطفا همه فیلدها را کامل نمائید");
                }
            }
            catch(Exception ex)
            {
                //1
                //write to log
                Logger.Error(ex);
                //2
                //show message to user
                ModelState.AddModelError("", "خطا در ذخیره اطلاعات کارمند");
                return View();
            }
            finally
            {
                //close connection
                //dispose objects
                //dispose stream
            }
            return View();
        }
    }
}