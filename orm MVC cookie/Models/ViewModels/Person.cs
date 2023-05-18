using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.CustomAttributes;

namespace WebApplication1.Models.ViewModels
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [CodeMelli("کد ملی صحیح وارد نمائید")]
        public string NationalCode { get; set; }
    }
}