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


        public String SystemTypeName { get; set; }

        public Int32 MaxLength { get; set; }

        public String ColationName { get; set; }

        public Int32 Precision { get; set; }

        public Int32 Scale { get; set; }
        public Boolean IsNulable { get; set; }

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
