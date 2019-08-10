using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fur.Models;

namespace Fur.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefon { get; set; }
        public int? VariantId { get; set; }
        public Variant Variant { get; set; }
        public int? DeliveryId { get; set; }
        public Delivery Delivery { get; set; }


        public ICollection<Good> Good { get; set; }
        public Order()
        {
            Good = new List<Good>();
            return;
        }
    }
}