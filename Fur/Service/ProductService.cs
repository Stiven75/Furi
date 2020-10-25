using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Fur.Service
{
    public class ProductService
    {
        public static IEnumerable<Product> GetProducts()
        {
            var Products = SqlService.GetSqlList("SELECT * FROM [dbo].[Products]", ProductReader);
            return Products;
        }
        public static Product GetProductById(int Id)
        {
            var Product = SqlService.GetSqlOne(String.Format("SELECT * FROM [dbo].[Products] Where Id={0}", Id), ProductReader);
            return Product;
        }

        public static void InsUpProduct(Product product)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].Products WHERE Id={0})
                INSERT INTO [dbo].Products ([Name],[ArtNo],[Enabled],[CategoryId],[Photo]) 
                VALUES ('{1}','{2}',{3},{4},'{5}')
                  ELSE
                UPDATE [dbo].Products  SET  Name='{1}',ArtNo='{2}',
                  Enabled={3},CategoryId={4},Photo='{5}' WHERE Id={0}";


            SqlService.SqlNon(String.Format(query,product.Id,product.Name, product.ArtNo, Convert.ToInt32(product.Enabled), product.CategoryId, product.Photo));
        }


        public static void DelProduct(Product Product)
        {
            var query = @"DELETE FROM [dbo].[Products] WHERE Id={0}";

            SqlService.SqlNon(String.Format(query, Product.Id));
        }



        private static Product ProductReader(SqlDataReader reader)
        {

            return new Product()
            {
                Id = SqlHelper.GetInt(reader,"Id"),
                Name = SqlHelper.GetString(reader, "Name"),
                ArtNo = SqlHelper.GetString(reader, "ArtNo"),
                Enabled = SqlHelper.GetBolean(reader, "Enabled"),
                CategoryId = SqlHelper.GetInt(reader, "CategoryId"),
                Photo = SqlHelper.GetString(reader, "Photo"),

            };

          
        }        
    }
}