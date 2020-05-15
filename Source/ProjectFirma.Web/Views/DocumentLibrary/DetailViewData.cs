/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.DocumentLibrary
{
    public class DetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.DocumentLibrary DocumentLibrary { get; }
        public bool UserHasDocumentLibraryManagePermissions { get; }
        public string EditDocumentLibraryUrl { get; }
        public string IndexUrl { get; }
        public DocumentLibraryDocumentGridSpec DocumentLibraryDocumentGridSpec { get; }
        public string DocumentLibraryDocumentsGridName { get; }
        public string DocumentLibraryDocumentGridDataUrl { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForDocumentLibrary;
        public string DocumentLibraryDisplayName { get; }
        public string DocumentLibraryPluralized { get; }
        public string NewDocumentUrl { get; }
        public string EditDocumentSortOrderUrl { get; }

        public DetailViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.DocumentLibrary documentLibrary) : base(currentFirmaSession)
        {
            DocumentLibrary = documentLibrary;
            PageTitle = documentLibrary.DocumentLibraryName;

            FieldDefinitionForDocumentLibrary = FieldDefinitionEnum.DocumentLibrary.ToType();
            DocumentLibraryDisplayName = FieldDefinitionForDocumentLibrary.GetFieldDefinitionLabel();
            DocumentLibraryPluralized = FieldDefinitionForDocumentLibrary.GetFieldDefinitionLabelPluralized();
            EntityName = DocumentLibraryDisplayName;

            UserHasDocumentLibraryManagePermissions = new DocumentLibraryManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            EditDocumentLibraryUrl = documentLibrary.GetEditUrl();

            IndexUrl = SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(c => c.Index());

            DocumentLibraryDocumentGridSpec = new DocumentLibraryDocumentGridSpec(UserHasDocumentLibraryManagePermissions)
            {
                ObjectNameSingular = "Document", 
                ObjectNamePlural = "Documents",
                SaveFiltersInCookie = true
            };
            DocumentLibraryDocumentsGridName = "documentLibraryDocumentsGrid";
            DocumentLibraryDocumentGridDataUrl = SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(c => c.DocumentLibraryDocumentGridJsonData(documentLibrary));

            NewDocumentUrl = SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(x => x.NewDocument(documentLibrary));
            EditDocumentSortOrderUrl = SitkaRoute<DocumentLibraryController>.BuildUrlFromExpression(x => x.EditDocumentSortOrder(documentLibrary));
        }
    }
}
