using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Order { get; set; }
        public Delivery()
        {
            Order = new List<Order>();
            return;
        }
    }
}