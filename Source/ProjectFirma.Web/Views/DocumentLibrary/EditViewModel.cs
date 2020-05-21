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
using LtInfo.Common;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.DocumentLibrary
{
    public class EditViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        public int DocumentLibraryID { get; set; }

        [DisplayName("Name")]
        [Required]
        [StringLength(ProjectFirmaModels.Models.DocumentLibrary.FieldLengths.DocumentLibraryName)]
        public string DocumentLibraryName { get; set; }
        
        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.DocumentLibrary.FieldLengths.DocumentLibraryDescription)]
        public string Description { get; set; }

        [DisplayName("Document Categories")]
        [Required]
        public List<int> DocumentCategoryIDs { get; set; }

        [DisplayName("About Menu Page(s) where this Library appears")]
        public List<int> CustomPageIDs { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
            CustomPageIDs = new List<int>();
        }

        public EditViewModel(ProjectFirmaModels.Models.DocumentLibrary documentLibrary)
        {
            DocumentLibraryID = documentLibrary.DocumentLibraryID;
            DocumentLibraryName = documentLibrary.DocumentLibraryName;
            Description = documentLibrary.DocumentLibraryDescription;
            DocumentCategoryIDs = documentLibrary.DocumentLibraryDocumentCategories.Select(x => x.DocumentCategoryID).ToList();
            CustomPageIDs = documentLibrary.CustomPages.Select(x => x.CustomPageID).ToList();
        }

        public void UpdateModel(ProjectFirmaModels.Models.DocumentLibrary documentLibrary, ICollection<DocumentLibraryDocumentCategory>  allDocumentLibraryDocumentCategories)
        {
            documentLibrary.DocumentLibraryName = DocumentLibraryName;
            documentLibrary.DocumentLibraryDescription = Description;

            var documentCategoriesUpdated = DocumentCategoryIDs.Select(x => new DocumentLibraryDocumentCategory(documentLibrary.DocumentLibraryID, x)).ToList();

            documentLibrary.DocumentLibraryDocumentCategories.Merge(documentCategoriesUpdated,
                allDocumentLibraryDocumentCategories,
                (x, y) => x.DocumentLibraryID == y.DocumentLibraryID && x.DocumentCategoryID == y.DocumentCategoryID, HttpRequestStorage.DatabaseEntities);

            var oldCustomPages = documentLibrary.CustomPages.Where(x => !CustomPageIDs.Contains(x.CustomPageID));
            foreach (var customPage in oldCustomPages)
            {
                customPage.DocumentLibraryID = null;
            }

            var customPages = HttpRequestStorage.DatabaseEntities.CustomPages.Where(x => CustomPageIDs.Contains(x.CustomPageID)).ToList();
            documentLibrary.CustomPages = customPages;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            var existingDocumentLibraries = HttpRequestStorage.DatabaseEntities.DocumentLibraries.ToList();
            if (!DocumentLibraryModelExtensions.IsDisplayNameUnique(existingDocumentLibraries, DocumentLibraryName, DocumentLibraryID))
            {
                validationResults.Add(new SitkaValidationResult<EditViewModel, string>("Document Library with the provided Name already exists.", x => x.DocumentLibraryName));
            }

            return validationResults;
        }
    }
}
