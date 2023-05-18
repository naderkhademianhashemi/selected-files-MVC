using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(11, MinimumLength = 11)]
        public string Mobile { get; set; }
    }
}