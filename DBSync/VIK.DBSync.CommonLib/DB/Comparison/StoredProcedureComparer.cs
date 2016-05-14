using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class StoredProcedureComparer
    {
        public static List<ComparePair> CompareTablesList(List<SqlStoredProcedure> sourceProcedures, List<SqlStoredProcedure> destProcedures)
        {
            Dictionary<String, SqlStoredProcedure> sourceDic = sourceProcedures.ToDictionary(t => t.QualifiedName);
            Dictionary<String, SqlStoredProcedure> destDic = destProcedures.ToDictionary(t => t.QualifiedName);

            List<ComparePair> result = new List<ComparePair>();
            ComparePair comparePair;
            foreach (var pair in sourceDic)
            {
                SqlStoredProcedure destObj;

                if (destDic.TryGetValue(pair.Key, out destObj))
                {
                    comparePair = new ComparePair()
                    {
                        SourceObject = pair.Value,
                        DestinationObject = destObj,
                        Result = CompareStoredProcedures(pair.Value, destObj)
                    };

                    destDic.Remove(pair.Key);
                }
                else
                {
                    comparePair = new ComparePair()
                    {
                        SourceObject = pair.Value,
                        DestinationObject = null,
                        Result = CompareResult.New
                    };
                }
                comparePair.Name = pair.Key;
                result.Add(comparePair);
            }

            foreach (var table in destDic.Values)
            {
                result.Add(new ComparePair()
                {
                    Name = table.QualifiedName,
                    SourceObject = null,
                    DestinationObject = table,
                    Result = CompareResult.Removed
                });
            }
            return result;
        }

        public static CompareResult CompareStoredProcedures(SqlStoredProcedure sourceProcedure, SqlStoredProcedure destProcedure)
        {
            if (sourceProcedure.Text.CompareTo(destProcedure.Text) != 0) return CompareResult.Different;

            return CompareResult.Equals;
        }
    }

   
}
