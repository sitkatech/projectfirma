/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Classification
{
    public class IndexGridSpec : GridSpec<Models.Classification>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {
            if (hasDeletePermissions)
            {
                Add(string.Empty,
                    x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()),
                    30);
            }

            Add(Models.FieldDefinition.Classification.ToGridHeaderString(MultiTenantHelpers.GetClassificationDisplayName()), a => a.GetDisplayNameAsUrl(), 250);
            Add(Models.FieldDefinition.ClassificationDescription.ToGridHeaderString("Description"), a => a.ClassificationDescription, 250);
            Add(Models.FieldDefinition.ClassificationDescription.ToGridHeaderString("Goal Statement"), a => a.GoalStatement, 250);
            Add("# of Projects", a => a.ProjectClassifications.Count, 90);
        }
    }
}
