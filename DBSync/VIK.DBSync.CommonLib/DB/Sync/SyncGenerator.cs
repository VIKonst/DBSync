using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.DB.Comparison;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public class SyncGenerator
    {
        IEnumerable<ComparePair> _forRemove;
        IEnumerable<ComparePair> _forCreate;
        IEnumerable<ComparePair> _forUpdate;

        public String GenerateScript(List<ComparePair> items)
        {
            _forRemove = items.Where(i => i.Result == CompareResult.Removed);
            _forCreate = items.Where(i => i.Result == CompareResult.New);
            _forUpdate = items.Where(i => i.Result == CompareResult.Different);
            return DropObjects() + CreateNewObjects() + UpdateObjects();
        }

        private String DropObjects()
        {
            StringBuilder script = new StringBuilder(String.Empty);

            script.Append(DropObjects(_forRemove.Where(p => p.DestinationObject.Type == SqlObjectType.StoredProcedure)
               .Select(p => p.DestinationObject)));

            script.Append(DropTables(_forRemove.Where(p => p.DestinationObject.Type == SqlObjectType.Table)
                .Select(p => p.DestinationObject as SqlTable)));                          

            script.Append(DropObjects(_forRemove.Where(p => p.DestinationObject.Type == SqlObjectType.Schema)
                .Select(p => p.DestinationObject)));
            return script.ToString();
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

        private String UpdateObjects()
        {
            StringBuilder script = new StringBuilder(String.Empty);
            var tables = _forUpdate.Where(p => p.SourceObject.Type == SqlObjectType.Table);
            foreach(var pair in tables)
            {
                script.AppendLine(UpdateTables(pair.SourceObject as SqlTable,
                    pair.DestinationObject as SqlTable));
                
            }
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
                script.Append(item.ForeignKeys.CreateAllScript());
            }
            return script.ToString();
        }


        private String DropObjects(IEnumerable<SqlObject> objects)
        {
            StringBuilder script = new StringBuilder(String.Empty);
            foreach (var item in objects)
            {
                script.AppendLine(item.DropScript());
                script.AppendLine(SqlStatement.GO);
            }
            return script.ToString();
        }

        private String DropTables(IEnumerable<SqlTable> tables)
        {
            StringBuilder script = new StringBuilder(String.Empty);
            foreach (var item in tables)
            {
                script.Append(item.DropDependenciesScript());
            }

            foreach (var item in tables)
            {
                script.AppendLine(item.DropScript());
                script.AppendLine(SqlStatement.GO);
            }
            return script.ToString();
        }

        private String UpdateTables(SqlTable source, SqlTable dest)
        {
            TablesSynchroniser sync = new TablesSynchroniser( source, dest);
            return sync.GetScript();
        }

    }
}
