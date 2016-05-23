using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public class SubObjectsFiller
    {
        public static void FillObjects<T, TSub>(ICollection<T> parentObjects, IEnumerable<TSub> subObjects, Func<T, ICollection<TSub>> getCollection) where T : SqlObject where TSub : SqlSubObject 
        {
            T parent = null;
            Int32 parentId = -1;
            ICollection<TSub> collection = null;

            foreach (var item in subObjects)
            {
                if (item.ParentObjectId != parentId)
                {
                    parentId = item.ParentObjectId;
                    parent = parentObjects.FirstOrDefault(o => o.ObjectId == parentId);                   
                  
                    if(parent!=null)
                    collection = getCollection(parent);
                }
                if (parent != null)
                {
                    item.ParentObject = parent;
                    collection.Add(item);
                }
               
            }
        }
    }
}
