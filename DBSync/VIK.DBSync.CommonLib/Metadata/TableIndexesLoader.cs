using System;
using System.Data;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class TableIndexesLoader : SqlSubObjectMetadataLoaderBase<SqlIndex>
    {
        public TableIndexesLoader(SqlTable table = null)
            : base("VIK.DBSync.CommonLib.Scripts.Indexes.sql",table)
        {

        }

        protected override SqlIndex GetObject(IDataRecord reader)
        {
            SqlIndex index = new SqlIndex();
            index.ParentObjectId = (Int32)reader["parent_table_id"];
            index.Name = (String)reader["index_name"];
            index.IndexId = (Int32)reader["index_id"];
            index.IsPrimaryKey = (Boolean)reader["is_primary_key"];
            index.IsUnique = (Boolean)reader["is_unique"];
            index.IsUniqueConstraint = (Boolean)reader["is_unique_constraint"];
            index.TypeStatement = (String)reader["type_desc"];
            index.IsPadded = (Boolean)reader["is_padded"];
            index.IgnoreDupKey = (Boolean)reader["ignore_dup_key"];
            index.IsAutoStatistics = (Boolean)reader["no_recompute"];
            index.AllowPageLocks = (Boolean)reader["allow_row_locks"];
            index.AllowRowLocks = (Boolean)reader["allow_page_locks"];
            index.FileGroup = (String)reader["data_space_name"];
            index.UsingXMLIndexId = (Int32)reader["using_xml_index_id"];
            index.XMLSecondaryType = (String)reader["xml_secondary_type"];
            index.FillFactor = (Byte)reader["fill_factor"];
            return index;
        }
    }
}
