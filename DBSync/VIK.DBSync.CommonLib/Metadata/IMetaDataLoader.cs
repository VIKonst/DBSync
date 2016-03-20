using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public interface IMetaDataLoader<T>
    {
        List<T> LoadObjects(IDbConnection connection);
    }
}
