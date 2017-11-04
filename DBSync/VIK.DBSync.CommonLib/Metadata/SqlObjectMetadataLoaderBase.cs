using System;
using System.Collections.Generic;
using System.Data;
using VIK.DBSync.CommonLib.DB;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.Metadata
{
    public abstract class SqlObjectMetadataLoaderBase<T> : IMetaDataLoader<T, List<T>> where T :ISqlObject 
    {
        protected String _scriptName;
        private DataBase _db;

        public SqlObjectMetadataLoaderBase(String scriptName, DataBase parentDb)
        {
            _scriptName = scriptName;
            _db = parentDb;
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
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T sqlObject = GetObject(reader);
                        sqlObject.ParentDb = _db;
                        list.Add(sqlObject);
                    }
                }
                
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
