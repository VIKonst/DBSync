using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.Metadata;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.DB
{
    public class DataBase
    {
        SqlConnection _connection;

        public DataBaseObjects Objects { get; set; }
        public string Name { get; set; }


        public DataBase(SqlConnection connection)
        {
            _connection = connection;
            Name = connection.Database;
            Objects = new DataBaseObjects();

        }

        public DataBase(String connectionString)
            : this(new SqlConnection(connectionString))
        {
            
        }


        public void LoadTables()
        {
            TablesLoader loader = new TablesLoader();
            Objects.Tables = loader.LoadObjects(_connection);
            foreach(var table in Objects.Tables )
            {
                loader.LoadSubObjects(table,_connection);
            }
        }

        public void LoadProcedures()
        {
            StoredProceduresLoader loader = new StoredProceduresLoader();
            Objects.Procedures = loader.LoadObjects(_connection);
        }

        public void LoadObjects()
        {
            LoadTables();
            LoadProcedures();
        }
    }
}
