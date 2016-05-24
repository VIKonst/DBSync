using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class SchemasComparer : ComparerBase<SqlSchema>
    {
        protected override CompareResult CompareObjects(SqlSchema obj1, SqlSchema obj2)
        {
            //if (obj1.Name.CompareTo(obj2.Name) != 0) return CompareResult.Different;
            if (obj1.OwnerName.CompareTo(obj2.OwnerName) != 0) return CompareResult.Different;

            return CompareResult.Equals;
        }
    }
}
