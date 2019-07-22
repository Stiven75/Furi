using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Fur.Models
{
    public class СategoryContext : DbContext
    {
        public DbSet<Сategory> Сategories { get; set; }
    }
}