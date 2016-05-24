using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class StoredProcedureComparer : ComparerBase<SqlStoredProcedure>
    {      

        protected override CompareResult CompareObjects(SqlStoredProcedure sourceProcedure, SqlStoredProcedure destProcedure)
        {
            if (sourceProcedure.Text.CompareTo(destProcedure.Text) != 0) return CompareResult.Different;

            return CompareResult.Equals;
        }
    }

   
}
