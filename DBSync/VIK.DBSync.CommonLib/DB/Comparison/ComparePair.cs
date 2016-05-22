using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public class ComparePair
    {
        public String Name { get; set; }
        public SqlObjectType Type { get; set; }
        public SqlObject SourceObject { get; set;  }
        public SqlObject DestinationObject { get; set; }

        public CompareResult Result { get; set; }
    }
}
