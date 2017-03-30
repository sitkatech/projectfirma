/*-----------------------------------------------------------------------
<copyright file="MultiTenantHelpers.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.Spatial;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    public static class MultiTenantHelpers
    {
        private static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();

        private static TenantAttribute GetCurrentTenantAttributes()
        {
            return HttpRequestStorage.DatabaseEntities.TenantAttributes.Single(x => x.TenantID == HttpRequestStorage.Tenant.TenantID);
        }

        public static string GetTaxonomySystemName()
        {
            return GetCurrentTenantAttributes().TaxonomySystemName;
        }

        public static string GetTaxonomyTierOneDisplayNameForProject()
        {
            return GetCurrentTenantAttributes().TaxonomyTierOneDisplayNameForProject;
        }

        public static string GetPerformanceMeasureName()
        {
            return GetCurrentTenantAttributes().PerformanceMeasureDisplayName;
        }

        public static string GetPerformanceMeasureNamePluralized()
        {
            return PluralizationService.Pluralize(GetPerformanceMeasureName());
        }

        public static string GetClassificationDisplayName()
        {
            return GetCurrentTenantAttributes().ClassificationDisplayName;
        }

        public static string GetClassificationDisplayNamePluralized()
        {
            return PluralizationService.Pluralize(GetClassificationDisplayName());
        }

        public static string GetTenantDisplayName()
        {
            return HttpRequestStorage.Tenant.TenantName;
        }

        public static string GetTenantSquareLogoUrl()
        {
            return GetCurrentTenantAttributes().TenantSquareLogoUrl;
        }

        public static string GetTenantBannerLogoUrl()
        {
            return GetCurrentTenantAttributes().TenantBannerLogoUrl;
        }

        public static string GetTenantStyleSheetUrl()
        {
            return GetCurrentTenantAttributes().TenantStyleSheetUrl;
        }
        
        public static DbGeometry GetDefaultBoundingBox()
        {
            return GetCurrentTenantAttributes().DefaultBoundingBox;
        }

        public static int NumberOfTaxonomyTiers
        {
            get { return GetCurrentTenantAttributes().NumberOfTaxonomyTiersToUse; }
            set { GetCurrentTenantAttributes().NumberOfTaxonomyTiersToUse = value; }
        }
        public static int MinimumYear { get { return GetCurrentTenantAttributes().MinimumYear;  } }
    }
}
