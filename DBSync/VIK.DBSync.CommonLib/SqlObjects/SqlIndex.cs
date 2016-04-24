using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlIndex : ISqlSubObject
    {
        public Int32 IndexId { get; set; }

        public String Name { get; set; }

        public String TypeStatement { get; set; }

        public Boolean IsUnique { get; set; }

        public Boolean IsPrimaryKey { get; set; }

        public Boolean IsUniqueConstraint { get; set; }

        public List<SqlColumn> Columns { get; set; }

        public ISqlObject ParentObject { get; set; }

        public String CreateScript()
        {
            StringBuilder builder = new StringBuilder("ADD CONSTRAINT ");
            builder.Append(Name);
            builder.Append(" ");
            if(IsPrimaryKey)
            {
                builder.Append("PRIMARY KEY ");
            } 
            else if(IsUniqueConstraint)
            {
                builder.Append("UNIQUE ");
            }
            builder.Append(" (columns)");
            return builder.ToString();
        }
    }
}
