using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class DBComparer
    {
        public static List<ComparePair> CompareDatabase(DataBase sourceDb, DataBase destinationDb)
        {
            List<ComparePair> result = new List<ComparePair>();
            result.AddRange((new TableComparer()).CompareList(sourceDb.Objects.Tables, destinationDb.Objects.Tables));
            result.AddRange((new StoredProcedureComparer()).CompareList(sourceDb.Objects.Procedures, destinationDb.Objects.Procedures));
            result.AddRange((new SchemasComparer()).CompareList(sourceDb.Objects.Schemas, destinationDb.Objects.Schemas));
            return result;
        }
    }
}
