using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //query from db
            var sliderItems = new List<SliderViewModel>
            {
                new SliderViewModel {Caption = "Slider 1", ImageUrl ="/Images/Slider-1.jpg" },
                new SliderViewModel {Caption = "Slider 2", ImageUrl ="/Images/Slider-2.jpg" },
                new SliderViewModel {Caption = "Slider 3", ImageUrl ="/Images/Slider-3.jpg" },
            };
            ViewData["SliderItems"] = sliderItems;

            return View();
        }

        //public ActionResult ProductListSlider()
        //{
        //    var sliderItems = new List<SliderViewModel>
        //    {
        //        new SliderViewModel {Caption = "Slider 1", ImageUrl ="/Images/Slider-1.jpg" },
        //        new SliderViewModel {Caption = "Slider 2", ImageUrl ="/Images/Slider-2.jpg" },
        //        new SliderViewModel {Caption = "Slider 3", ImageUrl ="/Images/Slider-3.jpg" },
        //    };
        //    return View(sliderItems);

        //}
        public ActionResult Details()
        {
            //query from db
            var sliderItems = new List<SliderViewModel>
            {
                new SliderViewModel {Caption = "Slider 1", ImageUrl ="/images/producct-details-slider-2.jpg" },
                new SliderViewModel {Caption = "Slider 2", ImageUrl ="/images/producct-details-slider-1.jpg" },
            };
            ViewData["SliderItems"] = sliderItems;

            return View();
        }

        //public ActionResult ProductDetailsSlider()
        //{
        //    var sliderItems = new List<SliderViewModel>
        //    {
        //        new SliderViewModel {Caption = "Slider 1", ImageUrl ="/images/producct-details-slider-2.jpg" },
        //        new SliderViewModel {Caption = "Slider 2", ImageUrl ="/images/producct-details-slider-1.jpg" },
        //    };
        //    return View(sliderItems);

        //}

        public ActionResult ShowProductList()
        {
            //query from db
            var productList = new List<ProductViewModel>
            {
                new ProductViewModel {Id = 1,ProductName = "Snowa", ThumbnailUrl = "/images/img-1.jpg" },
                new ProductViewModel {Id = 1,ProductName = "Samsung", ThumbnailUrl = "/images/img-2.jpg" },
                new ProductViewModel {Id = 1,ProductName = "LG", ThumbnailUrl = "/images/img-3.jpg" },
                new ProductViewModel {Id = 1,ProductName = "Sony", ThumbnailUrl = "/images/img-4.jpg" },
            };

            return View(productList);
        }
    }
}