using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class CheckConstraintsLoader : SqlSubObjectMetadataLoaderBase<SqlCheckConstraint>
    {
        public CheckConstraintsLoader(SqlObject parentObject)
           : base("VIK.DBSync.CommonLib.Scripts.CheckConstraints.sql", parentObject)
        {
        }

        protected override SqlCheckConstraint GetObject(IDataRecord reader)
        {
            SqlCheckConstraint constraint = new SqlCheckConstraint();
            constraint.Defenition = (String)reader["definition"];
            constraint.IsNotForReplication = (Boolean)reader["is_not_for_replication"];
            constraint.Name = (String)reader["check_constraint_name"];
            return constraint;
        }
    }
}
