//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingSourceCustomAttributeValue
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeValuePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingSourceCustomAttributeValue>
    {
        public FundingSourceCustomAttributeValuePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingSourceCustomAttributeValuePrimaryKey(FundingSourceCustomAttributeValue fundingSourceCustomAttributeValue) : base(fundingSourceCustomAttributeValue){}

        public static implicit operator FundingSourceCustomAttributeValuePrimaryKey(int primaryKeyValue)
        {
            return new FundingSourceCustomAttributeValuePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingSourceCustomAttributeValuePrimaryKey(FundingSourceCustomAttributeValue fundingSourceCustomAttributeValue)
        {
            return new FundingSourceCustomAttributeValuePrimaryKey(fundingSourceCustomAttributeValue);
        }
    }
}