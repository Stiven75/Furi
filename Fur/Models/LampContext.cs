using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Fur.Models
{
    public class LampContext: DbContext
    {
        public DbSet<Lamp> Lamps { get; set; }
        public DbSet<Bat> Bats { get; set; }
    }
}