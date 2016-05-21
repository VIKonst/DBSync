using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.Metadata;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlForeignKey : SqlSubObject
    {
        public override String Name { get; set; }

        public Int32 ForeignKeyId { get; set; }
        public Int32 ParentTableId { get; set; }

        public Int32 ReferencedTableId { get; set; }

        public SqlTable ReferencedTable { get; set; }

        public ReferentialAction DeleteAction { get; set; }

        public ReferentialAction UpdateAction { get; set; }

        public List<ForeignKeyColumn> Columns { get; set; }

        private String ActionToString(ReferentialAction action)
        {
            switch (action)
            {
                case ReferentialAction.Cascade:
                    return "CASCADE";
                case ReferentialAction.NoAction:
                    return "NO ACTION";
                case ReferentialAction.SetDefault:
                    return "SET DEFAULT";
                case ReferentialAction.SetNull:
                    return "SET NULL";
                default:
                    throw new ArgumentException("wrong action");
            }
        }

        public override String CreateScript()
        {
            StringBuilder builder = new StringBuilder(String.Empty);
            builder.AppendLine($"ALTER TABLE { this.ParentObject.QualifiedName}");
            builder.AppendLine($"ADD CONSTRAINT [{Name}] FOREIGN KEY");
            builder.AppendLine("(");
            builder.AppendLine(String.Join(",", Columns.Select(c => $"[{c.ParentColumnName}]")));
            builder.AppendLine(")");
            builder.Append("REFERENCES ");
            builder.Append(ReferencedTable.QualifiedName);
            builder.AppendLine("(");
            builder.AppendLine(String.Join(",", Columns.Select(c => $"[{c.ReferencedColumnName}]")));
            builder.AppendLine(")");
            builder.AppendLine($"ON DELETE {ActionToString(DeleteAction)}");         
            builder.Append($"ON UPDATE {ActionToString(UpdateAction)}");           

            return builder.ToString();
        }

        public override String DropScript()
        {
            String result = $"ALTER TABLE {this.ParentObject.QualifiedName} DROP CONSTRAINT {Name}";
            return result;
        }

    }
}
