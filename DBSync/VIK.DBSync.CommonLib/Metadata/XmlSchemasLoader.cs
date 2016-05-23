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
    class XmlSchemasLoader : SqlObjectMetadataLoaderBase<SqlXmlSchema>
    {
        public XmlSchemasLoader(DataBase parentDb) 
        : base("VIK.DBSync.CommonLib.Scripts.XmlSchemas.sql", parentDb)
        {
        }

        protected override SqlXmlSchema GetObject(IDataRecord reader)
        {
            SqlXmlSchema schema = new SqlXmlSchema();
            schema.Name = (String)reader["xml_collection_name"];
            schema.ObjectId = (Int32)reader["xml_collection_id"];
            schema.SchemaId = (Int32)reader["schema_id"];
            schema.SchemaName = (String)reader["schema_name"];
            schema.Definition = (String)reader["definition"];

            return schema;
        }
    }
}
