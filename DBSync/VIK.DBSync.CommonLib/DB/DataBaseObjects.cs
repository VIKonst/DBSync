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
        public List<SqlSchema> Schemas { get; set; }

        public List<SqlXmlSchema> XmlSchemas  { get; set; }

        public List<SqlType> Types { get; set; }

        public List<SqlObject> AllObjects()
        {
            List<SqlObject> all = new List<SqlObject>();
            all.AddRange(Tables);
            all.AddRange(Procedures);
            return all;
        }

        public DataBaseObjects()
        {
            Tables = new List<SqlTable>();
            Procedures = new List<SqlStoredProcedure>();
            Schemas = new List<SqlSchema>();
            
        }
    }
}
