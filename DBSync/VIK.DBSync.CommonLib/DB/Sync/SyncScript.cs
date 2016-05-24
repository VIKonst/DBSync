using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public class SyncScript : SortedSet<SyncAction>
    {

        private SyncOptions _options;

        private class SyncActionComparer : IComparer<SyncAction>
        {
            public Int32 Compare(SyncAction x, SyncAction y)
            {
                Int32 result = x.Type.CompareTo(y.Type);
                if (result != 0) return result;
                result = x.Name.CompareTo(y.Name);
                return result;
            }
        }

        public SyncScript()
            : this(new SyncOptions())
        {

        }

        public SyncScript(SyncOptions options)
            : base(new SyncActionComparer())
        {
            _options = options;
        }

        public override String ToString()
        {
            String body = String.Empty;
            StringBuilder end = new StringBuilder();
            StringBuilder start = new StringBuilder();

            start.Append("SET NOEXEC OFF");
            start.AppendLine(SqlStatement.GO);

            String seperartor = Environment.NewLine;
            if (_options.SafeTransaction)
            {
                start.Append("BEGIN TRAN");               
                start.Append(SqlStatement.GO);

                seperartor = String.Concat(SqlStatement.CHECK_ERROR, SqlStatement.GO,Environment.NewLine);

                end.AppendLine(seperartor);
                end.AppendLine(SqlStatement.COMMIT);
                end.Append("SET NOEXEC OFF");
                end.Append(SqlStatement.GO);
            }

            body = String.Join(seperartor, this);          
          
            
            return String.Concat(start, body, end.ToString());
        }
    }
}
