using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
            connection.IntegratedSecurity = true;
            connection.InitialCatalog = "";
            connection.DataSource = "VALERA-LAPTOP\\SQL2012";
            connection.InitialCatalog = "msdb";
            Int64 time;
            Int64 sum = 0;
            Int32 count = 20;
            for(int i=0; i< count; i++)
            {
                DataBase db = new DataBase(connection.ToString());
            
                Stopwatch t = new Stopwatch();
                t.Start();
                db.LoadObjects();
                time = t.ElapsedMilliseconds;
                Console.WriteLine($"time:{time}");
                t.Stop();
                sum += time;
            }
            Console.WriteLine($"AVG:{sum/count}");
            Console.ReadKey();
        }
    }
}
