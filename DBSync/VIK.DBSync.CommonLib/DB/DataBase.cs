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

        public String ConnectionString { get { return _connectionString; } }

        public event Action<String> OnPogressUpdate;

        public DataBase(SqlConnection connection)
        {
            _connection = connection;
            _connectionString = connection.ConnectionString;
            Name = connection.Database;
            Objects = new DataBaseObjects();

        }

        public DataBase(String connectionString)
            : this(new SqlConnection(connectionString))
        {
           
        }
               

        public void LoadObjects()
        {
            LoadSchemas();
            LoadTables();
            LoadProcedures();
            LoadXmlSchemas();
            if (_connection.State == System.Data.ConnectionState.Open)
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
                OnPogressUpdate?.Invoke(table.QualifiedName);
                loader.LoadSubObjects(table, _connection);
            }

        }

        private void LoadProcedures()
        {
            StoredProceduresLoader loader = new StoredProceduresLoader(this);

            OnPogressUpdate?.Invoke("Procedures are Loaded...");
            Objects.Procedures = loader.LoadObjects(_connection);
        }

        private void LoadSchemas()
        {
            SchemaLoader loader = new SchemaLoader(this);

            OnPogressUpdate?.Invoke(" Schemas are Loaded...");
            Objects.Schemas = loader.LoadObjects(_connection);
        }

        private void LoadXmlSchemas()
        {
            XmlSchemasLoader loader = new XmlSchemasLoader(this);

            OnPogressUpdate?.Invoke(" Xml Schemas are Loaded...");
            Objects.XmlSchemas = loader.LoadObjects(_connection);
        }
    }
}
