using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.DB;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public abstract class SqlObject : ISqlObject
    {
        public String IsExistStatement
        {
            get
            {
                return String.Format("EXISTS ( SELECT * FROM sys.objects where  [object_id] = OBJECT_ID(N'{0}') AND  [type]='{1}'))",
                this.QualifiedName, this.TypeStatement);
            }
        }       

        public DataBase ParentDb { get; set; }

        public Int32 ObjectId { get; set; }

        public String Name { get; set; }

        public String QualifiedName 
        { 
            get 
            {
                return String.Format("[{0}].[{1}]",this.SchemaName, this.Name);
            }         
        }

        public abstract SqlObjectType Type { get; }
       
        public abstract String TypeStatement { get; }

        public abstract String TypeName { get; }

        public Int32 SchemaId { get; set; }

        public String SchemaName { get; set; }

        public abstract String CreateScript();

        public abstract String DropScript();
    }
}
