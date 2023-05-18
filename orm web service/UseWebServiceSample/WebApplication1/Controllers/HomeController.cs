using System;
using WebApplication1.FADClassInfoService;
using WebApplication1.ServiceReference1;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //FADServiceSoapClient proxy = new FADServiceSoapClient();
            //var date = proxy.GetCurrentShamsiDate();
            //ViewBag.Date = date;

            NaderWebServiceSoapClient proxy2 = new NaderWebServiceSoapClient();
            var calc = proxy2.Calculator(11,22);
            ViewBag.Date = calc;
            
            return View();
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