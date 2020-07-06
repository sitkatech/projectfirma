//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.OrganizationType
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class OrganizationTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<OrganizationType>
    {
        public OrganizationTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OrganizationTypePrimaryKey(OrganizationType organizationType) : base(organizationType){}

        public static implicit operator OrganizationTypePrimaryKey(int primaryKeyValue)
        {
            return new OrganizationTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator OrganizationTypePrimaryKey(OrganizationType organizationType)
        {
            return new OrganizationTypePrimaryKey(organizationType);
        }
    }
}