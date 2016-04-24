using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class TablesLoader : SqlObjectMetadataLoaderBase<SqlTable>
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


        public override void LoadSubObjects(SqlTable table, IDbConnection connection)
        {
            TableColumnsLoader columnsLoader = new TableColumnsLoader(table);

            table.Columns = columnsLoader.LoadObjects(connection);

            TableIndexesLoader indexesLoader = new TableIndexesLoader(table);
            List<SqlIndex> indexes = indexesLoader.LoadObjects(connection);
            table.PrimarKey = indexes.FirstOrDefault(i => i.IsPrimaryKey);
            table.UniqueConstraints = indexes.Where(i => i.IsUniqueConstraint).ToList();

        }
    }
}
