using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.Metadata;
using VIK.DBSync.CommonLib.SqlScripting;

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

        public Boolean IsDisabled { get; set; }

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
            return CreateScript(false);
        }

        public String CreateScript(Boolean withNoCheck)
        {
            StringBuilder builder = new StringBuilder(String.Empty);
            builder.Append($"ALTER TABLE { this.ParentObject.QualifiedName}");
            if(withNoCheck)
            {
                builder.Append(" WITH NOCHECK");
            }
            builder.AppendLine($" ADD CONSTRAINT [{Name}] FOREIGN KEY");
            builder.Append("( ");
            builder.Append(String.Join(",", Columns.Select(c => $"[{c.ParentColumnName}]")));
            builder.AppendLine(")");
            builder.Append("REFERENCES ");
            builder.AppendLine(ReferencedTable.QualifiedName);
            builder.Append("(");
            builder.Append(String.Join(",", Columns.Select(c => $"[{c.ReferencedColumnName}]")));
            builder.AppendLine(")");
            builder.AppendLine($"ON DELETE {ActionToString(DeleteAction)}");
            builder.Append($"ON UPDATE {ActionToString(UpdateAction)}");
            if (IsDisabled)
            {
                builder.AppendLine();
                builder.AppendLine($"ALTER TABLE { this.ParentObject.QualifiedName} NOCHECK CONSTRAINT [{Name}]");
            }
            builder.Append(SqlStatement.GO);
            return builder.ToString();
        }

        public override String DropScript()
        {
            String result = $"ALTER TABLE {this.ParentObject.QualifiedName} DROP CONSTRAINT {Name}{SqlStatement.GO}";
            return result;
        }

    }
}
