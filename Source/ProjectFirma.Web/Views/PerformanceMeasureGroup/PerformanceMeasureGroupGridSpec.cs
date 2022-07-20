/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirmaModels.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.PerformanceMeasureGroup
{
    public class PerformanceMeasureGroupGridSpec : GridSpec<ProjectFirmaModels.Models.PerformanceMeasureGroup>
    {
        public PerformanceMeasureGroupGridSpec(FirmaSession currentFirmaSession)
        {
            var hasManagePermission = new PerformanceMeasureManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            if (hasManagePermission)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, !x.HasDependentObjects()), 30, DhtmlxGridColumnFilterType.None);
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditUrl(), $"Edit '{x.PerformanceMeasureGroupName}'", !x.HasDependentObjects()), 30, DhtmlxGridColumnFilterType.None);
            }
            Add(FieldDefinitionEnum.AccomplishmentGroup.ToType().ToGridHeaderString(),
                a => a.PerformanceMeasureGroupName,
                300,
                DhtmlxGridColumnFilterType.Text);
            Add($"# of {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}", a => a.PerformanceMeasures.Count, 300);
        }
    }
}
