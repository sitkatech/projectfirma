/*-----------------------------------------------------------------------
<copyright file="EditBasicsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Tenant
{
    public class EditTenantLogoViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int? TenantID { get; set; }

       

        [DisplayName("Tenant Banner Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantBannerLogoFileResourceData { get; set; }

        [DisplayName("Square Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase TenantSquareLogoFileResourceData { get; set; }


        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EditTenantLogoViewModel()
        {
        }

        public EditTenantLogoViewModel(ProjectFirmaModels.Models.Tenant tenant)
        {
            TenantID = tenant.TenantID;
        }

        public void UpdateModel(TenantAttribute attribute, Person currentPerson)
        {
           
            if (TenantSquareLogoFileResourceData != null)
            {
                attribute.TenantSquareLogoFileResource?.DeleteFileResource();
                attribute.TenantSquareLogoFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(TenantSquareLogoFileResourceData, currentPerson);
            }
            if (TenantBannerLogoFileResourceData != null)
            {
                attribute.TenantBannerLogoFileResource?.DeleteFileResource();
                attribute.TenantBannerLogoFileResource = FileResource.CreateNewFromHttpPostedFileAndSave(TenantBannerLogoFileResourceData, currentPerson);
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            return errors;
        }
    }
}
