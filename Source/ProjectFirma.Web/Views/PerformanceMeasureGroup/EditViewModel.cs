/*-----------------------------------------------------------------------
<copyright file="EditViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasureGroup
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int PerformanceMeasureGroupID { get; set; }

        [Required]
        [StringLength(ProjectFirmaModels.Models.PerformanceMeasureGroup.FieldLengths.PerformanceMeasureGroupName)]
        [DisplayName("Name")]
        public string PerformanceMeasureGroupName { get; set; }

        [DisplayName("Logo")]
        [SitkaFileExtensions("jpg|jpeg|gif|png")]
        public HttpPostedFileBase IconFileResourceData { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ProjectFirmaModels.Models.PerformanceMeasureGroup performanceMeasureGroup)
        {
            PerformanceMeasureGroupID = performanceMeasureGroup.PerformanceMeasureGroupID;
            PerformanceMeasureGroupName = performanceMeasureGroup.PerformanceMeasureGroupName;

        }

        public void UpdateModel(ProjectFirmaModels.Models.PerformanceMeasureGroup performanceMeasureGroup, FirmaSession currentFirmaSession, DatabaseEntities databaseEntities)
        {
            performanceMeasureGroup.PerformanceMeasureGroupName = PerformanceMeasureGroupName;

            if (IconFileResourceData != null)
            {
                var oldIconFileResourceInfo = performanceMeasureGroup.IconFileResourceInfo;
                performanceMeasureGroup.IconFileResourceInfo = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(IconFileResourceData, currentFirmaSession);
                oldIconFileResourceInfo?.FileResourceData.Delete(databaseEntities);
                oldIconFileResourceInfo?.Delete(databaseEntities);
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var performanceMeasureGroups = HttpRequestStorage.DatabaseEntities.PerformanceMeasureGroups.ToList();
            if (!PerformanceMeasureGroupModelExtensions.IsPerformanceMeasureGroupNameUnique(performanceMeasureGroups, PerformanceMeasureGroupName, PerformanceMeasureGroupID))
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>(FirmaValidationMessages.PerformanceMeasureGroupNameUnique, x => x.PerformanceMeasureGroupName));
            }
            return errors;
        }
    }
}
