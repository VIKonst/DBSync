using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.DB
{
    public class DBHelper
    {
        private const String GET_DATABASES_SCRIPT = "Select name from sys.databases order by name";
        public static List<String> GetDBsNames(String connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = GET_DATABASES_SCRIPT;
            SqlDataReader reader =  command.ExecuteReader();
            List<String> result = new List<String>();
            while ( reader.Read())
            {
                result.Add(reader.GetString(0));
            }
            reader.Close();
            connection.Close();
            return result;

        }

        public static async Task<List<String>> GetDBsNamesAsync(String connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command=  connection.CreateCommand();
            await connection.OpenAsync();
            command.CommandText = GET_DATABASES_SCRIPT;
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<String> result = new List<String>();
            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
            reader.Close();
            connection.Close();
            return result;
        }

        public static void TestConnection(String connectionString)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            connection.Close();
        }
    }
}
