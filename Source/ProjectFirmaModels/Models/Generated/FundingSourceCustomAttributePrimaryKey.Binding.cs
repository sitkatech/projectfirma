//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingSourceCustomAttribute
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingSourceCustomAttribute>
    {
        public FundingSourceCustomAttributePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingSourceCustomAttributePrimaryKey(FundingSourceCustomAttribute fundingSourceCustomAttribute) : base(fundingSourceCustomAttribute){}

        public static implicit operator FundingSourceCustomAttributePrimaryKey(int primaryKeyValue)
        {
            return new FundingSourceCustomAttributePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingSourceCustomAttributePrimaryKey(FundingSourceCustomAttribute fundingSourceCustomAttribute)
        {
            return new FundingSourceCustomAttributePrimaryKey(fundingSourceCustomAttribute);
        }
    }
}