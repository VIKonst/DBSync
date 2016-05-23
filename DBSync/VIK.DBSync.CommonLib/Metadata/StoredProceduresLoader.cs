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
    public class StoredProceduresLoader : SqlObjectMetadataLoaderBase<SqlStoredProcedure>
    {
        public StoredProceduresLoader(DataBase db)
            : base("VIK.DBSync.CommonLib.Scripts.StoredProcedures.sql", db)
        {            
        }

        protected override SqlStoredProcedure GetObject(IDataRecord reader)
        {
            SqlStoredProcedure procedure = new SqlStoredProcedure();
            procedure.Name = reader.GetString(0);
            procedure.SchemaId = reader.GetInt32(1);
            procedure.SchemaName = reader.GetString(2);
            procedure.ObjectId = reader.GetInt32(3);
            procedure.Text = reader.GetString(4);
            procedure.IsAnsiNullsOn = reader.GetBoolean(5);
            procedure.IsQuotedIdentifier = reader.GetBoolean(6);
            return procedure;
        }
    }
}
