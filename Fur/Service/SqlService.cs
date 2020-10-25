using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fur.Service
{
    public class SqlService
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\Lection.mdf';Integrated Security=True";

        public static TResult GetSqlOne<TResult>(string sqlExpression, Func<SqlDataReader, TResult> function)
        {

            // sqlExpression = "SELECT * FROM Colors";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
               // SqlDataReader reader = command.ExecuteReader();
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? function(reader) : default(TResult);
                }
            }
        }

        public static IEnumerable<TResult> GetSqlList<TResult>(string sqlExpression, Func<SqlDataReader, TResult> function)
        {

            // sqlExpression = "SELECT * FROM Colors";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // SqlDataReader reader = command.ExecuteReader();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return function != null ? function(reader) : default(TResult);
                    }
                }
            }
        }


        public static void SqlNon(string sqlExpression)
        {

            // sqlExpression = "SELECT * FROM Colors";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // SqlDataReader reader = command.ExecuteReader();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

    }
}