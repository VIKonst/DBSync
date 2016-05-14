using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class ForeignKeyColumn : SqlSubObject
    {
        public Int32 ParentColumnId { get; set; }

        public Int32 ReferencedColumnId { get; set; }

        public Int32 ForeignKeyColumnId { get; set; }

        public SqlTable ReferencedTable { get; set; }

        public Int32 ReferencedObjectId { get; set; }
        
        //  SqlColumn ParentColumn { get; set; }
        public String ParentColumnName { get; set; }
        public String ReferencedColumnName { get; set; }


        // SqlColumn ReferencedColumn { get; set; }
        public Int32 ForeignKeyId { get; set; }
        public SqlForeignKey ForeignKey { get; set; }

        public override String CreateScript()
        {
            throw new NotImplementedException();
        }
    }
}
