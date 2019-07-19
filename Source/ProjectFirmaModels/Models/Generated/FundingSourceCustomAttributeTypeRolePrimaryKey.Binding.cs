//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingSourceCustomAttributeTypeRole
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeTypeRolePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingSourceCustomAttributeTypeRole>
    {
        public FundingSourceCustomAttributeTypeRolePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingSourceCustomAttributeTypeRolePrimaryKey(FundingSourceCustomAttributeTypeRole fundingSourceCustomAttributeTypeRole) : base(fundingSourceCustomAttributeTypeRole){}

        public static implicit operator FundingSourceCustomAttributeTypeRolePrimaryKey(int primaryKeyValue)
        {
            return new FundingSourceCustomAttributeTypeRolePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingSourceCustomAttributeTypeRolePrimaryKey(FundingSourceCustomAttributeTypeRole fundingSourceCustomAttributeTypeRole)
        {
            return new FundingSourceCustomAttributeTypeRolePrimaryKey(fundingSourceCustomAttributeTypeRole);
        }
    }
}