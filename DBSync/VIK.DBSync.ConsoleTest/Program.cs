using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.DB;

namespace VIK.DBSync.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "VALERA-LAPTOP";
            builder.Add("Integrated Security", true);
            builder.InitialCatalog = "sample";
            SqlConnection connection = new SqlConnection(builder.ToString());

            DataBase db = new DataBase(connection);
            db.LoadTables();
            db.LoadProcedures();

            foreach(var obj in db.Objects.Procedures)
            {
                Console.WriteLine(obj.CreateScript());
            }
            Console.ReadKey();
        }
    }
}
