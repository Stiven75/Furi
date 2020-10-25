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
        public string PhoneNuber { get; set; }
        public string DeliveryName { get; set; }
        public string PaymentString { get; set; }
        public List<Good> goods { get; set; }
        public int CostOrder { get; set; }
    }
}