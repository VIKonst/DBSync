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

            IndexColumnLoader indexColumnsLoader = new IndexColumnLoader(table);
            List<IndexColumn> indexColumns = indexColumnsLoader.LoadObjects(connection);


            List<SqlIndex> indexes = indexesLoader.LoadObjects(connection);
            foreach(SqlIndex index in indexes)
            {
                index.Columns = indexColumns.Where(c => c.IndexId == index.IndexId).ToList();
                foreach (IndexColumn iColumn in index.Columns)
                {
                    iColumn.Column = table.Columns.First(c => c.ColumnId == iColumn.ColumnId);
                }
                  
                
                if(index.IsPrimaryKey)
                {
                    table.PrimarKey = index;
                }
                else if (index.IsUniqueConstraint)
                {
                    table.UniqueConstraints.Add(index);
                }
                else
                {
                    table.Indexes.Add(index);
                }
              
            }
          //  table.PrimarKey = indexes.FirstOrDefault(i => i.IsPrimaryKey);
          //  table.UniqueConstraints = indexes.Where(i => i.IsUniqueConstraint).ToList();
           // table.Indexes = indexes.Where(i => !i.IsUniqueConstraint && !i.IsPrimaryKey).ToList();
        }
    }
}
