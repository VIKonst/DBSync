using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public class IndexColumn : SqlSubObject 
    {
        public Int32 ObjectId { get; set; }
        public Int32 IndexId { get; set; }
        public Int32 ColumnId { get; set; }
        public Int32 IndexColumnId { get; set; }

        public Boolean IsIncluded { get; set; }

        public Boolean IsDesc { get; set; }

        public SqlColumn Column { get; set; }


        public override String Name 
        { 
            get 
            {
                return Column.Name;
            }
            set
            {
                throw new NotImplementedException("Name is not required for IndexColumn");
            }
        }

        public String DescStatement 
        {
            get
            {
                if(IsDesc)
                {
                    return "DESC";
                }
                else
                {
                    return "ASC";
                }
            }
        }


        public String ScriptStatement
        {
            get
            {
                return $"[{Name}] {DescStatement}";
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
