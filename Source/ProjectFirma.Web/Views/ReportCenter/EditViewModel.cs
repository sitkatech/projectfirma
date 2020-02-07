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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ReportCenter
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {

        public int ReportTemplateID { get; set; }

        public int? FileResourceID { get; set; }

        [Required]
        [StringLength(50)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportCenterReportTitle)]
        public string DisplayName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportCenterReportDescription)]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Model Type")]
        public int ReportTemplateModelTypeID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportCenterReportModel)]
        public int ReportTemplateModelID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportCenterReportFile)]
        [SitkaFileExtensions("docx")]
        public HttpPostedFileBase FileResourceData { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(ReportTemplate reportTemplate)
        {
            ReportTemplateID = reportTemplate.ReportTemplateID;
            DisplayName = reportTemplate.DisplayName;
            Description = reportTemplate.Description;
            FileResourceID = reportTemplate.FileResourceID;
            ReportTemplateModelTypeID = reportTemplate.ReportTemplateModelTypeID;
            ReportTemplateModelID = reportTemplate.ReportTemplateModelID;
        }

        public void UpdateModel(ReportTemplate reportTemplate, FileResource fileResource,
            FirmaSession currentFirmaSession, DatabaseEntities databaseEntities)
        {
            // updating parameters
            reportTemplate.DisplayName = DisplayName;
            reportTemplate.Description = Description;
            reportTemplate.FileResource = fileResource;
            reportTemplate.ReportTemplateModelTypeID = ReportTemplateModelTypeID;
            reportTemplate.ReportTemplateModelID = ReportTemplateModelID;
            
            var updateIsReplacingFileResourceData = FileResourceData != null && FileResourceID != null;
            if (updateIsReplacingFileResourceData)
            {
                // delete the old FileResource
                var oldFileResource =
                    HttpRequestStorage.DatabaseEntities.FileResources.First(x => x.FileResourceID == FileResourceID);
                oldFileResource.Delete(databaseEntities);
            }
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            var errors = new List<ValidationResult>();
            var reportTemplate = HttpRequestStorage.DatabaseEntities.ReportTemplates.SingleOrDefault(x => x.DisplayName == DisplayName);
            if (reportTemplate != null && reportTemplate.ReportTemplateID != ReportTemplateID)
            {
                errors.Add(new SitkaValidationResult<EditViewModel, string>("This Display Name is already being used by another Report Template", x => x.DisplayName));
            }

            if (FileResourceData == null && FileResourceID == null)
            {
                errors.Add(new SitkaValidationResult<EditViewModel, HttpPostedFileBase>("You cannot have a report template without a template file.", x => x.FileResourceData));
            }

            if (FileResourceData != null)
            {
                FileResourceModelExtensions.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            }
            return errors;
        }
    }
}
