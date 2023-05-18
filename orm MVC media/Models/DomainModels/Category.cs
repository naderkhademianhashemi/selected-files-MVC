using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.DomainModels
{
    //[Table("CategoryTable")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}