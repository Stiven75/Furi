using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class SqlHelper
    {

        public static string GetString(IDataReader reader, string Column)
        {
            int index = reader.GetOrdinal(Column);
            if (reader.IsDBNull(index))
            {
                return " ";
            }
            return Convert.ToString(reader.GetValue(index));
        }

        public static int GetInt(IDataReader reader, string Column)
        {
            int index = reader.GetOrdinal(Column);
            if (reader.IsDBNull(index))
            {
                return 0;
            }
            return Convert.ToInt32(reader.GetValue(index));
        }

        public static bool GetBolean(IDataReader reader, string Column)
        {

            int index = reader.GetOrdinal(Column);
            if (reader.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(reader.GetValue(index));

        }

    }
}