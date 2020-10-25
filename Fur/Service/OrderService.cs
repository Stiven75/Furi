using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class OrderService
    {
        public static IEnumerable<Order> GetOrder()
        {
            var Orders = SqlService.GetSqlList("SELECT * FROM [dbo].[Order]", OrderReader);
            return Orders;
        }
        
        public static void InsUpOrder(Order Orders)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].[Order] WHERE Id={0})
                INSERT INTO [dbo].[Order] ([Name],[PhoneNuber],[DeliveryName],[PaymentString],[CostOrder]) 
                VALUES ('{1}','{2}','{3}','{4}',{5})
                  ELSE
                UPDATE [dbo].[Order]  SET  Name='{1}',PhoneNuber='{2}',DeliveryName='{3}',PaymentString='{4}',CostOrder={5}  WHERE Id={0}";


            SqlService.SqlNon(String.Format(query, Orders.Id, Orders.Name, Orders.PhoneNuber, Orders.DeliveryName, Orders.PaymentString, Orders.CostOrder));
        }

        private static Order OrderReader(SqlDataReader reader)
        {

            return new Order()
            {
                Id = SqlHelper.GetInt(reader, "Id"),
                Name = SqlHelper.GetString(reader, "Name"),
                PhoneNuber = SqlHelper.GetString(reader, "PhoneNuber"),
                DeliveryName = SqlHelper.GetString(reader, "DeliveryName"),
                PaymentString = SqlHelper.GetString(reader, "PaymentString"),
                CostOrder = SqlHelper.GetInt(reader, "CostOrder")
            };
        }
    }
}