using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;
using VIK.DBSync.CommonLib.SqlScripting;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public class TablesSynchroniser
    {
        private SqlTable _source;
        private SqlTable _dest;
        public TablesSynchroniser(SqlTable source, SqlTable dest)
        {
            _source = source;
            _dest = dest;
        }

        public void FillScript(SyncScript script)
        {
            if(IsNeedRecreate())
            {
                ReCreateScript(script);
            }
            else
            {
                AlterScript(script);
            }
        }

        private class ColumnNameComparer : IEqualityComparer<SqlColumn>
        {
            public Boolean Equals(SqlColumn x, SqlColumn y)
            {
                return x.Name.Equals(y.Name);
            }

            public Int32 GetHashCode(SqlColumn obj)
            {
                return obj.Name.GetHashCode();
            }
        }

        private ColumnNameComparer _columnNameComparer = new ColumnNameComparer();

        private void ReCreateScript(SyncScript syncScript)
        {
            String newName = $"{_dest.Name}_temp{( Guid.NewGuid().ToString("N") )}";
            String fullNewName = $"[{_dest.SchemaName}].[{newName}]";
            
            foreach(var key in _dest.Dependencies)
            {
                syncScript.Add(new SyncAction
                {
                    Name = key.Name,
                    Text = key.DropScript(),
                    Type = SyncActionType.DropFK
                });
            }

            DropTableSubObjects(_dest, syncScript);

            StringBuilder script = new StringBuilder();
            script.AppendLine($"EXEC sp_rename N'{_dest.QualifiedName}', N'{newName}' ");
            script.AppendLine(SqlStatement.GO);
            script.Append(_source.CreateScript(false));

            var columns = _source.Columns.Intersect(_dest.Columns, _columnNameComparer)
                                .Where(c=>!c.IsComputed).Select(c => c.Name);

            String columnsText = String.Join(",", columns);
            if (_source.HasIdentity) script.AppendLine($"SET IDENTITY_INSERT {_source.QualifiedName} ON");
            script.AppendLine($"INSERT INTO {_dest.QualifiedName} ({columnsText}) ");
            script.AppendLine($"SELECT {columnsText} FROM {fullNewName}");
            if (_source.HasIdentity) script.AppendLine($"SET IDENTITY_INSERT {_source.QualifiedName} OFF");
            script.AppendLine(SqlStatement.GO);
            script.AppendLine($"DROP TABLE {fullNewName}");

            syncScript.Add(new SyncAction
            {
                Name = _source.QualifiedName,
                Text = script.ToString(),
                Type = SyncActionType.CreateTable
            });

            foreach (var key in _source.Dependencies)
            {
                syncScript.Add(new SyncAction
                {
                    Name = key.Name,
                    Text = key.CreateScript(true),
                    Type = SyncActionType.CreateFK
                });
            }

            foreach (var subItem in _source.ForeignKeys)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.CreateScript(true),
                    Type = SyncActionType.CreateFK
                });
            }
        }
        


        public static void CreateTable(SqlTable table, SyncScript syncScript)
        {
            syncScript.Add(new SyncAction
            {
                Name = table.QualifiedName,
                Text = table.HeaderCreateScript(),
                Type = SyncActionType.CreateTable
            });

            if (table.PrimarKey != null)
            {
                syncScript.Add(new SyncAction
                {
                    Name = table.PrimarKey.Name,
                    Text = table.PrimarKey.CreateScript(),
                    Type = SyncActionType.CreatePK
                });
            }

            foreach (var subItem in table.UniqueConstraints)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.CreateScript(),
                    Type = SyncActionType.CreateUC
                });
            }

            foreach (var subItem in table.DefaultConstraints)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.CreateScript(),
                    Type = SyncActionType.CreateDC
                });
            }

            foreach (var subItem in table.CheckConstraints)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.CreateScript(),
                    Type = SyncActionType.CreateCC
                });
            }

            foreach (var subItem in table.Indexes)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.CreateScript(),
                    Type = SyncActionType.CreateIndex
                });
            }

            foreach (var subItem in table.ForeignKeys)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.CreateScript(true),
                    Type = SyncActionType.CreateFK
                });
            }
        }

        public static void DropTableSubObjects(SqlTable table, SyncScript syncScript)
        {
            if (table.PrimarKey != null)
            {
                syncScript.Add(new SyncAction
                {
                    Name = table.PrimarKey.Name,
                    Text = table.PrimarKey.DropScript(),
                    Type = SyncActionType.DropPK
                });
            }

            foreach (var subItem in table.UniqueConstraints)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.DropScript(),
                    Type = SyncActionType.DropUC
                });
            }

            foreach (var subItem in table.DefaultConstraints)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.DropScript(),
                    Type = SyncActionType.DropDC
                });
            }

            foreach (var subItem in table.CheckConstraints)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.DropScript(),
                    Type = SyncActionType.DropCC
                });
            }

            foreach (var subItem in table.Indexes.Reverse<SqlIndex>())
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.DropScript(),
                    Type = SyncActionType.DropIndex
                });
            }

            foreach (var subItem in table.ForeignKeys)
            {
                syncScript.Add(new SyncAction
                {
                    Name = subItem.Name,
                    Text = subItem.DropScript(),
                    Type = SyncActionType.DropFK
                });
            }
        }

        private SyncScript AlterScript(SyncScript script)
        {
            throw new NotImplementedException();
        }



        private bool IsNeedRecreate()
        {
            return true;
        }
    }
}
