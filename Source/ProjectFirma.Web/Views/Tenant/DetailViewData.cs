/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Tenant
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Tenant Tenant { get; }
        public TenantAttribute TenantAttribute { get; }
        public string EditBasicsUrl { get; }
        public string EditBoundingBoxUrl { get; }
        public string EditClassificationSystemsUrl { get; }
        public string EditStylesheetUrl { get; }
        public string EditTenantLogoUrl { get; }
        public bool UserHasTenantManagePermissions { get; }
        public SitkaRoute<UserController> PrimaryContactRoute { get; }
        public string DeleteTenantStyleSheetFileResourceUrl { get; }
        public string DeleteTenantSquareLogoFileResourceUrl { get; }
        public string DeleteTenantBannerLogoFileResourceUrl { get; }
        public bool IsCurrentTenant { get; }
        public string EditBoundingBoxFormID { get; }
        public MapInitJson MapInitJson { get; }
        public DetailGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public bool UsesCostTypes { get; }
        public string CostTypes { get; }

        public DetailViewData(Person currentPerson, ProjectFirmaModels.Models.Tenant tenant, TenantAttribute tenantAttribute,
            string editBasicsUrl, string editBoundingBoxUrl, string deleteTenantStyleSheetFileResourceUrl,
            string deleteTenantSquareLogoFileResourceUrl, string deleteTenantBannerLogoFileResourceUrl,
            string editBoundingBoxFormID, MapInitJson mapInitJson, DetailGridSpec gridSpec, string gridName,
            string gridDataUrl, string editClassificationSystemsUrl, string editStylesheetUrl, string editTenantLogoUrl, string costTypes)
            : base(currentPerson)
        {
            PageTitle = tenantAttribute.TenantShortDisplayName;
            Tenant = tenant;
            TenantAttribute = tenantAttribute;
            EditBasicsUrl = editBasicsUrl;
            EditBoundingBoxUrl = editBoundingBoxUrl;
            EditClassificationSystemsUrl = editClassificationSystemsUrl;
            EditStylesheetUrl = editStylesheetUrl;
            EditTenantLogoUrl = editTenantLogoUrl;
            PrimaryContactRoute = tenantAttribute.PrimaryContactPerson != null ? new SitkaRoute<UserController>(c => c.Detail(tenantAttribute.PrimaryContactPersonID)) : null;
            UserHasTenantManagePermissions = new SitkaAdminFeature().HasPermissionByPerson(CurrentPerson);
            DeleteTenantStyleSheetFileResourceUrl = deleteTenantStyleSheetFileResourceUrl;
            DeleteTenantSquareLogoFileResourceUrl = deleteTenantSquareLogoFileResourceUrl;
            DeleteTenantBannerLogoFileResourceUrl = deleteTenantBannerLogoFileResourceUrl;
            IsCurrentTenant = HttpRequestStorage.Tenant == tenant;
            EditBoundingBoxFormID = editBoundingBoxFormID;
            MapInitJson = mapInitJson;
            GridSpec = gridSpec;
            GridName = gridName;
            GridDataUrl = gridDataUrl;
            UsesCostTypes = tenantAttribute.BudgetTypeID == BudgetType.AnnualBudgetByCostType.BudgetTypeID;
            CostTypes = costTypes;
        }
    }
}
