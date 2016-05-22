using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class TableComparer : ComparerBase<SqlTable>
    {
        
        protected  override CompareResult CompareObjects(SqlTable table1, SqlTable table2)
        {
            if (!table1.QualifiedName.Equals(table2.QualifiedName)) throw new Exception("Should be same names");
            if (table1.IsAnsiNullsOn != table2.IsAnsiNullsOn) return CompareResult.Different;
            
            if (!CompareSubObjectsList(table1.Columns,table2.Columns)) return CompareResult.Different;
            if (!CompareSubObjectsList(table1.Indexes, table2.Indexes)) return CompareResult.Different;
            if (!CompareSubObjectsList(table1.UniqueConstraints, table2.UniqueConstraints)) return CompareResult.Different;
            if (!CompareSubObjectsList(table1.DefaultConstraints, table2.DefaultConstraints)) return CompareResult.Different;
            if (!CompareSubObjectsList(table1.CheckConstraints, table2.CheckConstraints)) return CompareResult.Different;
            if (!CompareSubObjectsList(table1.ForeignKeys, table2.ForeignKeys)) return CompareResult.Different;

            if ((table1.PrimarKey!=null && table1.PrimarKey.CompareTo(table2.PrimarKey)!=0) ||
                ( table2.PrimarKey != null && table2.PrimarKey.CompareTo(table1.PrimarKey) != 0 )) return CompareResult.Different;
            return CompareResult.Equals;
        }
 
        public static Boolean CompareSubObjectsList<T>(List<T> sourcelist, List<T> destlist)  where T : SqlSubObject
        {
            if (sourcelist.Count != destlist.Count) return false;
            for (int i = 0; i < sourcelist.Count; i++)
            {
                if (sourcelist[i].CompareTo(destlist[i]) != 0) return false;
            }
            return true;
        }

    }
}
