using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class XmlSchemaComparer : ComparerBase<SqlXmlSchema>
    {
        protected override CompareResult CompareObjects(SqlXmlSchema obj1, SqlXmlSchema obj)
        {
           if(obj.Definition.CompareTo(obj1.Definition)!=0) return CompareResult.Different;
           return CompareResult.Equals;
        }
    }
}
