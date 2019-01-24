//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationTypeRelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationTypeRelationshipType GetOrganizationTypeRelationshipType(this IQueryable<OrganizationTypeRelationshipType> organizationTypeRelationshipTypes, int organizationTypeRelationshipTypeID)
        {
            var organizationTypeRelationshipType = organizationTypeRelationshipTypes.SingleOrDefault(x => x.OrganizationTypeRelationshipTypeID == organizationTypeRelationshipTypeID);
            Check.RequireNotNullThrowNotFound(organizationTypeRelationshipType, "OrganizationTypeRelationshipType", organizationTypeRelationshipTypeID);
            return organizationTypeRelationshipType;
        }

    }
}