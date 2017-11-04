using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class TypeComparer : ComparerBase<SqlType>
    {
        protected override CompareResult CompareObjects(SqlType obj1, SqlType obj)
        {
            if (obj1.CreateScript().CompareTo(obj.CreateScript()) != 0) return CompareResult.Different;
            return CompareResult.Equals;
        }
    }
}
