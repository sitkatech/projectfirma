/*-----------------------------------------------------------------------
<copyright file="BulkUploadFinancialsViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectBulkUpload
{
    public class ProjectBulkUploadViewModel : IValidatableObject
    {

        [Required]
        [DisplayName("Excel File to Upload")]
        [SitkaFileExtensions("xlsx")]
        public HttpPostedFileBase FileResourceDatum { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ProjectBulkUploadViewModel()
        {
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            FileResourceModelExtensions.ValidateFileSize(FileResourceDatum, errors, GeneralUtility.NameOf(() => FileResourceDatum));
            return errors;
        }
        
    }
}