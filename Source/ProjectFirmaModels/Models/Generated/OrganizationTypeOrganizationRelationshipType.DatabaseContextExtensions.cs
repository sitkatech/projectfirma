//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationTypeOrganizationRelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationTypeOrganizationRelationshipType GetOrganizationTypeOrganizationRelationshipType(this IQueryable<OrganizationTypeOrganizationRelationshipType> organizationTypeOrganizationRelationshipTypes, int organizationTypeOrganizationRelationshipTypeID)
        {
            var organizationTypeOrganizationRelationshipType = organizationTypeOrganizationRelationshipTypes.SingleOrDefault(x => x.OrganizationTypeOrganizationRelationshipTypeID == organizationTypeOrganizationRelationshipTypeID);
            Check.RequireNotNullThrowNotFound(organizationTypeOrganizationRelationshipType, "OrganizationTypeOrganizationRelationshipType", organizationTypeOrganizationRelationshipTypeID);
            return organizationTypeOrganizationRelationshipType;
        }

    }
}