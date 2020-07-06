//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[OrganizationImage]
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
        public static OrganizationImage GetOrganizationImage(this IQueryable<OrganizationImage> organizationImages, int organizationImageID)
        {
            var organizationImage = organizationImages.SingleOrDefault(x => x.OrganizationImageID == organizationImageID);
            Check.RequireNotNullThrowNotFound(organizationImage, "OrganizationImage", organizationImageID);
            return organizationImage;
        }

    }
}