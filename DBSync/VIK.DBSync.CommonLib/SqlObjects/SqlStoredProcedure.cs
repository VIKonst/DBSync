using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlStoredProcedure : SqlObject
    {
        public override SqlObjectType Type
        {
            get
            {
                return SqlObjectType.StoredProcedure;
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
                return "P";
            }
        }

        public String Text { get; set; }
        public Boolean IsAnsiNullsOn { get; set; }
        public Boolean IsQuotedIdentifier { get; set; }
        public override String CreateScript()
        {
            StringBuilder script = new StringBuilder(String.Empty);
            script.AppendLine(SqlStatement.GetAnsiNullsStatemt(IsAnsiNullsOn));
            script.Append(SqlStatement.GetQuotedIdentifierStatemt(IsQuotedIdentifier));
            script.Append(SqlStatement.GO);
            script.Append(Text);
            script.AppendLine(SqlStatement.GO);
            return script.ToString();
        }

        public override String DropScript()
        {
            return $"DROP PROCEDURE {QualifiedName}{SqlStatement.GO}";
        }
    }
}
