using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public abstract class SqlSubObject : ISqlSubObject, IComparable<SqlSubObject>
    {
        public virtual String Name
        {
            get; set;
        }

        public virtual ISqlObject ParentObject
        {
            get; set;
        }

        public abstract String CreateScript();

        public Boolean IsNotForReplication { get; set; }

        public virtual Int32 CompareTo(SqlSubObject obj)
        {
            if (obj == null) return -1;
            Int32 result = this.Name.CompareTo(obj.Name);
            if (result != 0) return result;
            result = this.IsNotForReplication.CompareTo(obj.IsNotForReplication);
            if (result != 0) return result;
           
            return CreateScript().CompareTo(obj.CreateScript());
        } 
    }
}
