using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSync.SqlLiteDb.Entities
{
    public class Setting
    {
        public Int64 ID { get; set; }

        public String SettingName { get; set; }

        public String SettingValue { get; set; }
    }
}
