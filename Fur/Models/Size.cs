using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public Size()
        {
            Offers = new List<Offer>();
            return;
        }
    }
}