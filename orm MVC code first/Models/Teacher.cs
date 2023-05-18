using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstSample.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
        [EmailAddress]
        [MaxLength(64)]
        public string Email { get; set; }
    }
}