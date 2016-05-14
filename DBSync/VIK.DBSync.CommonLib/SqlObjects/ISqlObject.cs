using System;
using VIK.DBSync.CommonLib.DB;

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

        DataBase ParentDb { get; set; }

        String CreateScript();

        String DropScript();

    }
}
