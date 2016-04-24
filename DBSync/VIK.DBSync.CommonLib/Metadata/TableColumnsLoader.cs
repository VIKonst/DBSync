using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class TableColumnsLoader : SqlSubObjectMetadataLoaderBase<SqlColumn>
    {
        public TableColumnsLoader(SqlTable table)
            :base("VIK.DBSync.CommonLib.Scripts.TableColumns.sql", table)
        {

        }

        protected override SqlColumn GetObject(IDataRecord reader)
        {
            SqlColumn column = new SqlColumn();
            
            column.ColumnId = reader.GetInt32(1);
            column.Name = reader.GetString(2);
            column.UserTypeId = reader.GetInt32(3);
            column.UserType = reader.GetString(4);
            column.SytemTypeId = reader.GetByte(5);
            column.SytemType = reader.GetString(6);
            column.ColationName = reader.GetString(7);
            column.Precision = reader.GetByte(8);
            column.Scale = reader.GetByte(9);
            column.IsNulable = (Boolean)reader["is_nullable"];
            column.IsIdentity = (Boolean)reader["is_identity"];
            column.IdentitySeed = reader["identity_seed"];
            column.IdentityIncrement = reader["identity_increment"];
            column.IsPersisted = (Boolean)reader["is_persisted"];
            column.MaxLength = (Int16)reader["max_length"];
            column.IsComputed = (Boolean)reader["is_computed"];
            column.ComputedDefinition = (String)reader["computed_definition"];
           
            return column;
        }
    }
}
