using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class GoodService
    {
        public static IEnumerable<Good> GetBaskets()
        {
            var Goods = SqlService.GetSqlList("SELECT * FROM [dbo].[Goods]", GoodReader);
            return Goods;
        }


        public static IEnumerable<Good> GetBasketsByOrderId(int OrderId)
        {
            var Goods = SqlService.GetSqlList(String.Format("SELECT * FROM [dbo].[Goods] where OrderId={0}", OrderId), GoodReader);
            return Goods;
        }

        public static void InsUpGoods(Good Good)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].[Goods] WHERE Id={0})
                INSERT INTO [dbo].[Goods] ([OrderId],[OfferId],[ArtNo],[Price],[Count]) 
                VALUES ({1},{2},'{3}',{4},{5})
                  ELSE
                UPDATE [dbo].[Goods]  SET  OrderId={1},OfferId={2},ArtNo='{3}',Price={4},Count={5}  WHERE Id={0}";


            SqlService.SqlNon(String.Format(query, Good.Id, Good.OrderId, Good.OfferId, Good.ArtNo, Good.Price, Good.Count));
        }

        private static Good GoodReader(SqlDataReader reader)
        {

            return new Good()
            {
                Id = SqlHelper.GetInt(reader, "Id"),
                OfferId = SqlHelper.GetInt(reader, "OfferId"),
                OrderId = SqlHelper.GetInt(reader, "OrderId"),
                ArtNo = SqlHelper.GetString(reader, "ArtNo"),
                Price = SqlHelper.GetInt(reader, "Price"),
                Count = SqlHelper.GetInt(reader, "Count"),

            };


        }
    }



}