﻿/*-----------------------------------------------------------------------
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

namespace ProjectFirma.Web.Views.Reports
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {

        public int ReportTemplateID { get; set; }

        public int? FileResourceInfoID { get; set; }

        [Required]
        [StringLength(50)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportTitle)]
        public string DisplayName { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportDescription)]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Model Type")]
        public int ReportTemplateModelTypeID { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportModel)]
        public int ReportTemplateModelID { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ReportFile)]
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
            FileResourceInfoID = reportTemplate.FileResourceInfoID;
            ReportTemplateModelTypeID = reportTemplate.ReportTemplateModelTypeID;
            ReportTemplateModelID = reportTemplate.ReportTemplateModelID;
        }

        public void UpdateModel(ReportTemplate reportTemplate, FileResourceInfo fileResourceInfo,
            FirmaSession currentFirmaSession, DatabaseEntities databaseEntities)
        {
            // updating parameters
            reportTemplate.DisplayName = DisplayName;
            reportTemplate.Description = Description;
            reportTemplate.FileResourceInfo = fileResourceInfo;
            reportTemplate.ReportTemplateModelTypeID = ReportTemplateModelTypeID;
            reportTemplate.ReportTemplateModelID = ReportTemplateModelID;
            
            var updateIsReplacingFileResourceData = FileResourceData != null && FileResourceInfoID != null;
            if (updateIsReplacingFileResourceData)
            {
                // delete the old FileResourceInfo
                var oldFileResource =
                    HttpRequestStorage.DatabaseEntities.FileResourceInfos.First(x => x.FileResourceInfoID == FileResourceInfoID);
                oldFileResource.FileResourceData.Delete(databaseEntities);
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

            if (FileResourceData == null && FileResourceInfoID == null)
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
