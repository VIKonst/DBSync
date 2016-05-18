using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.DB;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class SchemaLoader : SqlObjectMetadataLoaderBase<SqlSchema>
    {
        public SchemaLoader(DataBase parentDb) :
        base("VIK.DBSync.CommonLib.Scripts.Schemas.sql", parentDb)
        {
        }

        public override void LoadSubObjects(SqlSchema sqlObject, IDbConnection reader)
        {
            //Schema have not sub objects
        }

        protected override SqlSchema GetObject(IDataRecord reader)
        {
            SqlSchema schema = new SqlSchema();
            schema.Name = (String)reader["schema_name"];
            schema.OwnerName = (String)reader["principal_name"];
            return schema;
        }
    }
}
