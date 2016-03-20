using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlTable : SqlObject
    {
        public override SqlObjectType Type
        {
            get
            {
                return SqlObjectType.Table;
            }
        }

        public override String TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

        public override String TypeStatement
        {
            get
            {
                return "U";
            }
        }


        public Boolean IsAnsiNullsOn { get; set; }

        public List<SqlColumn> Columns { get; set; }

        public override String CreateScript()
        {
            StringBuilder script = new StringBuilder(String.Empty, 500);
            script.AppendLine(SqlStatement.GetAnsiNullsStatemt(IsAnsiNullsOn));
            script.AppendLine(SqlStatement.GetQuotedIdentifierStatemt(true));
            script.AppendLine(SqlStatement.GO);
            script.Append(SqlStatement.GetCreateStatemt(" TABLE " + QualifiedName));
            script.AppendLine("(");


            foreach (SqlColumn column in Columns)
            {
                script.AppendFormat("[{0}]\t{1}{2}{3}{4},\r\n",column.Name, column.TypeStatement,
                column.IdentityStatement, column.ColationStatement, column.NullStatement);
            }
            script[script.Length - 3] = ' ';
            script.AppendLine(")");

            return script.ToString();

        }
        public override String DropScript()
        {
            throw new NotImplementedException();
        }
    }
}
