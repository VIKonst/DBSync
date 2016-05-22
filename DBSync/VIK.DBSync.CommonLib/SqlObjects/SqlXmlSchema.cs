using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlXmlSchema : SqlObject
    {
        public override SqlObjectType Type
        {
            get
            {
                return SqlObjectType.XmlSchema;
            }
        }

        public override String TypeName
        {
            get
            {
                return Type.ToString();
            }
        }

        public override String TypeStatement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public String Definition { get; set; }

        public override String CreateScript()
        {
            return $"CREATE XML SCHEMA COLLECTION {QualifiedName} AS '{Definition}'{SqlStatement.GO}";

        }

        public override String DropScript()
        {
            return $"DROP XML SCHEMA COLLECTION {QualifiedName}{SqlStatement.GO}";
        }
    }
}
