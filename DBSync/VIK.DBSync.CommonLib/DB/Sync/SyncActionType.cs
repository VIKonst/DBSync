using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIK.DBSync.CommonLib.DB.Sync
{
    public enum SyncActionType
    {
        DropFK =0,      
        DropDC,
        DropCC,
        DropUC,
        DropIndex,
        DropPK,
        DropStorProcedure,
        DropTable,   
        DropSchema,   
        CreateSchema,  
        CreateTable,
        CreateStorProcedure,
        CreatePK,
        CreateIndex,
        CreateUC,
        CreateDC,       
        CreateCC,
        CreateFK
    }
}
