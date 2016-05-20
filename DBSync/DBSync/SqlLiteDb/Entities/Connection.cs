using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSync.SqlLiteDb.Entities
{
    public class Connection
    {
        public Int64 Id { get; set; }

        public String Server { get; set; }

        public Boolean IsWindowsAuth { get; set; }

        public String UserName { get; set; }

        public String Pass { get; set; }
    }
}
