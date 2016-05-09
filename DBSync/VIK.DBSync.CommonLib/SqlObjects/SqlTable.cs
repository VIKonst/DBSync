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
        public SqlTable()
        {
            UniqueConstraints = new List<SqlIndex>();
            Indexes = new List<SqlIndex>();        
        }

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

        public List<SqlIndex> UniqueConstraints { get; set; }

        public List<SqlIndex> Indexes { get; set; }

        public SqlIndex PrimarKey { get; set; }
        

        public override String CreateScript()
        {
            StringBuilder script = new StringBuilder(String.Empty, 500);
            script.AppendLine(SqlStatement.GetAnsiNullsStatemt(IsAnsiNullsOn));
            script.AppendLine(SqlStatement.GetQuotedIdentifierStatemt(true));
            script.AppendLine(SqlStatement.GO);
            script.Append(SqlStatement.GetCreateStatemt(" TABLE " + QualifiedName));
            script.AppendLine("(");
            
            foreach (SqlColumn column in Columns.OrderBy(c => c.ColumnId))
            {
                script.Append(column.CreateStatement);
                script.Append(",\r\n");                
            }

            script[script.Length - 3] = ' ';
            script.AppendLine(")");
            script.AppendLine(SqlStatement.GO);

            String alterTableStatement = SqlStatement.GetAlterTableStatemt(QualifiedName);

            if (PrimarKey != null)
            {
                script.AppendLine(alterTableStatement);
                script.AppendLine(PrimarKey.CreateScript());
                script.AppendLine(SqlStatement.GO);
            }

           
            foreach (SqlIndex constraint in UniqueConstraints.OrderBy(c => c.IndexId))
            {
                script.AppendLine(alterTableStatement);
                script.AppendLine(constraint.CreateScript());
                script.AppendLine(SqlStatement.GO);
            }

            foreach (SqlIndex index in Indexes.OrderBy(c => c.IndexId))
            {
                script.AppendLine(index.CreateScript());
                script.AppendLine(SqlStatement.GO);
            }

            return script.ToString();

        }

        public override String DropScript()
        {
            throw new NotImplementedException();
        }
    }
}
