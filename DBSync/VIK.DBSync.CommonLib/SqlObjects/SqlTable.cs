using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlTable : SqlObject
    {
        public override SqlObjectType Type
        {
            get
            {
                return SqlObjectType.Table;
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
                return "U";
            }
        }


        public Boolean IsAnsiNullsOn { get; set; }
        public override String CreateScript()
        {
            throw new NotImplementedException();
        }

        public override String DropScript()
        {
            throw new NotImplementedException();
        }
    }
}
