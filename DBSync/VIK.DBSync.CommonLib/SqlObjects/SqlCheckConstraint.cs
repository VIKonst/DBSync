using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlCheckConstraint : SqlSubObject
    {
        public Int32 ParentColumnId { get; set; }
    //    public String ParentColumnName { get; set; }
        public String Defenition { get; set; }
        
        public override String CreateScript()
        {            
            String notFoReplicaton = this.IsNotForReplication ? "NOT FOR REPLICATION" : String.Empty;
            return $"ALTER TABLE {this.ParentObject.QualifiedName} ADD CONSTRAINT [{Name}]" + Environment.NewLine +
                   $"CHECK {notFoReplicaton} {Defenition}{SqlStatement.GO}";
                                   
        }

        public override String DropScript()
        {
            return $"ALTER TABLE {this.ParentObject.QualifiedName} DROP CONSTRAINT  {Name}{SqlStatement.GO}";
        }
    }
}
