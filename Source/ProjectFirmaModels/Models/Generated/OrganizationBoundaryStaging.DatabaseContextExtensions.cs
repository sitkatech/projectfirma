//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationBoundaryStaging]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationBoundaryStaging GetOrganizationBoundaryStaging(this IQueryable<OrganizationBoundaryStaging> organizationBoundaryStagings, int organizationBoundaryStagingID)
        {
            var organizationBoundaryStaging = organizationBoundaryStagings.SingleOrDefault(x => x.OrganizationBoundaryStagingID == organizationBoundaryStagingID);
            Check.RequireNotNullThrowNotFound(organizationBoundaryStaging, "OrganizationBoundaryStaging", organizationBoundaryStagingID);
            return organizationBoundaryStaging;
        }

    }
}