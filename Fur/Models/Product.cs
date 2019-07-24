using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fur.Models;

namespace Fur.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Articul { get; set; }
        public string Activiti { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? OfferId { get; set; }      
        public Offer Offer { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
    }

}