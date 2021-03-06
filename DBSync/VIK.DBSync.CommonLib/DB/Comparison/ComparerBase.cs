﻿using System;
using System.Collections.Generic;
using System.Linq;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.DB.Comparison
{
    public abstract class ComparerBase<T>  where T : SqlObject
    {
        public List<ComparePair> CompareList(List<T> sourceObjects, List<T> destObjects)
        {
            Dictionary<String, T> sourceDic = sourceObjects.ToDictionary(t => t.QualifiedName, StringComparer.InvariantCultureIgnoreCase);
            Dictionary<String, T> destDic = destObjects.ToDictionary(t => t.QualifiedName, StringComparer.InvariantCultureIgnoreCase);

            List<ComparePair> result = new List<ComparePair>();
            ComparePair comparePair;
            foreach (var pair in sourceDic)
            {
                T destObj;

                if (destDic.TryGetValue(pair.Key, out destObj))
                {
                    comparePair = new ComparePair()
                    {
                        SourceObject = pair.Value,
                        DestinationObject = destObj,
                        Type = destObj.Type,
                        Result = CompareObjects(pair.Value, destObj)
                    };

                    destDic.Remove(pair.Key);
                }
                else
                {
                    comparePair = new ComparePair()
                    {
                        SourceObject = pair.Value,
                        Type = pair.Value.Type,
                        DestinationObject = null,
                        Result = CompareResult.New
                    };
                }
                comparePair.Name = pair.Key;
                result.Add(comparePair);
            }

            foreach (var table in destDic.Values)
            {
                result.Add(new ComparePair()
                {
                    Name = table.QualifiedName,
                    Type = table.Type,
                    SourceObject = null,
                    DestinationObject = table,
                    Result = CompareResult.Removed
                });
            }
            return result;
        }

        protected abstract CompareResult CompareObjects(T obj1, T obj);
    }
}
