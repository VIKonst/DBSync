using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class ForeignKeysLoader : SqlSubObjectMetadataLoaderBase<SqlForeignKey>
    {
        public ForeignKeysLoader(SqlTable parentObject) 
            : base("VIK.DBSync.CommonLib.Scripts.ForeignKeys.sql", parentObject)
        {
        }

        protected override SqlForeignKey GetObject(IDataRecord reader)
        {
            SqlForeignKey key = new SqlForeignKey();
            key.Name = (String)reader["foreign_key_name"];
            return key;
        }
    }
}
