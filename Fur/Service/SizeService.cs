using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class SizeService
    {

        public static IEnumerable<Size> GetSize()
        {
            var Size = SqlService.GetSqlList("SELECT * FROM [dbo].[Size]", SizeReader);
            return Size;
        }
        public static Size GetSizeById(int Id)
        {
            var Size = SqlService.GetSqlOne(String.Format("SELECT * FROM [dbo].[Size] Where Id={0} ", Id), SizeReader);
            return Size;
        }
        public static void InsUpSize(Size Size)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].Size WHERE Id={0})
                INSERT INTO [dbo].Size ([Name]) 
                VALUES ('{1}')
                  ELSE
                UPDATE [dbo].Size  SET  Name='{1}' WHERE Id={0}";


            SqlService.SqlNon(String.Format(query, Size.Id, Size.Name));
        }

        public static void DelSize(Size Size)
        {
            var query = @"DELETE FROM [dbo].[Size] WHERE Id={0}";

            SqlService.SqlNon(String.Format(query, Size.Id));
        }




        private static Size SizeReader(SqlDataReader reader)
        {

            return new Size()
            {
                Id = SqlHelper.GetInt(reader, "Id"),
                Name = SqlHelper.GetString(reader, "Name")

            };


        }
    }
}