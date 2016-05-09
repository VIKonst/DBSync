using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public enum  CompareResult
    {
        Equals = 1,
        Different,
        New,
        Removed
    }
}
