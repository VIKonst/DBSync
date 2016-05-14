using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.Metadata;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.DB
{
    public class DataBase
    {
        private SqlConnection _connection;
        private String _connectionString;

        public DataBaseObjects Objects { get; set; }
        public string Name { get; set; }

        public event Action<String> OnPogressUpdate;

        public DataBase(SqlConnection connection)
        {
            _connection = connection;
            Name = connection.Database;
            Objects = new DataBaseObjects();

        }

        public DataBase(String connectionString)
            : this(new SqlConnection(connectionString))
        {
            _connectionString = connectionString;
        }
               

        public void LoadObjects()
        {
            LoadTables();
            LoadProcedures();
            if(_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }


        private void LoadTables()
        {
            TablesLoader loader = new TablesLoader(this);

            Objects.Tables = loader.LoadObjects(_connection);

            foreach (var table in Objects.Tables)
            {
                OnPogressUpdate?.Invoke(Name+": "+table.QualifiedName + " is Loaded...");
                loader.LoadSubObjects(table, _connection);
            }

        }

        private void LoadProcedures()
        {
            StoredProceduresLoader loader = new StoredProceduresLoader(this);

            OnPogressUpdate?.Invoke(Name + ": Procedures are Loaded...");
            Objects.Procedures = loader.LoadObjects(_connection);
        }
    }
}
