using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class SqlType : SqlObject
    {
        public override SqlObjectType Type
        {
            get
            {
                return SqlObjectType.Type;
            }
        }

        public override String TypeName
        {
            get
            {
                return "Type";
            }
        }

        public override String TypeStatement
        {
            get
            {
                return "T";
            }
        }

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
