﻿using System;
using System.Data.SqlClient;
using System.Linq;
using VIK.DBSync.CommonLib.Metadata;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB
{
    public class DataBase
    {
        private SqlConnection _connection;
        private String _connectionString;

        public DataBaseObjects Objects { get; set; }
        public string Name { get; set; }

        public String ConnectionString { get { return _connectionString; } }

        public event Action<String> OnPogressUpdate;

        public DataBase(SqlConnection connection)
        {
            _connection = connection;
            _connectionString = connection.ConnectionString;
            Name = connection.Database;
            Objects = new DataBaseObjects();
        }

        public DataBase(String connectionString)
            : this(new SqlConnection(connectionString))
        {
           
        }               

        public void LoadObjects()
        {
            OnPogressUpdate?.Invoke("Tables are Loaded...");
            var columns = LoadSubObjects(new TableColumnsLoader());
            var checkConstraints = LoadSubObjects(new CheckConstraintsLoader());
            var defaultConstraints = LoadSubObjects(new DefaultConstraintsLoader());
            var fKeys = LoadSubObjects(new ForeignKeysLoader());
            var indexes = LoadSubObjects(new TableIndexesLoader());
            var indexColumns = LoadSubObjects(new IndexColumnLoader());
            var foreignKeyColumns = LoadSubObjects(new ForeignKeyColumnLoader());

            var tables = (new TablesLoader(this)).LoadObjects(_connection);

            SubObjectsFiller.FillObjects(tables, columns, t => t.Columns);
            SubObjectsFiller.FillObjects(tables, checkConstraints, t => t.CheckConstraints);
            SubObjectsFiller.FillObjects(tables, defaultConstraints, t => t.DefaultConstraints);           

            Int32 parentId = -1;
            SqlTable parent = null;
            foreach (SqlIndex index in indexes)
            {
                if (index.ParentObjectId != parentId)
                {
                    parentId = index.ParentObjectId;
                    parent = tables.FirstOrDefault(o => o.ObjectId == parentId);                  
                }

                index.ParentObject = parent;
                if (parent == null) continue;
               
                index.Columns = indexColumns.Where(c => c.IndexId == index.IndexId && c.ParentObjectId==index.ParentObjectId).ToList();
                
                if(index.UsingXMLIndexId!=0) index.UsingXMLIndex = indexes.FirstOrDefault(i => i.IndexId == index.UsingXMLIndexId && i.ParentObjectId == index.ParentObjectId);
               
                foreach (IndexColumn iColumn in index.Columns)
                {
                    iColumn.Column = parent.Columns.First(c => c.ColumnId == iColumn.ColumnId);
                }

                if (index.IsPrimaryKey)
                {
                    parent.PrimarKey = index;
                }
                else if (index.IsUniqueConstraint)
                {
                    parent.UniqueConstraints.Add(index);
                }
                else
                {
                    parent.Indexes.Add(index);
                }
            }

            parentId = -1;
            foreach (SqlForeignKey key in fKeys)
            {
                if (key.ParentObjectId != parentId)
                {
                    parentId = key.ParentObjectId;
                    parent = tables.FirstOrDefault(o => o.ObjectId == parentId);
                }
                key.ParentObject = parent;
                if (parent == null) continue;
                key.ReferencedTable = tables.FirstOrDefault(t => t.ObjectId == key.ReferencedTableId);
                key.ReferencedTable.Dependencies.Add(key);               
                key.Columns = foreignKeyColumns.Where(c => c.ForeignKeyId == key.ForeignKeyId).ToList();
                parent.ForeignKeys.Add(key);
            }
            
            OnPogressUpdate?.Invoke("Types are Loaded...");
            Objects.Types = new TypesLoader(this).LoadObjects(_connection);

            foreach (SqlColumn column in columns.Where(c=>c.IsUserDefinedType))
            {               
                SqlType type = Objects.Types.FirstOrDefault(t=>t.ObjectId==column.UserTypeId);
                column.ColumnType = type;
                type.Columns.Add(column);
            }

            Objects.Tables = tables;            

            OnPogressUpdate?.Invoke("Procedures are Loaded...");
            Objects.Procedures = new StoredProceduresLoader(this).LoadObjects(_connection);            

            OnPogressUpdate?.Invoke("Schemas are Loaded...");
            Objects.Schemas = new SchemaLoader(this).LoadObjects(_connection);

            OnPogressUpdate?.Invoke("Xml Schemas are Loaded...");
            Objects.XmlSchemas = new XmlSchemasLoader(this).LoadObjects(_connection);

          
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }           
        }

        private SubObjectsCollection<T> LoadSubObjects<T>(SqlSubObjectMetadataLoaderBase<T> loader) where T:SqlSubObject
        {
            return loader.LoadObjects(_connection);
        }
     
    }
}
