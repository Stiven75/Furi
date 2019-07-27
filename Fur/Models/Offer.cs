using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Articul { get; set; }
        public int? ColorId { get; set; }
        public Color Color { get; set; }
        public int? SizeId { get; set; }
        public Size Size { get; set; }
        public ICollection<Product> Products { get; set; }
        public Offer()
        {
            Products = new List<Product>();
            return;
        }
    }
}