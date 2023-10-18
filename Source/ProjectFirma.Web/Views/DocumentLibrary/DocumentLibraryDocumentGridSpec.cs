﻿/*-----------------------------------------------------------------------
<copyright file="DocumentLibraryDocumentGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.DocumentLibrary
{
    public class DocumentLibraryDocumentGridSpec : GridSpec<DocumentLibraryDocument>
    {
        public DocumentLibraryDocumentGridSpec(bool hasDeletePermissions)
        {
            if (hasDeletePermissions)
            {
                Add("delete",
                    x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, true),
                    30,AgGridColumnFilterType.None);
                Add("edit",
                    x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditUrl(), $"Edit Document {x.DocumentTitle}", true),
                    30, AgGridColumnFilterType.None);
            }

            Add("Document Title", x => x.DocumentTitle, 150);
            Add("File Type", x => x.FileResourceInfo.OriginalFileExtension, 65, AgGridColumnFilterType.SelectFilterStrict);
            Add("Description", x => x.DocumentDescription, 600);
            Add("Document Category", x => x.DocumentCategory.DocumentCategoryDisplayName, 130);
            Add(FieldDefinitionEnum.DocumentLibrary.ToType().ToGridHeaderString(), x => x.DocumentLibrary.GetDisplayNameAsUrl(), 130);
            Add(FieldDefinitionEnum.DocumentLibraryDocumentViewableBy.ToType().ToGridHeaderString(), a => a.GetViewableRoles(), 200, AgGridColumnFilterType.Html);
            Add("Last Updated Date", x => x.LastUpdateDate, 120);
            Add("Last Updated By", x => x.LastUpdatePerson.GetFullNameFirstLast(), 130);
        }
    }
}
