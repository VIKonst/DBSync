using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public abstract class SqlSubObject : ISqlSubObject  
    {
        public String Name
        {
            get; set;
        }

        public virtual ISqlObject ParentObject
        {
            get; set;
        }
    }
}
