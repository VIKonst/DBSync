using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    public interface ISqlObject
    {
        Int32 ObjectId { get; set; }

        Int32 SchemaId { get; set; }

        String SchemaName { get; set; }

        SqlObjectType Type { get; }

        String TypeName { get; }

        String TypeStatement { get; }

        String Name { get; set; }

        String QualifiedName { get; }

        String IsExistStatement { get; }

        String CreateScript();

        String DropScript();

    }
}
