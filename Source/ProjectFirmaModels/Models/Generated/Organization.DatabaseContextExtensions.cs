//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Organization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static Organization GetOrganization(this IQueryable<Organization> organizations, int organizationID)
        {
            var organization = organizations.SingleOrDefault(x => x.OrganizationID == organizationID);
            Check.RequireNotNullThrowNotFound(organization, "Organization", organizationID);
            return organization;
        }

    }
}