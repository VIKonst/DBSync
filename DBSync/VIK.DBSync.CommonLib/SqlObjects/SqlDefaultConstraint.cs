using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlDefaultConstraint : SqlSubObject
    {
        public String ColumnName { get; set; }

        public String Definition { get; set; }

        public override String CreateScript()
        {
            return $"ADD CONSTRAINT {Name} {Environment.NewLine}\tDEFAULT {Definition} FOR [{ColumnName}]";
        }
    }
}
