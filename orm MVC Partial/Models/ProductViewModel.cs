using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public int Id { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}