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
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.Tag
{
    public class IndexGridSpec : GridSpec<Models.Tag>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(Models.TagModelExtensions.GetDeleteUrl(x), true), 30);
            }

            Add(Models.FieldDefinition.TagName.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(Models.TagModelExtensions.GetDetailUrl(a), a.GetDisplayName()), 200, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.TagDescription.ToGridHeaderString(), a => a.TagDescription, 600);
            Add($"# of {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}", a => a.ProjectTags.Count, 65);
        }
    }
}
