using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}