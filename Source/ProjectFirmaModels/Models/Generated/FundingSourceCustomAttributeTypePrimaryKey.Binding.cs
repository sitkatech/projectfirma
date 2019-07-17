//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingSourceCustomAttributeType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingSourceCustomAttributeType>
    {
        public FundingSourceCustomAttributeTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingSourceCustomAttributeTypePrimaryKey(FundingSourceCustomAttributeType fundingSourceCustomAttributeType) : base(fundingSourceCustomAttributeType){}

        public static implicit operator FundingSourceCustomAttributeTypePrimaryKey(int primaryKeyValue)
        {
            return new FundingSourceCustomAttributeTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingSourceCustomAttributeTypePrimaryKey(FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            return new FundingSourceCustomAttributeTypePrimaryKey(fundingSourceCustomAttributeType);
        }
    }
}