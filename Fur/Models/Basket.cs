using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public string Articul { get; set; }
        public int Price { get; set; }
    }
}