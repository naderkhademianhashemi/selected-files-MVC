using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Price { get; set; }
    }
}