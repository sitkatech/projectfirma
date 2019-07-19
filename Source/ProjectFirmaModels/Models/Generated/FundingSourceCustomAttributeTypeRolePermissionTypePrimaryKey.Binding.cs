//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.FundingSourceCustomAttributeTypeRolePermissionType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class FundingSourceCustomAttributeTypeRolePermissionTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<FundingSourceCustomAttributeTypeRolePermissionType>
    {
        public FundingSourceCustomAttributeTypeRolePermissionTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public FundingSourceCustomAttributeTypeRolePermissionTypePrimaryKey(FundingSourceCustomAttributeTypeRolePermissionType fundingSourceCustomAttributeTypeRolePermissionType) : base(fundingSourceCustomAttributeTypeRolePermissionType){}

        public static implicit operator FundingSourceCustomAttributeTypeRolePermissionTypePrimaryKey(int primaryKeyValue)
        {
            return new FundingSourceCustomAttributeTypeRolePermissionTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator FundingSourceCustomAttributeTypeRolePermissionTypePrimaryKey(FundingSourceCustomAttributeTypeRolePermissionType fundingSourceCustomAttributeTypeRolePermissionType)
        {
            return new FundingSourceCustomAttributeTypeRolePermissionTypePrimaryKey(fundingSourceCustomAttributeTypeRolePermissionType);
        }
    }
}