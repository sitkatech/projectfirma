/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
    public class IndexGridSpec : GridSpec<ProjectFirmaModels.Models.DocumentLibrary>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {
            if (hasDeletePermissions)
            {
                Add("delete",
                    x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, true),
                    30,AgGridColumnFilterType.None);
                Add("edit",
                    x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditUrl(), $"Edit Document Library {x.DocumentLibraryName}", true),
                    30, AgGridColumnFilterType.None);
            }

            Add(FieldDefinitionEnum.DocumentLibraryName.ToType().ToGridHeaderString(), x => new HtmlLinkObject(x.DocumentLibraryName,x.GetDetailUrl()).ToJsonObjectForAgGrid(), 250, AgGridColumnFilterType.HtmlLinkJson);
            Add("Document Category", x => x.GetDocumentCategoryDisplayNamesAsCommaDelimitedString(), 300);
            Add("Page Names", x => x.GetCustomPageDisplayNamesAsCommaDelimitedString(), 300);
            Add("# of Documents", x => x.DocumentLibraryDocuments.Count, 100);
        }
    }
}
