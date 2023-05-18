using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstSample.Models
{
    public class NwModel :DbContext
    {
        public NwModel():base("name=NWModel")
        {

        }

        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}