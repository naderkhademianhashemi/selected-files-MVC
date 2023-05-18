using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Resource;

namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Resource.Message), 
            ErrorMessageResourceName = nameof(Message.Required))]
        [MinLength(5, ErrorMessageResourceType =typeof(Resource.Message), 
            ErrorMessageResourceName = nameof(Message.MinLen))]
        [MaxLength(128, ErrorMessage = "جداکثر طول رشته 128 کاراکتر می باشد")]
        [Display(Name ="نام محصول")]
        public string ProductName { get; set; }
    
        [Required(ErrorMessageResourceType = typeof(Resource.Message),
             ErrorMessageResourceName = nameof(Message.Required))]
        [StringLength(64, MinimumLength = 3, ErrorMessageResourceType =typeof(Resource.Message),
            ErrorMessageResourceName =nameof(Message.MinMaxLen))]
        [Display(Name ="گروه")]
        public string CategoryName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource.Message),
              ErrorMessageResourceName = nameof(Message.Required))]
        [Range(1000,int.MaxValue)]
        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [EmailAddress(ErrorMessage ="فرمت ایمیل صحیح نمی باشد")]
        [Display(Name = "ایمیل تامین کننده")]
        //[ScaffoldColumn(false)]
        public string SupplierEmail { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}