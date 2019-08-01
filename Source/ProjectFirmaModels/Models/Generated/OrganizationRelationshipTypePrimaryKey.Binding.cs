//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.OrganizationRelationshipType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class OrganizationRelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<OrganizationRelationshipType>
    {
        public OrganizationRelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OrganizationRelationshipTypePrimaryKey(OrganizationRelationshipType organizationRelationshipType) : base(organizationRelationshipType){}

        public static implicit operator OrganizationRelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new OrganizationRelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator OrganizationRelationshipTypePrimaryKey(OrganizationRelationshipType organizationRelationshipType)
        {
            return new OrganizationRelationshipTypePrimaryKey(organizationRelationshipType);
        }
    }
}