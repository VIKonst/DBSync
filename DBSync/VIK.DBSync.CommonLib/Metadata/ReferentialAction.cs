using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.Metadata
{
    public enum ReferentialAction
    {
        NoAction = 0,
        Cascade = 1,
        SetNull = 2,
        SetDefault = 3
    }
}
