using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class IndexColumnLoader : SqlSubObjectMetadataLoaderBase<IndexColumn>
    {

        public IndexColumnLoader(SqlTable table)
            :base("VIK.DBSync.CommonLib.Scripts.IndexColumns.sql", table)
        {            
        }

        protected override IndexColumn GetObject(IDataRecord reader)
        {
            IndexColumn column = new IndexColumn();
            column.ObjectId = (Int32)reader["object_id"];
            column.ColumnId = (Int32)reader["column_id"];
            column.IndexId = (Int32)reader["index_id"];
            column.IndexColumnId = (Int32)reader["index_column_id"];
            column.IsDesc = (Boolean)reader["is_descending_key"];
            column.IsIncluded = (Boolean)reader["is_included"];
            return column;
        }
    }
}
