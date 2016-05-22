using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public class SyncAction
    {
        public String Name{ get; set; }

        public String Text { get; set; }

        public SyncActionType Type { get; set; }

        public override String ToString()
        {
            return Text;
        }

    }
}
