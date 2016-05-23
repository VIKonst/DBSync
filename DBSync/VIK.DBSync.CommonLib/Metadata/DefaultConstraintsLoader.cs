using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class DefaultConstraintsLoader : SqlSubObjectMetadataLoaderBase<SqlDefaultConstraint>
    {
        public DefaultConstraintsLoader(SqlObject parentObject = null) 
            : base("VIK.DBSync.CommonLib.Scripts.DefaultConstraints.sql", parentObject)
        {
        }

        protected override SqlDefaultConstraint GetObject(IDataRecord reader)
        {
            SqlDefaultConstraint constraint = new SqlDefaultConstraint();
            constraint.Name = (String)reader["default_constraint_name"];
            constraint.ColumnName = (String)reader["column_name"];
            constraint.Definition = (String)reader["definition"];
            constraint.ParentObjectId = (Int32)reader["parent_table_id"];
            return constraint;
        }
    }
}
