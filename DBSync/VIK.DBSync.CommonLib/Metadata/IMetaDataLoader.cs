﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIK.DBSync.CommonLib.DB;
using VIK.DBSync.CommonLib.SqlObjects;

namespace VIK.DBSync.CommonLib.Metadata
{
    public interface IMetaDataLoader<T,CollectionT> where CollectionT : ICollection<T>
    {
        CollectionT LoadObjects(IDbConnection connection);
    }
}
