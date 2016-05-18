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
            Dependencies = new HashSet<SqlForeignKey>();
            CheckConstraints = new List<SqlCheckConstraint>();
            DefaultConstraints = new List<SqlDefaultConstraint>();
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

        public List<SqlForeignKey> ForeignKeys { get; set; }

        public List<SqlCheckConstraint> CheckConstraints { get; set; }

        public List<SqlDefaultConstraint> DefaultConstraints { get; set; }

        public HashSet<SqlForeignKey> Dependencies { get; set; }

        public override String CreateScript()
        {
            return CreateScript(true);
        }

        public String CreateScript(Boolean withFk)
        {
            StringBuilder script = new StringBuilder(String.Empty, 500);
            script.AppendLine(SqlStatement.GetAnsiNullsStatemt(IsAnsiNullsOn));
            script.AppendLine(SqlStatement.GetQuotedIdentifierStatemt(true));
            script.AppendLine(SqlStatement.GO);
            script.AppendLine();
            script.Append(SqlStatement.GetCreateStatemt("TABLE " + QualifiedName));

            //Columns definition
            script.AppendLine("(");
            script.AppendLine(String.Join(",\r\n", Columns.OrderBy(c=>c.ColumnId).Select(c => c.CreateScript())));
            script.AppendLine(")");
            script.AppendLine(SqlStatement.GO);
            script.AppendLine();


            String alterTableStatement = SqlStatement.GetAlterTableStatemt(QualifiedName);

            if (PrimarKey != null)
            {
                script.AppendLine(alterTableStatement);
                script.AppendLine(PrimarKey.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }

            foreach (SqlIndex constraint in UniqueConstraints)
            {
                script.AppendLine(alterTableStatement);
                script.AppendLine(constraint.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }

            foreach (SqlIndex index in Indexes)
            {
                script.AppendLine(index.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }

            if (withFk)
            {
                script.AppendLine(CreateForeignKeysScript());
            }

            foreach (SqlCheckConstraint constraint in CheckConstraints)
            {
                script.AppendLine(alterTableStatement);
                script.AppendLine(constraint.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }

            foreach (SqlDefaultConstraint constraint in DefaultConstraints)
            {
                script.AppendLine(alterTableStatement);
                script.AppendLine(constraint.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }

            return script.ToString();
        }

        public String CreateForeignKeysScript()
        {
            String alterTableStatement = SqlStatement.GetAlterTableStatemt(QualifiedName);
            StringBuilder script = new StringBuilder();
            foreach (SqlForeignKey key in ForeignKeys)
            {
                script.AppendLine(alterTableStatement);
                script.AppendLine(key.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }
            return script.ToString();
        }

        public override String DropScript()
        {
            return $"DROP TABLE {QualifiedName}";
        }


        public override Int32 GetHashCode()
        {
            return ObjectId;
        }
    }
}
