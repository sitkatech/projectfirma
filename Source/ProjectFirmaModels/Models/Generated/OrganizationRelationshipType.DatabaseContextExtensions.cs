//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationRelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationRelationshipType GetOrganizationRelationshipType(this IQueryable<OrganizationRelationshipType> organizationRelationshipTypes, int organizationRelationshipTypeID)
        {
            var organizationRelationshipType = organizationRelationshipTypes.SingleOrDefault(x => x.OrganizationRelationshipTypeID == organizationRelationshipTypeID);
            Check.RequireNotNullThrowNotFound(organizationRelationshipType, "OrganizationRelationshipType", organizationRelationshipTypeID);
            return organizationRelationshipType;
        }

    }
}