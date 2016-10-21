using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<Organization> GetActiveOrganizations(this IQueryable<Organization> organizations)
        {
            return organizations.Where(x => x.IsActive).ToList().OrderBy(x => x.DisplayName).ToList();
        }

        public static Organization GetOrganizationByOrganizationGuid(this IQueryable<Organization> organizations, Guid organizationGuid)
        {
            var organization = organizations.SingleOrDefault(x => x.OrganizationGuid == organizationGuid);
            return organization;
        }

        public static Organization GetOrganizationByOrganizationName(this IQueryable<Organization> organizations, string organizationName)
        {
            var organization = organizations.SingleOrDefault(x => x.OrganizationName == organizationName);
            return organization;
        }
    }
}