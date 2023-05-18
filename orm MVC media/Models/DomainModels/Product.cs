using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DomainModels
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string ProductName { get; set; }
        public int Price { get; set; }
        public byte[] Thumbnail { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}