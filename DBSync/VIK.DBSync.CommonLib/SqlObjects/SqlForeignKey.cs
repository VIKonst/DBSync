using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlForeignKey : ISqlSubObject
    {
        public ISqlObject ParentObject { get; set; }

        public String Name { get; set; }

        public Int32 ForeignKeyId { get; set; }
        public Int32 ParentTableId { get; set; }

        public Int32 ReferencedTableId { get; set; }

        public Int16 DeleteAction { get; set; }

        public Int16 UpdateAction { get; set; }


    }
}
