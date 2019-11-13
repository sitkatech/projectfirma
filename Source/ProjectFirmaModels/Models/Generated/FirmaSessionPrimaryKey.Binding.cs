//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FirmaSession
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FirmaSessionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FirmaSession>
    {
        public FirmaSessionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FirmaSessionPrimaryKey(FirmaSession firmaSession) : base(firmaSession){}

        public static implicit operator FirmaSessionPrimaryKey(int primaryKeyValue)
        {
            return new FirmaSessionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator FirmaSessionPrimaryKey(FirmaSession firmaSession)
        {
            return new FirmaSessionPrimaryKey(firmaSession);
        }
    }
}