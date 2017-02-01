//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Organization]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteOrganization(this IQueryable<Organization> organizations, List<int> organizationIDList)
        {
            if(organizationIDList.Any())
            {
                organizations.Where(x => organizationIDList.Contains(x.OrganizationID)).Delete();
            }
        }

        public static void DeleteOrganization(this IQueryable<Organization> organizations, ICollection<Organization> organizationsToDelete)
        {
            if(organizationsToDelete.Any())
            {
                var organizationIDList = organizationsToDelete.Select(x => x.OrganizationID).ToList();
                organizations.Where(x => organizationIDList.Contains(x.OrganizationID)).Delete();
            }
        }

        public static void DeleteOrganization(this IQueryable<Organization> organizations, int organizationID)
        {
            DeleteOrganization(organizations, new List<int> { organizationID });
        }

        public static void DeleteOrganization(this IQueryable<Organization> organizations, Organization organizationToDelete)
        {
            DeleteOrganization(organizations, new List<Organization> { organizationToDelete });
        }
    }
}