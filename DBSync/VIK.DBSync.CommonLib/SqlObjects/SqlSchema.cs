using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlSchema : SqlObject
    {
        public override SqlObjectType Type
        {
            get
            {
                return SqlObjectType.Schema;
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
                return "S";
            }
        }


        public String OwnerName { get; set; }

        public override String CreateScript()
        {
            return $"CREATE SCHEMA [{Name}] AUTHORIZATION {OwnerName}{Environment.NewLine}{SqlStatement.GO}{Environment.NewLine}";
        }

        public override String DropScript()
        {
            return $"DROP SCHEMA [{Name}]";
        }
    }
}
