using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fur.Models;
using Fur.Service;

namespace Fur.Models
{



    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtNo { get; set; }
        public bool Enabled { get; set; }
        public int? CategoryId { get; set; }
        public IEnumerable<Offer> Offer { get {

                return OfferService.GetOffersByProductId(Id).ToList();
            
            } }
        public string Photo { get; set; }


        public Product() 
        { }


    }


}