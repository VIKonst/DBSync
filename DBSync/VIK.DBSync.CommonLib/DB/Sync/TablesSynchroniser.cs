using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public class TablesSynchroniser
    {
        private SqlTable _source;
        private SqlTable _dest;
        public TablesSynchroniser(SqlTable source, SqlTable dest)
        {
            _source = source;
            _dest = dest;
        }

        public String GetScript()
        {
            if(IsNeedRecreate())
            {
                return ReCreateScript();
            }
            else
            {
                return AlterScript();
            }
        }

        private class ColumnNameComparer : IEqualityComparer<SqlColumn>
        {
            public Boolean Equals(SqlColumn x, SqlColumn y)
            {
                return x.Name.Equals(y.Name);
            }

            public Int32 GetHashCode(SqlColumn obj)
            {
                return obj.Name.GetHashCode();
            }
        }

        private ColumnNameComparer _columnNameComparer = new ColumnNameComparer();

        private String ReCreateScript()
        {
            StringBuilder script = new StringBuilder();
            String newName = _source.Name + "temp" + ( Guid.NewGuid().ToString("N") );

            script.AppendLine(_source.DropSubObjects());
            script.AppendLine($"EXEC sp_rename N'{_source.QualifiedName}', N'{newName}' ");
            script.AppendLine(SqlStatement.GO);            
            script.AppendLine(_dest.CreateScript(false));
            var columns = _source.Columns.Intersect(_dest.Columns, _columnNameComparer).Select(c=>c.Name);
            String columnsText = String.Join(",",columns);
            script.AppendLine($"INSERT INTO {_dest.Name} VALUES ({columnsText}) ");
            script.AppendLine($"SELECT {columnsText} FROM {newName}");
            script.AppendLine(SqlStatement.GO);
            return script.ToString();

        }

        private String AlterScript()
        {
            throw new NotImplementedException();
        }



        private bool IsNeedRecreate()
        {
            return true;
        }
    }
}
