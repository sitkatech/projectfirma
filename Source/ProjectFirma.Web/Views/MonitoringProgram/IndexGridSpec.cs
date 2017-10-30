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

namespace ProjectFirma.Web.Views.MonitoringProgram
{
    public class IndexGridSpec : GridSpec<Models.MonitoringProgram>
    {
        public IndexGridSpec(bool hasDeletePermissions)
        {            
            if (hasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.DeleteUrl, true, !x.HasDependentObjects()), 30);
            }
            Add(Models.FieldDefinition.MonitoringProgram.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.DetailUrl, a.DisplayName), 450, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.MonitoringProgramUrl.ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.MonitoringProgramUrl, a.MonitoringProgramUrl), 200, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.MonitoringApproach.ToGridHeaderString(), a => a.MonitoringApproach, 450);
            Add("# of Partners", a => a.MonitoringProgramPartners.Count, 90);
        }
    }
}
