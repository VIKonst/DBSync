using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.DB;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class TablesLoader : SqlObjectMetadataLoaderBase<SqlTable>
    {
        public TablesLoader(DataBase db)
            : base("VIK.DBSync.CommonLib.Scripts.Tables.sql", db)
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
            table.IsReplicated = reader.GetBoolean(5);
            table.LockEscalation = reader.GetString(6);
            table.DataSpaceName = reader.GetString(7);
            return table;
        }
        
        public override void LoadSubObjects(SqlTable table, IDbConnection connection)
        {            
            table.Columns = (new TableColumnsLoader(table)).LoadObjects(connection);
            table.CheckConstraints = (new CheckConstraintsLoader(table)).LoadObjects(connection);
            table.DefaultConstraints = (new DefaultConstraintsLoader(table)).LoadObjects(connection);
                
            List<IndexColumn> indexColumns = (new IndexColumnLoader(table)).LoadObjects(connection);
            List<SqlIndex> allIndexes = (new TableIndexesLoader(table)).LoadObjects(connection);

            foreach(SqlIndex index in allIndexes)
            {
                index.Columns = indexColumns.Where(c => c.IndexId == index.IndexId).ToList();
                index.UsingXMLIndex = allIndexes.FirstOrDefault(i=>i.IndexId==index.UsingXMLIndexId);
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
            //  table.PrimarKey = allIndexes.FirstOrDefault(i => i.IsPrimaryKey);
            //  table.UniqueConstraints = allIndexes.Where(i => i.IsUniqueConstraint).ToList();
            // table.Indexes = allIndexes.Where(i => !i.IsUniqueConstraint && !i.IsPrimaryKey).ToList();

            table.ForeignKeys = (new ForeignKeysLoader(table) ).LoadObjects(connection);
            List<ForeignKeyColumn> foreignKeyColumns = ( new ForeignKeyColumnLoader(table) ).LoadObjects(connection);
            
            
            foreach (SqlForeignKey key in table.ForeignKeys)
            {
                key.ReferencedTable = table.ParentDb.Objects.Tables.FirstOrDefault(t => t.ObjectId == key.ReferencedTableId);
                key.ReferencedTable.Dependencies.Add(key);
                key.Columns = foreignKeyColumns.Where(c=>c.ForeignKeyId==key.ForeignKeyId).ToList();
            }
           
        }
    }
}
