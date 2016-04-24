using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.SqlObjects
{
    enum  SqlSubObjectType
    {
        Column,
        ForeignKey,
        Index,
        DefaultConstraint,
        UniqueConstraint,
        CheckConstraint

    }
}
