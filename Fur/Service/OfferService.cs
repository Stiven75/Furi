using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class OfferService
    {
        public static IEnumerable<Offer> GetOffers()
        {
            var Offer = SqlService.GetSqlList("SELECT * FROM [dbo].[Offer]", OfferReader);
            return Offer;
        }
        public static Offer GetOffersById(int Id)
        {
            var Offer = SqlService.GetSqlOne(String.Format("SELECT * FROM [dbo].[Offer] Where Id={0}", Id), OfferReader);
            return Offer;
        }

        public static IEnumerable<Offer> GetOffersByProductId(int ProductId)
        {
            var Offer = SqlService.GetSqlList(String.Format("SELECT * FROM [dbo].[Offer] Where ProductId={0}", ProductId), OfferReader);
            return Offer;
        }

        public static void InsUpOffer(Offer offer)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].Offer WHERE Id={0})
                INSERT INTO [dbo].Offer ([ArtNo],[ColorId],[SizeId],[Price],[ProductId]) 
                VALUES ('{1}',{2},{3},{4},{5})
                  ELSE
                UPDATE [dbo].Offer  SET  ArtNo='{1}',ColorId={2},
                  SizeId={3},Price={4}  WHERE Id={0}";


            SqlService.SqlNon(String.Format(query, offer.Id, offer.ArtNo, offer.ColorId, offer.SizeId, offer.Price,offer.ProductId));
        }


        public static void DelOffer(Offer Offer)
        {
            var query = @"DELETE FROM [dbo].[Offer] WHERE Id={0}";

            SqlService.SqlNon(String.Format(query, Offer.Id));
        }



        private static Offer OfferReader(SqlDataReader reader)
        {

            return new Offer()
            {
                Id = SqlHelper.GetInt(reader, "Id"),
                ColorId = SqlHelper.GetInt(reader, "ColorId"),
                ProductId = SqlHelper.GetInt(reader, "ProductId"),
                ArtNo = SqlHelper.GetString(reader, "ArtNo"),
                SizeId = SqlHelper.GetInt(reader, "SizeId"),
                Price = SqlHelper.GetInt(reader, "Price"),

            };


        }
    }
}