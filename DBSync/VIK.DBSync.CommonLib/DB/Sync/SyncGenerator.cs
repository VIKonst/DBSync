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

        SyncScript _syncScript;
        public String GenerateScript(List<ComparePair> items)
        {
            _syncScript = new SyncScript();

            _forRemove = items.Where(i => i.Result == CompareResult.Removed);
            _forCreate = items.Where(i => i.Result == CompareResult.New);
            _forUpdate = items.Where(i => i.Result == CompareResult.Different);
            CreateNewObjects();
            DropObjects();
            return _syncScript.ToString();
        }

        private String DropObjects()
        {
            StringBuilder script = new StringBuilder(String.Empty);

            DropObjects(_forRemove.Where(p => p.DestinationObject.Type == SqlObjectType.StoredProcedure)
               .Select(p => p.DestinationObject), SyncActionType.DropSchema);
            DropObjects(_forRemove.Where(p => p.DestinationObject.Type == SqlObjectType.Schema)
               .Select(p => p.DestinationObject), SyncActionType.DropStorProcedure);

            script.Append(DropTables(_forRemove.Where(p => p.DestinationObject.Type == SqlObjectType.Table)
                .Select(p => p.DestinationObject as SqlTable)));                          

          
            return script.ToString();
        }

        private void CreateNewObjects()
        {
            CreateObjects(_forCreate.Where(p => p.SourceObject.Type == SqlObjectType.Schema)
                .Select(p => p.SourceObject),SyncActionType.CreateSchema);

            CreateTables(_forCreate.Where(p=>p.SourceObject.Type==SqlObjectType.Table)
                .Select(p=>p.SourceObject as SqlTable));
                
            CreateObjects(_forCreate.Where(p => p.SourceObject.Type == SqlObjectType.StoredProcedure)
                .Select(p => p.SourceObject), SyncActionType.CreateStorProcedure);

            
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

        private void CreateObjects(IEnumerable<SqlObject> objects, SyncActionType type)
        {            
            foreach (var item in objects)
            {
                _syncScript.Add(new SyncAction
                {
                    Name = item.QualifiedName,
                    Text = item.CreateScript(),
                    Type = type
                });
            }       
          
        }

        private void CreateTables(IEnumerable<SqlTable> tables)
        {            
            foreach (var item in tables)
            {
                _syncScript.Add(new SyncAction
                {
                    Name = item.QualifiedName,
                    Text = item.HeaderCreateScript(),
                    Type = SyncActionType.CreateTable
                });

                if (item.PrimarKey != null)
                {
                    _syncScript.Add(new SyncAction
                    {
                        Name = item.PrimarKey.Name,
                        Text = item.PrimarKey.CreateScript(),
                        Type = SyncActionType.CreatePK
                    });
                }

                foreach (var subItem in item.UniqueConstraints)
                {
                    _syncScript.Add(new SyncAction
                    {
                        Name = subItem.Name,
                        Text = subItem.CreateScript(),
                        Type = SyncActionType.CreateUC
                    });
                }

                foreach (var subItem in item.DefaultConstraints)
                {
                    _syncScript.Add(new SyncAction
                    {
                        Name = subItem.Name,
                        Text = subItem.CreateScript(),
                        Type = SyncActionType.CreateDC
                    });
                }

                foreach (var subItem in item.CheckConstraints)
                {
                    _syncScript.Add(new SyncAction
                    {
                        Name = subItem.Name,
                        Text = subItem.CreateScript(),
                        Type = SyncActionType.CreateCC
                    });
                }

                foreach (var subItem in item.Indexes)
                {
                    _syncScript.Add(new SyncAction
                    {
                        Name = subItem.Name,
                        Text = subItem.CreateScript(),
                        Type = SyncActionType.CreateIndex
                    });
                }

                foreach (var subItem in item.ForeignKeys)
                {
                    _syncScript.Add(new SyncAction
                    {
                        Name = subItem.Name,
                        Text = subItem.CreateScript(true),
                        Type = SyncActionType.CreateFK
                    });
                }
            }
        }


        private void DropObjects(IEnumerable<SqlObject> objects, SyncActionType actType)
        {            
            foreach (var item in objects)
            {
                _syncScript.Add(new SyncAction
                {
                    Name = item.Name,
                    Text = item.DropScript(),
                    Type = actType
                });
            }          
        }

        private String DropTables(IEnumerable<SqlTable> tables)
        {
            StringBuilder script = new StringBuilder(String.Empty);
            foreach (var item in tables)
            {
                foreach (var subItem in item.Dependencies)
                {
                    _syncScript.Add(new SyncAction
                    {
                        Name = subItem.Name,
                        Text = subItem.DropScript(),
                        Type = SyncActionType.DropFK
                    });
                }

                _syncScript.Add(new SyncAction
                {
                    Name = item.Name,
                    Text = item.DropScript(),
                    Type = SyncActionType.DropTable
                });
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
