using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.Metadata
{
    public abstract class MetadataLoaderBase<T> : IMetaDataLoader<T> where T : ISqlObject
    {
        protected String _scriptName;

        public MetadataLoaderBase(String scriptName)
        {
            _scriptName = scriptName;
        }

        abstract protected T GetObject(IDataRecord reader);

        public List<T> LoadObjects(IDbConnection connection)
        {
            IDataReader reader = null;
            try
            {
                List<T> list = new List<T>();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = ResourcesHelper.GetScriptFromResources(this._scriptName);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    T sqlObject = GetObject(reader);
                    list.Add(sqlObject);
                }

                reader.Close();
                return list;
            }
            catch(Exception ex)
            {
                throw new Exception("Loading is failed. Type: " + typeof(T).Name, ex);
            }
            finally
            {
                if(reader!=null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }            
        }



    }
}
