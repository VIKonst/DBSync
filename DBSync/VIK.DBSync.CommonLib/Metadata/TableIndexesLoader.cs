using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class TableIndexesLoader : SqlSubObjectMetadataLoaderBase<SqlIndex>
    {
        public TableIndexesLoader(SqlTable table)
            : base("VIK.DBSync.CommonLib.Scripts.Indexes.sql",table)
        {

        }

        protected override SqlIndex GetObject(IDataRecord reader)
        {
            SqlIndex index = new SqlIndex();
            index.Name = (String)reader["index_name"];
            index.IndexId = (Int32)reader["index_id"];
            index.IsPrimaryKey = (Boolean)reader["is_primary_key"];
            index.IsUnique = (Boolean)reader["is_unique"];
            index.IsUniqueConstraint = (Boolean)reader["is_unique_constraint"];
            return index;
        }
    }
}
