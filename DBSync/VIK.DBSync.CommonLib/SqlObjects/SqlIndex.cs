using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlIndex : SqlSubObject, IComparable<SqlIndex>
    {
        public Int32 IndexId { get; set; }

        public override String Name { get; set; }

        public String TypeStatement { get; set; }

        public Boolean IsUnique { get; set; }

        public Boolean IsPrimaryKey { get; set; }

        public Boolean IsUniqueConstraint { get; set; }

        public Boolean IsPadded { get; set; }

        public Boolean IsAutoStatistics { get; set; }

        public Boolean IgnoreDupKey { get; set; }

        public Boolean AllowRowLocks { get; set; }

        public Boolean AllowPageLocks { get; set; }

        public Int16 FillFactor { get; set; }

        public String FileGroup { get; set; }

        public List<IndexColumn> Columns { get; set; }

        public override String CreateScript()
        {
            StringBuilder builder = new StringBuilder(String.Empty);
          
            if(IsPrimaryKey)
            {
                builder.AppendFormat($"ADD CONSTRAINT [{Name}] PRIMARY KEY {TypeStatement}");              
            } 
            else if(IsUniqueConstraint)
            {
                builder.Append($"ADD CONSTRAINT [{Name}] UNIQUE {TypeStatement}");
            }
            else
            {
                if (IsUnique)
                {
                    builder.Append($"CREATE {TypeStatement} INDEX [{Name}] ON {ParentObject.QualifiedName}");
                }
                else
                {
                    builder.Append($"CREATE {TypeStatement} UNIQUE INDEX [{Name}] ON {ParentObject.QualifiedName}");
                }
            }
           
            builder.Append("\r\n(");
            builder.Append(String.Join(",", Columns.Select(c => c.ScriptStatement)));
            builder.AppendLine(" )");
            builder.AppendLine("WITH ( ");
            builder.AppendFormat($"PAD_INDEX = {SqlStatement.GetOnOffStatement(IsPadded)}, ");
            builder.AppendFormat($"STATISTICS_NORECOMPUTE = {SqlStatement.GetOnOffStatement(IsAutoStatistics)}, ");
            builder.AppendFormat($"IGNORE_DUP_KEY = {SqlStatement.GetOnOffStatement(IgnoreDupKey)}, ");
            builder.AppendFormat($"ALLOW_ROW_LOCKS = {SqlStatement.GetOnOffStatement(AllowRowLocks)}, ");
            builder.AppendFormat($"ALLOW_PAGE_LOCKS = {SqlStatement.GetOnOffStatement(AllowPageLocks)} ");
            if(FillFactor != 0) builder.AppendFormat($", FILLFACTOR =  {FillFactor.ToString()}");
            builder.Append(" ) ");
            if (!String.IsNullOrEmpty(FileGroup)) builder.Append(" ON [" + FileGroup + "]");
            return builder.ToString();
        }

        public Int32 CompareTo(SqlIndex other)
        {
            if (other == null) return -1;
            Int32 result = this.Name.CompareTo(other.Name);
            if (result != 0) return result;
            result = this.CreateScript().CompareTo(other.CreateScript());
            return result;
        }
    }
}
