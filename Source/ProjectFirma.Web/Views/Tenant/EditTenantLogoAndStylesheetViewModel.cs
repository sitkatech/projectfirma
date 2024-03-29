﻿/*-----------------------------------------------------------------------
<copyright file="EditTenantLogoAndStylesheetViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Tenant
{
    public class EditTenantLogoAndStylesheetViewModel : FormViewModel
    {
        [Required]
        public int? TenantID { get; set; }

        [DisplayName("Tenant Banner Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantBannerLogoFileResourceData { get; set; }

        [DisplayName("Square Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantSquareLogoFileResourceData { get; set; }

        [DisplayName("Tenant Style Sheet")]
        [SitkaFileExtensions("css")]
        public HttpPostedFileBase TenantStyleSheetFileResourceData { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditTenantLogoAndStylesheetViewModel()
        {
        }

        public EditTenantLogoAndStylesheetViewModel(ProjectFirmaModels.Models.Tenant tenant)
        {
            TenantID = tenant.TenantID;
        }

        public void UpdateModel(TenantAttribute tenantAttribute, FirmaSession currentFirmaSession, DatabaseEntities databaseEntities)
        {
            if (TenantSquareLogoFileResourceData != null)
            {
                var attributeTenantSquareLogoFileResource = tenantAttribute.TenantSquareLogoFileResourceInfo;
                tenantAttribute.TenantSquareLogoFileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(TenantSquareLogoFileResourceData, currentFirmaSession);
                attributeTenantSquareLogoFileResource?.FileResourceData.Delete(databaseEntities);
                attributeTenantSquareLogoFileResource?.Delete(databaseEntities);
            }
            if (TenantBannerLogoFileResourceData != null)
            {
                var attributeTenantBannerLogoFileResource = tenantAttribute.TenantBannerLogoFileResourceInfo;
                tenantAttribute.TenantBannerLogoFileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(TenantBannerLogoFileResourceData, currentFirmaSession);
                attributeTenantBannerLogoFileResource?.FileResourceData.Delete(databaseEntities);
                attributeTenantBannerLogoFileResource?.Delete(databaseEntities);
            }

            if (TenantStyleSheetFileResourceData != null)
            {
                var attributeTenantStyleSheetFileResource = tenantAttribute.TenantStyleSheetFileResourceInfo;
                tenantAttribute.TenantStyleSheetFileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(TenantStyleSheetFileResourceData, currentFirmaSession);
                attributeTenantStyleSheetFileResource?.FileResourceData.Delete(databaseEntities);
                attributeTenantStyleSheetFileResource?.Delete(databaseEntities);
            }
        }
    }
}
