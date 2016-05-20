using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.DB.Comparison;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public class SyncGenerator
    {
        IEnumerable<ComparePair> _forRemove;
        IEnumerable<ComparePair> _forCreate;

        public String GenerateScript(List<ComparePair> items)
        {
            _forRemove = items.Where(i => i.Result == CompareResult.Removed);
            _forCreate = items.Where(i => i.Result == CompareResult.New);

            return CreateNewObjects();
        }

        private String CreateNewObjects()
        {
            StringBuilder script = new StringBuilder(String.Empty);
            script.Append(CreateObjects(_forCreate.Where(p => p.SourceObject.Type == SqlObjectType.Schema)
                .Select(p => p.SourceObject)));

            script.Append(CreateTables(_forCreate.Where(p=>p.SourceObject.Type==SqlObjectType.Table)
                .Select(p=>p.SourceObject as SqlTable)));
                
            script.Append(CreateObjects(_forCreate.Where(p => p.SourceObject.Type == SqlObjectType.StoredProcedure)
                .Select(p => p.SourceObject)));
            return script.ToString();
        }

        private String CreateObjects(IEnumerable<SqlObject> objects)
        {
            StringBuilder script = new StringBuilder(String.Empty);
            foreach (var item in objects)
            {
                script.Append(item.CreateScript());
            }         
            return script.ToString();
        }

        private String CreateTables(IEnumerable<SqlTable> tables)
        {
            StringBuilder script = new StringBuilder(String.Empty);
            foreach (var item in tables)
            {
                script.Append(item.CreateScript(false));
            }

            foreach (var item in tables)
            {
                script.Append(item.CreateForeignKeysScript());
            }
            return script.ToString();
        }

    }
}
