using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class TablesLoader : MetadataLoaderBase<SqlTable>
    {
        public TablesLoader()
            : base("VIK.DBSync.CommonLib.Scripts.Tables.sql")
        {            
        }

        protected override SqlTable GetObject(IDataRecord reader)
        {
            SqlTable table = new SqlTable();
          
            table.Name = reader.GetString(0);
            table.SchemaId = reader.GetInt32(1);
            table.SchemaName = reader.GetString(2);
            table.ObjectId = reader.GetInt32(3);
            table.IsAnsiNullsOn = reader.GetBoolean(4);
            return table;
        }
    }
}
