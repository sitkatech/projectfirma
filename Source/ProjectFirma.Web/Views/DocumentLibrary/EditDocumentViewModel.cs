/*-----------------------------------------------------------------------
<copyright file="EditDocumentViewModel.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirmaModels;

namespace ProjectFirma.Web.Views.DocumentLibrary
{
    public class EditDocumentViewModel : FormViewModel
    {
        public int DocumentLibraryID { get; set; }

        [Required]
        [DisplayName("Document Title")]
        [StringLength(ProjectFirmaModels.Models.DocumentLibraryDocument.FieldLengths.DocumentTitle)]
        public string DocumentTitle { get; set; }

        [DisplayName("Description")]
        [StringLength(ProjectFirmaModels.Models.DocumentLibraryDocument.FieldLengths.DocumentDescription)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Document Category")]
        public int DocumentCategoryID { get; set; }

        [DisplayName("Public")]
        public bool ViewableByAnonymous { get; set; }

        [DisplayName("Unassigned")]
        public bool ViewableByUnassigned { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.NormalUser)]
        public bool ViewableByNormal { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ProjectSteward)]
        public bool ViewableByProjectSteward { get; set; }

        [DisplayName("Administrator")]
        public bool ViewableByAdmin { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditDocumentViewModel()
        {
        }

        public EditDocumentViewModel(DocumentLibraryDocument documentLibraryDocument)
        {
            DocumentLibraryID = documentLibraryDocument.DocumentLibraryID;
            DocumentTitle = documentLibraryDocument.DocumentTitle;
            Description = documentLibraryDocument.DocumentDescription;
            DocumentCategoryID = documentLibraryDocument.DocumentCategoryID;

            ViewableByAnonymous = documentLibraryDocument.DocumentLibraryDocumentRoles.Any(x => x.RoleID == null);
            ViewableByUnassigned = documentLibraryDocument.DocumentLibraryDocumentRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Unassigned.RoleID);
            ViewableByNormal = documentLibraryDocument.DocumentLibraryDocumentRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Normal.RoleID);
            ViewableByProjectSteward = documentLibraryDocument.DocumentLibraryDocumentRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID);
            ViewableByAdmin = documentLibraryDocument.DocumentLibraryDocumentRoles.Any(x => x.RoleID == ProjectFirmaModels.Models.Role.Admin.RoleID);
        }

        public virtual void UpdateModel(DocumentLibraryDocument documentLibraryDocument, FirmaSession currentFirmaSession, ICollection<DocumentLibraryDocumentRole> allDocumentLibraryDocumentRoles)
        {
            documentLibraryDocument.DocumentTitle = DocumentTitle;
            documentLibraryDocument.DocumentDescription = Description;
            documentLibraryDocument.DocumentCategoryID = DocumentCategoryID;
            documentLibraryDocument.LastUpdateDate = DateTime.Now;
            documentLibraryDocument.LastUpdatePerson = currentFirmaSession.Person;

            var newDocumentLibraryDocumentRoles = new List<DocumentLibraryDocumentRole>();

            if (ViewableByAnonymous)
            {
                newDocumentLibraryDocumentRoles.Add(new DocumentLibraryDocumentRole(documentLibraryDocument.DocumentLibraryDocumentID));
            }
            if (ViewableByUnassigned)
            {
                newDocumentLibraryDocumentRoles.Add(new DocumentLibraryDocumentRole(documentLibraryDocument.DocumentLibraryDocumentID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Unassigned.RoleID
                });
            }
            if (ViewableByNormal)
            {
                newDocumentLibraryDocumentRoles.Add(new DocumentLibraryDocumentRole(documentLibraryDocument.DocumentLibraryDocumentID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Normal.RoleID
                });
            }
            if (ViewableByProjectSteward)
            {
                newDocumentLibraryDocumentRoles.Add(new DocumentLibraryDocumentRole(documentLibraryDocument.DocumentLibraryDocumentID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.ProjectSteward.RoleID
                });
            }
            if (ViewableByAdmin)
            {
                newDocumentLibraryDocumentRoles.Add(new DocumentLibraryDocumentRole(documentLibraryDocument.DocumentLibraryDocumentID)
                {
                    RoleID = ProjectFirmaModels.Models.Role.Admin.RoleID
                });
            }

            documentLibraryDocument.DocumentLibraryDocumentRoles.Merge(newDocumentLibraryDocumentRoles,
                allDocumentLibraryDocumentRoles,
                (x, y) => x.DocumentLibraryDocumentID == y.DocumentLibraryDocumentID && x.RoleID == y.RoleID,
                HttpRequestStorage.DatabaseEntities);
        }
    }
}
