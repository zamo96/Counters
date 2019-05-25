using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace Counters.Models
{
    public class FillingContext:DbContext
    {
         public DbSet<Filling> Fillings { get; set; }
    }
}