using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Offer> Offres { get; set; }
        public Color()
        {
            Offres = new List<Offer>();
            return;
        }
    }
}