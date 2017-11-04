using System;
using System.Data;
using VIK.DBSync.CommonLib.DB;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class TypesLoader : SqlObjectMetadataLoaderBase<SqlType>
    {
        public TypesLoader(DataBase db)
            : base("VIK.DBSync.CommonLib.Scripts.Types.sql", db)
        {            
        }

        protected override SqlType GetObject(IDataRecord reader)
        {
            SqlType type = new SqlType();          
            type.Name = (String)reader["name_of_type"];
            type.SchemaId = (Int32)reader["schema_id"];
            type.SchemaName = (String)reader["schema_name"];
            type.ObjectId = (Int32)reader["type_id"];
            type.ColationName = (String)reader["collation_name"];
            type.Precision = (Byte)reader["type_precision"];
            type.Scale = (Byte)reader["type_scale"];
            type.IsNulable = (Boolean)reader["is_nullable"];
            type.SystemTypeName = (String)reader["native_type_name"];
            type.MaxLength = (Int16)reader["max_length"];
            return type;
        }        
     
    }
}
