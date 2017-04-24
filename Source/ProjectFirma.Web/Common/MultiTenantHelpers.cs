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
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Common
{
    public static class MultiTenantHelpers
    {
        private static readonly EnglishPluralizationService PluralizationService = new EnglishPluralizationService();

        public static string GetTaxonomySystemName()
        {
            return FieldDefinition.TaxonomySystemName.GetFieldDefinitionLabel();
        }

        public static string GetTaxonomyTierOneDisplayNameForProject()
        {
            return FieldDefinition.TaxonomyTierOneDisplayNameForProject.GetFieldDefinitionLabel();
        }

        public static string GetPerformanceMeasureName()
        {
            return FieldDefinition.PerformanceMeasure.GetFieldDefinitionLabel();
        }

        public static string GetPerformanceMeasureNamePluralized()
        {
            return PluralizationService.Pluralize(GetPerformanceMeasureName());
        }

        public static string GetTenantDisplayName()
        {
            return HttpRequestStorage.Tenant.GetTenantAttribute().TenantDisplayName;
        }

        public static string GetTenantSquareLogoUrl()
        {
            return HttpRequestStorage.Tenant.GetTenantAttribute().TenantSquareLogoFileResource != null
                ? HttpRequestStorage.Tenant.GetTenantAttribute().TenantSquareLogoFileResource.FileResourceUrl
                : "/Content/img/ProjectFirma_Logo_Square.png";
        }

        public static string GetTenantBannerLogoUrl()
        {
            return HttpRequestStorage.Tenant.GetTenantAttribute().TenantBannerLogoFileResource != null
                ? HttpRequestStorage.Tenant.GetTenantAttribute().TenantBannerLogoFileResource.FileResourceUrl
                : "/Content/img/ProjectFirma_Logo_2016_FNL.width-600.png";
        }

        public static string GetTenantStyleSheetUrl()
        {
            return HttpRequestStorage.Tenant.GetTenantAttribute().TenantStyleSheetFileResource != null
                ? new SitkaRoute<TenantController>(c => c.Style(HttpRequestStorage.Tenant.TenantName)).BuildUrlFromExpression()
                : "~/Content/Bootstrap/firma/default.theme.min.css";
        }
        
        public static DbGeometry GetDefaultBoundingBox()
        {
            return HttpRequestStorage.Tenant.GetTenantAttribute().DefaultBoundingBox;
        }

        public static int GetNumberOfTaxonomyTiers()
        {
            return HttpRequestStorage.Tenant.GetTenantAttribute().NumberOfTaxonomyTiersToUse;
        }

        public static int GetMinimumYear()
        {
            return HttpRequestStorage.Tenant.GetTenantAttribute().MinimumYear;
        }
    }
}
