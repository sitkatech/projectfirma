/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActualFromProjectManageFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit {0} Actual Value From Project", FieldDefinitionEnum.PerformanceMeasure)]
    public class PerformanceMeasureActualFromProjectManageFeature : ProjectEditAsAdminFeature
    {
        public new PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            if (contextModelObject.ProjectStage == ProjectStage.PlanningDesign)
            {
                return new PermissionCheckResult(
                    $"Reported {FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabelPluralized()} are not relevant for projects in the Planning/Design stage.");
            }
            return base.HasPermission(firmaSession, contextModelObject);
        }
    }
}
