using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        string key = "FAD";
        public ActionResult Index(string id)
        {
            //var encrypt = EncryptionUtility.Encryption("1", key);
            var decrypt = EncryptionUtility.Decryption(id, key);
            if (decrypt == "1")
            {
                ViewBag.OrderTitle = "Order 1 Info";
            }
            else if(decrypt == "2")
            {
                ViewBag.OrderTitle = "Order 2 Info";
            }
            return View();
        }

        public ActionResult List()
        {
            var orderList = new List<OrderViewModel>
            {
                new OrderViewModel {Id = EncryptionUtility.Encryption("1", key), Title ="Order 1 Info" },
                new OrderViewModel {Id = EncryptionUtility.Encryption("2", key), Title ="Order 2 Info" },
            };
            return View(orderList);
        }
    }
}