﻿using System;
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

        SyncScript _syncScript;
        SyncOptions _options;
        public SyncGenerator()
            :this(new SyncOptions())
        {

        }

        public SyncGenerator(SyncOptions options)
        {
            _options = options;
        }

        public String GenerateScript(List<ComparePair> items)
        {
            _syncScript = new SyncScript(_options);

            foreach (var item in items)
            {
                switch (item.Result)
                {
                    case CompareResult.Removed:
                        DropObject(item.DestinationObject);
                        break;
                    case CompareResult.New:
                        CreateObject(item.SourceObject);
                        break;
                    case CompareResult.Different:
                        UpdateObject(item.SourceObject, item.DestinationObject);
                        break;
                    case CompareResult.Equals:
                        break;
                }
            }

            return _syncScript.ToString();
        }

        private void DropObject(SqlObject obj)
        {
            switch (obj.Type)
            {
                case SqlObjectType.Table:
                    DropTable(obj as SqlTable);
                    break;
                default:
                    _syncScript.Add(new SyncAction
                    {
                        Name = obj.Name,
                        Text = obj.DropScript(),
                        Type = GetDropActionType(obj.Type)
                    });
                    break;
            }
        }

        private void CreateObject(SqlObject obj)
        {
            switch (obj.Type)
            {
                case SqlObjectType.Table:
                    TablesSynchroniser.CreateTable(obj as SqlTable, _syncScript);
                    break;
                default:
                    _syncScript.Add(new SyncAction
                    {
                        Name = obj.Name,
                        Text = obj.CreateScript(),
                        Type = GetCreateActionType(obj.Type)
                    });
                    break;
            }
        }

        private void UpdateObject(SqlObject source, SqlObject destination)
        {
            switch (source.Type)
            {
                case SqlObjectType.Table:
                    UpdateTables(source as SqlTable, destination as SqlTable);
                    break;
                case SqlObjectType.Type:
                    UpdateTypes(source as SqlType, destination as SqlType);
                    break;
                default:
                    _syncScript.Add(new SyncAction
                    {
                        Name = source.Name,
                        Text = source.CreateScript(),
                        Type = GetCreateActionType(source.Type)
                    });
                    _syncScript.Add(new SyncAction
                    {
                        Name = destination.Name,
                        Text = destination.DropScript(),
                        Type = GetDropActionType(destination.Type)
                    });
                    break;
            }
        }

        private void UpdateTypes(SqlType source, SqlType destination)
        {
            StringBuilder text = new StringBuilder();
            foreach(SqlColumn column in destination.Columns)
            {
                text.AppendLine($"ALTER TABLE {column.ParentObject.QualifiedName} ALTER COLUMN [{column.Name}] {destination.GetTypeStatement()}");
            }
            text.AppendLine(destination.DropScript());
            text.AppendLine(source.CreateScript());
            foreach (SqlColumn column in destination.Columns)
            {
                text.AppendLine($"ALTER TABLE {column.ParentObject.QualifiedName} ALTER COLUMN [{column.Name}] {source.QualifiedName}");
            }

            _syncScript.Add(new SyncAction {
                Name = source.Name,
                Text = text.ToString(),
                Type = SyncActionType.AlterType
            }
            );
        }

        private SyncActionType GetDropActionType(SqlObjectType type)
        {
            switch (type)
            {
                case SqlObjectType.Table:
                    return SyncActionType.DropTable;
                case SqlObjectType.Schema:
                    return SyncActionType.DropSchema;
                case SqlObjectType.StoredProcedure:
                    return SyncActionType.DropStorProcedure;
                case SqlObjectType.XmlSchema:
                    return SyncActionType.DropXmlSchema;
                case SqlObjectType.Type:
                    return SyncActionType.DropType;
                default:
                    throw new Exception("not suppurted type");
            }
        }

        private SyncActionType GetCreateActionType(SqlObjectType type)
        {
            switch (type)
            {
                case SqlObjectType.Table:
                    return SyncActionType.CreateTable;
                case SqlObjectType.Schema:
                    return SyncActionType.CreateSchema;
                case SqlObjectType.StoredProcedure:
                    return SyncActionType.CreateStorProcedure;
                case SqlObjectType.XmlSchema:
                    return SyncActionType.CreateXmlSchema;
                case SqlObjectType.Type:
                    return SyncActionType.CreateType;
                default:
                    throw new Exception("not suppurted type");
            }
        }  

        private void DropTable(SqlTable table)
        {
            foreach (var subItem in table.Dependencies)
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
                Name = table.Name,
                Text = table.DropScript(),
                Type = SyncActionType.DropTable
            });
        }

        private void UpdateTables(SqlTable source, SqlTable dest)
        {
            TablesSynchroniser sync = new TablesSynchroniser(source, dest);
            sync.FillScript(_syncScript);
        }

    }
}
