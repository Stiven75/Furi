using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Photi { get; set; }
        public ICollection<Product> Products { get; set; }
        public Photo()
        {
            Products = new List<Product>();
            return;
        }
    }
}