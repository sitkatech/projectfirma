//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationType]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static OrganizationType GetOrganizationType(this IQueryable<OrganizationType> organizationTypes, int organizationTypeID)
        {
            var organizationType = organizationTypes.SingleOrDefault(x => x.OrganizationTypeID == organizationTypeID);
            Check.RequireNotNullThrowNotFound(organizationType, "OrganizationType", organizationTypeID);
            return organizationType;
        }

    }
}