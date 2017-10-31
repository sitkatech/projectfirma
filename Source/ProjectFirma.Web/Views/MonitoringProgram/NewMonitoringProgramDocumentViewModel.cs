/*-----------------------------------------------------------------------
<copyright file="NewMonitoringProgramDocumentViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Views.MonitoringProgram
{
    public class NewMonitoringProgramDocumentViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int MonitoringProgramDocumentID { get; set; }

        [Required]
        [DisplayName("Monitoring Program Document")]
        [SitkaFileExtensions("pdf")]
        public HttpPostedFileBase FileResourceData { get; set; }

        [StringLength(MonitoringProgramDocument.FieldLengths.DisplayName)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.MonitoringApproach)]
        [Required]
        public string DisplayName { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewMonitoringProgramDocumentViewModel()
        {
        }

        public NewMonitoringProgramDocumentViewModel(MonitoringProgramDocument monitoringProgramDocument)
        {
            DisplayName = monitoringProgramDocument.DisplayName;
            UploadDate = monitoringProgramDocument.UploadDate;
        }

        public void UpdateModel(MonitoringProgramDocument monitoringProgramDocument, Person currentPerson)
        {
            monitoringProgramDocument.DisplayName = DisplayName;
            monitoringProgramDocument.UploadDate = UploadDate;
            monitoringProgramDocument.FileResource = FileResource.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentPerson);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            FileResource.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData));
            return errors;
        }
    }
}
