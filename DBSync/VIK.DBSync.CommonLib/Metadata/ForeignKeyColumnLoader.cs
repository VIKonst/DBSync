using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class ForeignKeyColumnLoader : SqlSubObjectMetadataLoaderBase<ForeignKeyColumn>
    {
        public ForeignKeyColumnLoader(SqlTable table)
            : base("VIK.DBSync.CommonLib.Scripts.ForeignKeyColumns.sql", table)
        {            
        }
        
        protected override ForeignKeyColumn GetObject(IDataRecord reader)
        {
            ForeignKeyColumn column = new ForeignKeyColumn();
            column.Name = String.Empty;
            column.ForeignKeyId = (Int32)reader["foreign_key_id"];
            column.ForeignKeyColumnId = (Int32)reader["foreign_key_column_id"];
            column.ParentColumnName = (String)reader["parent_column_name"];
            column.ReferencedColumnName = (String)reader["referenced_column_name"];
            column.ReferencedObjectId = (Int32)reader["referenced_object_id"];
            return column;
        }        
    }
}
