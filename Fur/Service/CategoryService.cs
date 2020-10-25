using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class CategoryService
    {
        public static IEnumerable<Category> GetCategory()
        {
            var Colors = SqlService.GetSqlList("SELECT * FROM [dbo].[Category]", CategoryReader);
            return Colors;
        }


        public static Category GetCategoryById(int Id)
        {
            var Colors = SqlService.GetSqlOne(String.Format("SELECT * FROM [dbo].[Category] Where Id={0} ", Id), CategoryReader);
            return Colors;
        }

        public static void InsUpCategory(Category category)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].[Category] WHERE Id={0})
                INSERT INTO [dbo].[Category] ([Name]) 
                VALUES ('{1}')
                  ELSE
                UPDATE [dbo].[Category]  SET  Name='{1}'  WHERE Id={0}";


            SqlService.SqlNon(String.Format(query, category.Id, category.Name));
        }


        public static void DelCategory(Category category)
        {
            var query = @"DELETE FROM [dbo].[Category] WHERE Id={0}";

            SqlService.SqlNon(String.Format(query, category.Id));
        }



        private static Category CategoryReader(SqlDataReader reader)
        {

            return new Category()
            {
                Id = SqlHelper.GetInt(reader, "Id"),
                Name = SqlHelper.GetString(reader, "Name")

            };


        }
    }
}