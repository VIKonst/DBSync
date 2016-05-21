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
            UniqueConstraints = new SubObjectsCollection<SqlIndex>();
            Indexes = new SubObjectsCollection<SqlIndex>();
            Dependencies = new HashSet<SqlForeignKey>();
            CheckConstraints = new SubObjectsCollection<SqlCheckConstraint>();
            DefaultConstraints = new SubObjectsCollection<SqlDefaultConstraint>();
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

        public Boolean IsReplicated { get; set; }

        public String LockEscalation { get; set; }

        public String DataSpaceName { get; set; }

        public SubObjectsCollection<SqlColumn> Columns { get; set; }

        public SubObjectsCollection<SqlIndex> UniqueConstraints { get; set; }

        public SubObjectsCollection<SqlIndex> Indexes { get; set; }

        public SqlIndex PrimarKey { get; set; }

        public SubObjectsCollection<SqlForeignKey> ForeignKeys { get; set; }

        public SubObjectsCollection<SqlCheckConstraint> CheckConstraints { get; set; }

        public SubObjectsCollection<SqlDefaultConstraint> DefaultConstraints { get; set; }

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
            script.AppendLine($") ON [{this.DataSpaceName}]");
            script.AppendLine(SqlStatement.GO);
            script.AppendLine();

            if (PrimarKey != null)
            {
                script.AppendLine(PrimarKey.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }
            
            script.AppendLine(UniqueConstraints.CreateAllScript());
            script.AppendLine(Indexes.CreateAllScript());
            script.AppendLine(CheckConstraints.CreateAllScript());
            script.AppendLine(DefaultConstraints.CreateAllScript());

            if (withFk)
            {
                script.AppendLine(ForeignKeys.CreateAllScript());
            }

            return script.ToString();
        }
             

        public String DropDependenciesScript()
        {
            StringBuilder builder = new StringBuilder();
            foreach (SqlForeignKey key  in Dependencies)
            {
                builder.AppendLine(key.DropScript());
                builder.AppendLine(SqlStatement.GO);
            }
            return builder.ToString();
        }

        public String CreateDependenciesScript()
        {
            StringBuilder builder = new StringBuilder();
            foreach (SqlForeignKey key in Dependencies)
            {
                builder.AppendLine(key.CreateScript());
                builder.AppendLine(SqlStatement.GO);
            }
            return builder.ToString();
        }

        public String DropSubObjects()
        {
            StringBuilder script = new StringBuilder();
            script.Append(PrimarKey.DropScript());
            script.AppendLine(UniqueConstraints.DropAllScript());
            script.AppendLine(Indexes.DropAllScript());
            script.AppendLine(CheckConstraints.DropAllScript());
            script.AppendLine(DefaultConstraints.DropAllScript());
            return script.ToString();
        }

        public String CreateSubObjects(Boolean withFk)
        {
            StringBuilder script = new StringBuilder();
            if (PrimarKey != null)
            {
                script.AppendLine(PrimarKey.CreateScript());
                script.AppendLine(SqlStatement.GO);
                script.AppendLine();
            }

            script.AppendLine(UniqueConstraints.CreateAllScript());
            script.AppendLine(Indexes.CreateAllScript());
            script.AppendLine(CheckConstraints.CreateAllScript());
            script.AppendLine(DefaultConstraints.CreateAllScript());

            if (withFk)
            {
                script.AppendLine(ForeignKeys.CreateAllScript());
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
