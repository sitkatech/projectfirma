//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Organization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Organization GetOrganization(this IQueryable<Organization> organizations, int organizationID)
        {
            var organization = organizations.SingleOrDefault(x => x.OrganizationID == organizationID);
            Check.RequireNotNullThrowNotFound(organization, "Organization", organizationID);
            return organization;
        }

        public static void DeleteOrganization(this List<int> organizationIDList)
        {
            if(organizationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizations.RemoveRange(HttpRequestStorage.DatabaseEntities.Organizations.Where(x => organizationIDList.Contains(x.OrganizationID)));
            }
        }

        public static void DeleteOrganization(this ICollection<Organization> organizationsToDelete)
        {
            if(organizationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllOrganizations.RemoveRange(organizationsToDelete);
            }
        }

        public static void DeleteOrganization(this int organizationID)
        {
            DeleteOrganization(new List<int> { organizationID });
        }

        public static void DeleteOrganization(this Organization organizationToDelete)
        {
            DeleteOrganization(new List<Organization> { organizationToDelete });
        }
    }
}