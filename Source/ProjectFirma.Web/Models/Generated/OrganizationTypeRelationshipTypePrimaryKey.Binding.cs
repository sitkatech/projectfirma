//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.OrganizationTypeRelationshipType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class OrganizationTypeRelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<OrganizationTypeRelationshipType>
    {
        public OrganizationTypeRelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public OrganizationTypeRelationshipTypePrimaryKey(OrganizationTypeRelationshipType organizationTypeRelationshipType) : base(organizationTypeRelationshipType){}

        public static implicit operator OrganizationTypeRelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new OrganizationTypeRelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator OrganizationTypeRelationshipTypePrimaryKey(OrganizationTypeRelationshipType organizationTypeRelationshipType)
        {
            return new OrganizationTypeRelationshipTypePrimaryKey(organizationTypeRelationshipType);
        }
    }
}