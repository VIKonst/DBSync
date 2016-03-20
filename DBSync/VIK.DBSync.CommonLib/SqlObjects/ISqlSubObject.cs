using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public interface ISqlSubObject
    {
        ISqlObject ParentObject { get; set; }

        String ObjectName { get; set; }


    }
}
