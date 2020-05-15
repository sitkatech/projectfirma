/*-----------------------------------------------------------------------
<copyright file="NewDocumentViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.DocumentLibrary
{
    public class NewDocumentViewData
    {
        public readonly ProjectFirmaModels.Models.DocumentLibrary DocumentLibrary;
        public readonly string SupportedFileExtensionsCommaSeparated;
        public readonly List<string> SupportedFileExtensions;
        public readonly IEnumerable<SelectListItem> DocumentCategories;
        public readonly IEnumerable<SelectListItem> DocumentLibraries;

        public NewDocumentViewData(ProjectFirmaModels.Models.DocumentLibrary documentLibrary, IEnumerable<SelectListItem> documentCategories, IEnumerable<SelectListItem> documentLibraries)
        {
            DocumentLibrary = documentLibrary;
            DocumentCategories = documentCategories;
            DocumentLibraries = documentLibraries;
            SupportedFileExtensions = new List<string> { "pdf", "zip", "doc", "docx", "xls", "xlsx", "ppt", "pptx" };
            SupportedFileExtensionsCommaSeparated = string.Join(", ", SupportedFileExtensions.OrderBy(x => x));
        }
    }
}
