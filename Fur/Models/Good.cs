using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Good
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public string Artikul { get; set; }
        public string Price { get; set; }
    }
}