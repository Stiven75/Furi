using Fur.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Good
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OfferId { get; set; }
        public string ArtNo { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }


        public Offer Offer
        {

            get { return OfferService.GetOffersById(OfferId); }
        }
    }
}