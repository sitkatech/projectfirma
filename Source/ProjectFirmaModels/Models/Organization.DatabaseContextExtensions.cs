/*-----------------------------------------------------------------------
<copyright file="Organization.DatabaseContextExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<Organization> GetActiveOrganizations(this IQueryable<Organization> organizations)
        {
            return organizations.Where(x => x.IsActive).ToList().OrderBy(x => x.GetDisplayName()).ToList();
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

        public static Organization GetUnknownOrganization(this IQueryable<Organization> organizations)
        {
            return organizations.Single(x => x.OrganizationName == Organization.OrganizationUnknown);
        }
    }
}
