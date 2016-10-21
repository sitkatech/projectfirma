//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.LandBank
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class LandBankPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<LandBank>
    {
        public LandBankPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public LandBankPrimaryKey(LandBank landBank) : base(landBank){}

        public static implicit operator LandBankPrimaryKey(int primaryKeyValue)
        {
            return new LandBankPrimaryKey(primaryKeyValue);
        }

        public static implicit operator LandBankPrimaryKey(LandBank landBank)
        {
            return new LandBankPrimaryKey(landBank);
        }
    }
}