using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public class SyncScript : SortedSet<SyncAction>
    { 
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
            : base(new SyncActionComparer())
        {
        }

        public override String ToString()
        {
            return String.Join(Environment.NewLine, this); ;
        }
    }
}
