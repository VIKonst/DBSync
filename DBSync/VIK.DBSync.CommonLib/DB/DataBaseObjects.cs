using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB
{
    public class DataBaseObjects
    {
        public List<SqlTable> Tables { get; set; }
        public List<SqlStoredProcedure> Procedures { get; set; }
        public DataBaseObjects()
        {
            Tables = new List<SqlTable>();            
        }
    }
}
