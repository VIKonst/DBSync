using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public enum SyncActionType
    {
        AlterType = 0,
        DropFK,      
        DropDC,
        DropCC,
        DropUC,
        DropIndex,
        DropPK,
        DropStorProcedure,
        DropTable,
        DropType,
        DropXmlSchema,
        DropSchema,        
        CreateSchema,  
        CreateXmlSchema,
        CreateType,
        CreateTable,
        CopyDataTable,
        CreateStorProcedure,
        CreatePK,
        CreateIndex,
        CreateUC,
        CreateDC,       
        CreateCC,
        CreateFK
    }
}
