using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models.DomainModels;

namespace WebApplication1.Models
{
    public class FADContext :DbContext
    {
        public FADContext():base("name=DefaultConnection")
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}