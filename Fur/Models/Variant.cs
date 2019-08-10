using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Order { get; set; }
        public Variant()
        {
            Order = new List<Order>();
            return;
        }
    }
}