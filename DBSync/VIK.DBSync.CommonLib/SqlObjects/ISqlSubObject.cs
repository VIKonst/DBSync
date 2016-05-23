using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public interface ISqlSubObject
    {
        Int32 ParentObjectId { get; set; }

        ISqlObject ParentObject { get; set; }

        String Name { get; set; }

        Boolean IsNotForReplication { get; set; }

    }
}
