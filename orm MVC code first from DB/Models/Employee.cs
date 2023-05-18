using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstFromDatabase.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(64)]
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}