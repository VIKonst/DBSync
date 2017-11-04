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
            Columns = new SubObjectsCollection<SqlColumn>();
            UniqueConstraints = new SubObjectsCollection<SqlIndex>();
            Indexes = new SubObjectsCollection<SqlIndex>();
            Dependencies = new HashSet<SqlForeignKey>();
            CheckConstraints = new SubObjectsCollection<SqlCheckConstraint>();
            DefaultConstraints = new SubObjectsCollection<SqlDefaultConstraint>();
            ForeignKeys = new SubObjectsCollection<SqlForeignKey>();
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

        public Boolean HasIdentity
        {
            get
            {
                return IdentityColumnId >= 0;
            }
        }

        public Boolean IsAnsiNullsOn { get; set; }

        public Boolean IsReplicated { get; set; }

        public String LockEscalation { get; set; }

        public String DataSpaceName { get; set; }

        public Int32 IdentityColumnId { get; set; }

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
            StringBuilder script = new StringBuilder(HeaderCreateScript());
           
            if (PrimarKey != null)
            {
                script.AppendLine(PrimarKey.CreateScript());
                script.AppendLine();
            }
            
            script.Append(UniqueConstraints.CreateAllScript());
            script.Append(Indexes.CreateAllScript());
            script.Append(CheckConstraints.CreateAllScript());
            script.Append(DefaultConstraints.CreateAllScript());

            if (withFk)
            {
                script.Append(ForeignKeys.CreateAllScript());
            }

            return script.ToString();
        }
             

        public String HeaderCreateScript()
        {
            StringBuilder script = new StringBuilder(String.Empty, 500);
            script.AppendLine(SqlStatement.GetAnsiNullsStatemt(IsAnsiNullsOn));
            script.Append(SqlStatement.GetQuotedIdentifierStatemt(true));
            script.AppendLine(SqlStatement.GO);
            script.Append(SqlStatement.GetCreateStatemt("TABLE " + QualifiedName));

            //Columns definition
            script.AppendLine("(");
            script.AppendLine(String.Join(",\r\n", Columns.OrderBy(c => c.ColumnId).Select(c => c.CreateScript())));
            script.Append($")");
            script.AppendLine(SqlStatement.GO);

            return script.ToString();
        }

        public String DropDependenciesScript()
        {
            StringBuilder builder = new StringBuilder();
            foreach (SqlForeignKey key  in Dependencies)
            {
                builder.Append(key.DropScript());            
            }
            return builder.ToString();
        }

        public String CreateDependenciesScript()
        {
            StringBuilder builder = new StringBuilder();
            foreach (SqlForeignKey key in Dependencies)
            {
                builder.AppendLine(key.CreateScript());             
            }
            return builder.ToString();
        }

        public String DropSubObjects()
        {
            StringBuilder script = new StringBuilder();
            script.Append(Indexes.DropAllScript());
            script.Append(UniqueConstraints.DropAllScript());
            if (PrimarKey != null)
            {
                script.AppendLine(PrimarKey.DropScript());
            }
            script.Append(CheckConstraints.DropAllScript());
            script.Append(DefaultConstraints.DropAllScript());
            return script.ToString();
        }

        public String CreateSubObjects(Boolean withFk)
        {
            StringBuilder script = new StringBuilder();
            if (PrimarKey != null)
            {
                script.AppendLine(PrimarKey.CreateScript());
                script.AppendLine();
            }

            script.Append(UniqueConstraints.CreateAllScript());
            script.Append(Indexes.CreateAllScript());
            script.Append(CheckConstraints.CreateAllScript());
            script.Append(DefaultConstraints.CreateAllScript());

            if (withFk)
            {
                script.Append(ForeignKeys.CreateAllScript());
            }
            return script.ToString();
        }

        public override String DropScript()
        {
            return $"DROP TABLE {QualifiedName}{SqlStatement.GO}";
        }


        public override Int32 GetHashCode()
        {
            return ObjectId;
        }
    }
}
