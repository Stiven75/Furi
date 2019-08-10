using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Fur.Models
{
    public class LampContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Basket> Baskets  { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Order> Orders { get; set; }
        /*
        
                public DbSet<Categoru> Categories { get; set; }
                public DbSet<Photo> Photos { get; set; }
        */
    }
}