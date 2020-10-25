using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class BasketService
    {
        public static IEnumerable<Basket> GetBasket()
        {
            var Baskets = SqlService.GetSqlList("SELECT * FROM [dbo].[Basket]", BasketReader);
            return Baskets;
        }


        public static Basket GetBasketByOfferId(int OfferId)
        {
            var Basket = SqlService.GetSqlOne(String.Format("SELECT * FROM [dbo].[Basket] Where OfferId={0}", OfferId), BasketReader);
            return Basket;
        }



        public static void InsUpBasket(Basket basket)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].[Basket] WHERE Id={0})
                INSERT INTO [dbo].[Basket] ([OfferId],[Count]) 
                VALUES ({1},{2})
                  ELSE
                UPDATE [dbo].[Basket]  SET  OfferId={1},Count={2}  WHERE Id={0}";


            SqlService.SqlNon(String.Format(query, basket.Id, basket.OfferId, basket.Count));
        }


        public static void DelBasketById(int basketID)
        {
            var query = @"DELETE FROM [dbo].[Basket] WHERE Id={0}";

            SqlService.SqlNon(String.Format(query, basketID));
        }



        public static void DelBasketByOfferId(Basket basket)
        {
            var query = @"DELETE FROM [dbo].[Basket] WHERE OfferId={0}";

            SqlService.SqlNon(String.Format(query, basket.Id));
        }



        private static Basket BasketReader(SqlDataReader reader)
        {

            return new Basket()
            {
                Id = SqlHelper.GetInt(reader, "Id"),
                OfferId = SqlHelper.GetInt(reader, "OfferId"),
                Count = SqlHelper.GetInt(reader, "Count"),

            };


        }
    }



}