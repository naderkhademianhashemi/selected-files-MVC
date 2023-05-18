using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstFromDatabase.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string CountryName { get; set; }
        public string Description { get; set; }
    }
}