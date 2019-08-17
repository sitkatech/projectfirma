//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.OrganizationTypeOrganizationRelationshipType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class OrganizationTypeOrganizationRelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<OrganizationTypeOrganizationRelationshipType>
    {
        public OrganizationTypeOrganizationRelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OrganizationTypeOrganizationRelationshipTypePrimaryKey(OrganizationTypeOrganizationRelationshipType organizationTypeOrganizationRelationshipType) : base(organizationTypeOrganizationRelationshipType){}

        public static implicit operator OrganizationTypeOrganizationRelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new OrganizationTypeOrganizationRelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator OrganizationTypeOrganizationRelationshipTypePrimaryKey(OrganizationTypeOrganizationRelationshipType organizationTypeOrganizationRelationshipType)
        {
            return new OrganizationTypeOrganizationRelationshipTypePrimaryKey(organizationTypeOrganizationRelationshipType);
        }
    }
}