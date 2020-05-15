/*-----------------------------------------------------------------------
<copyright file="NewDocumentViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.DocumentLibrary
{
    public class NewDocumentViewModel : EditDocumentViewModel
    {
        [Required]
        [DisplayName("Document File")]
        [SitkaFileExtensions("pdf|zip|doc|docx|xls|xlsx|ppt|pptx")]
        public HttpPostedFileBase FileResourceData { get; set; }

        public override void UpdateModel(ProjectFirmaModels.Models.DocumentLibraryDocument documentLibraryDocument, FirmaSession currentFirmaSession, ICollection<DocumentLibraryDocumentRole> allDocumentLibraryDocumentRoles)
        {
            documentLibraryDocument.FileResource = FileResourceModelExtensions.CreateNewFromHttpPostedFileAndSave(FileResourceData, currentFirmaSession);
            base.UpdateModel(documentLibraryDocument, currentFirmaSession, allDocumentLibraryDocumentRoles);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = GetValidationResults().ToList();
            var maxFileSize = (1024 ^ 2) * 50 * 1000; // 50 MB
            FileResourceModelExtensions.ValidateFileSize(FileResourceData, errors, GeneralUtility.NameOf(() => FileResourceData), maxFileSize);
            return errors;
        }
    }
}
