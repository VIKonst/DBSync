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
        public ForeignKeysLoader(SqlTable parentObject=null) 
            : base("VIK.DBSync.CommonLib.Scripts.ForeignKeys.sql", parentObject)
        {
        }

        protected override SqlForeignKey GetObject(IDataRecord reader)
        {
            SqlForeignKey key = new SqlForeignKey();
            key.Name = (String)reader["foreign_key_name"];
            key.UpdateAction = (ReferentialAction)(Byte)reader["update_referential_action"];
            key.DeleteAction = (ReferentialAction)(Byte)reader["delete_referential_action"];
            key.ParentObjectId = (Int32)reader["referencing_table_id"];
            key.ReferencedTableId = (Int32)reader["referenced_table_id"];
            key.ForeignKeyId = (Int32)reader["foreign_key_id"];
            key.IsDisabled = (Boolean)reader["is_disabled"];
            return key;
        }
    }
}
