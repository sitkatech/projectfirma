/*-----------------------------------------------------------------------
<copyright file="ProjectStageGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectStageCustomLabel
{
    public class ProjectStageGridSpec : GridSpec<ProjectStage>
    {
        public ProjectStageGridSpec(bool hasManagePermissions)
        {            
            if (hasManagePermissions)
            {
                Add(string.Empty,
                    a => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(a.GetEditUrl(), $"Edit {FieldDefinitionEnum.ProjectStage.ToType().GetFieldDefinitionLabel()} label"),
                    30, DhtmlxGridColumnFilterType.None);
            }

            Add("Custom Label", a => a.HasCustomLabel() ? a.GetProjectStageDisplayName() : string.Empty, 200);
            Add("Default Label", a => a.ProjectStageDisplayName, 200);
            Add("Has Custom Stage Name?", a => a.HasCustomLabel().ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Custom Color", a => a.HasCustomColor() ? a.GetProjectStageColor() : string.Empty, 200);
            Add("Default Color", a => a.ProjectStageColor, 200);
            Add("Has Custom Stage Color?", a => a.HasCustomColor().ToYesNo(), 100, DhtmlxGridColumnFilterType.SelectFilterStrict);

        }
    }
}
