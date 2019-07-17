//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingSourceCustomAttributeDataType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeDataTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingSourceCustomAttributeDataType>
    {
        public FundingSourceCustomAttributeDataTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingSourceCustomAttributeDataTypePrimaryKey(FundingSourceCustomAttributeDataType fundingSourceCustomAttributeDataType) : base(fundingSourceCustomAttributeDataType){}

        public static implicit operator FundingSourceCustomAttributeDataTypePrimaryKey(int primaryKeyValue)
        {
            return new FundingSourceCustomAttributeDataTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingSourceCustomAttributeDataTypePrimaryKey(FundingSourceCustomAttributeDataType fundingSourceCustomAttributeDataType)
        {
            return new FundingSourceCustomAttributeDataTypePrimaryKey(fundingSourceCustomAttributeDataType);
        }
    }
}