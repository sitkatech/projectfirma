//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationBoundaryStaging]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationBoundaryStaging GetOrganizationBoundaryStaging(this IQueryable<OrganizationBoundaryStaging> organizationBoundaryStagings, int organizationBoundaryStagingID)
        {
            var organizationBoundaryStaging = organizationBoundaryStagings.SingleOrDefault(x => x.OrganizationBoundaryStagingID == organizationBoundaryStagingID);
            Check.RequireNotNullThrowNotFound(organizationBoundaryStaging, "OrganizationBoundaryStaging", organizationBoundaryStagingID);
            return organizationBoundaryStaging;
        }

        public static void DeleteOrganizationBoundaryStaging(this List<int> organizationBoundaryStagingIDList)
        {
            if(organizationBoundaryStagingIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizationBoundaryStagings.RemoveRange(HttpRequestStorage.DatabaseEntities.OrganizationBoundaryStagings.Where(x => organizationBoundaryStagingIDList.Contains(x.OrganizationBoundaryStagingID)));
            }
        }

        public static void DeleteOrganizationBoundaryStaging(this ICollection<OrganizationBoundaryStaging> organizationBoundaryStagingsToDelete)
        {
            if(organizationBoundaryStagingsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizationBoundaryStagings.RemoveRange(organizationBoundaryStagingsToDelete);
            }
        }

        public static void DeleteOrganizationBoundaryStaging(this int organizationBoundaryStagingID)
        {
            DeleteOrganizationBoundaryStaging(new List<int> { organizationBoundaryStagingID });
        }

        public static void DeleteOrganizationBoundaryStaging(this OrganizationBoundaryStaging organizationBoundaryStagingToDelete)
        {
            DeleteOrganizationBoundaryStaging(new List<OrganizationBoundaryStaging> { organizationBoundaryStagingToDelete });
        }
    }
}