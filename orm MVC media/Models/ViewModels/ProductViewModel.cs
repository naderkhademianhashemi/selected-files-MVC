using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string ProductName { get; set; }
        public int Price { get; set; }
        public byte[] Thumbnail { get; set; }
        public HttpPostedFileBase ThumbnailFile { get; set; }
        public string ThumbnailBase64 { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
    }
}