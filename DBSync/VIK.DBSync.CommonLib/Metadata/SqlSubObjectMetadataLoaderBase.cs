using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.Metadata
{
    public abstract class SqlSubObjectMetadataLoaderBase<T> : IMetaDataLoader<T> where T : ISqlSubObject
    {
        protected String _scriptName;
        protected SqlObject _parentObject;

        public SqlSubObjectMetadataLoaderBase(String scriptName, SqlObject parentObject)
        {
            _scriptName = scriptName;
            _parentObject = parentObject;
        }

        abstract protected T GetObject(IDataRecord reader);

        public List<T> LoadObjects(IDbConnection connection)
        {
            IDataReader reader = null;
            try
            {
                List<T> list = new List<T>();
                IDbCommand command = connection.CreateCommand();
                command.CommandText = String.Format(ResourcesHelper.GetScriptFromResources(this._scriptName),_parentObject.ObjectId);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    T sqlSubObject = GetObject(reader);
                    sqlSubObject.ParentObject = _parentObject;
                    list.Add(sqlSubObject);
                }

                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Loading is failed. Type: " + typeof(T).Name, ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
        }

    }
}
