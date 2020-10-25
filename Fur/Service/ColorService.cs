using Fur.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class ColorService
    {
        public static IEnumerable<Color> GetColors()
        {
            var Colors = SqlService.GetSqlList("SELECT * FROM [dbo].[Color]", ColorReader);
            return Colors;
        }
        public static Color GetColorById(int Id)
        {
            var Colors = SqlService.GetSqlOne(String.Format("SELECT * FROM [dbo].[Color] Where Id={0} ", Id), ColorReader);
            return Colors;
        }

        public static void InsUpColor(Color Color)
        {
            var query = @"IF NOT EXISTS(SELECT * FROM [dbo].[Color] WHERE Id={0})
                INSERT INTO [dbo].[Color] ([Name],[ColorCode]) 
                VALUES ('{1}','{2}')
                  ELSE
                UPDATE [dbo].[Color]  SET  Name='{1}',ColorCode='{2}'  WHERE Id={0}";


            SqlService.SqlNon(String.Format(query, Color.Id, Color.Name, Color.ColorCode));
        }


        public static void DelColor(Color Color)
        {
            var query = @"DELETE FROM [dbo].[Color] WHERE Id={0}";

            SqlService.SqlNon(String.Format(query, Color.Id));
        }



        private static Color ColorReader(SqlDataReader reader)
        {

            return new Color()
            {
                Id = SqlHelper.GetInt(reader, "Id"),
                Name = SqlHelper.GetString(reader, "Name"),
                ColorCode = SqlHelper.GetString(reader, "ColorCode"),

            };


        }

    }
}