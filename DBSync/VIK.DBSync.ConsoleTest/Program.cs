using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
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
            String dbName = "sample2"; // database name

            // Connect to the local, default instance of SQL Server. 
            Server srv = new Server();

            // Reference the database.  
            Database db = srv.Databases[dbName];

            // Define a Scripter object and set the required scripting options. 
            Scripter scrp = new Scripter(srv);
            
            scrp.Options.ScriptDrops = false;
            scrp.Options.WithDependencies = true;
            scrp.Options.Indexes = true;   // To include indexes
            scrp.Options.DriAllConstraints = true;   // to include referential constraints in the script

            // Iterate through the tables in database and script each one. Display the script.   
            foreach (Table tb in db.Tables)
            {
                // check if the table is not a system table
                if (tb.IsSystemObject == false)
                {
                    Console.WriteLine("-- Scripting for table " + tb.Name);

                    // Generating script for table tb
                    System.Collections.Specialized.StringCollection sc = scrp.Script(new Urn[] { tb.Urn });
                    foreach (string st in sc)
                    {
                        Console.WriteLine(st);
                    }
                    Console.WriteLine("--");
                }
            }
            Console.ReadKey();
        }
    }
}
