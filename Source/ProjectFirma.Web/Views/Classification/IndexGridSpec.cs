/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class IndexGridSpec : GridSpec<Models.Classification>
    {
        public IndexGridSpec(bool hasDeletePermissions, Models.ClassificationSystem classificationSystem)
        {
            if (hasDeletePermissions)
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()),
                    30,DhtmlxGridColumnFilterType.None);
            }

            Add(classificationSystem.ToGridHeaderString(), a => a.GetDisplayNameAsUrl(), 250);
            Add(Models.FieldDefinition.ClassificationDescription.ToGridHeaderString("Description"), a => a.ClassificationDescription, 250);
            Add(Models.FieldDefinition.ClassificationDescription.ToGridHeaderString("Goal Statement"), a => a.GoalStatement, 250);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.ProjectClassifications.Count, 90);
            Add("Sort Order", a => a.ClassificationSortOrder + 1, 90);  // Most humans ordinarily expect lists to be 1-indexed instead of zero-indexed)
        }
    }
}
