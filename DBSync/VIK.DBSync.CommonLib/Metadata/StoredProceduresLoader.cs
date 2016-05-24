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
        private String SPACES_FOR_TAB = new String(' ', 4);
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
            procedure.Text = reader.GetString(4).Replace("\t", SPACES_FOR_TAB);
            procedure.IsAnsiNullsOn = reader.GetBoolean(5);
            procedure.IsQuotedIdentifier = reader.GetBoolean(6);
            return procedure;
        }
    }
}
