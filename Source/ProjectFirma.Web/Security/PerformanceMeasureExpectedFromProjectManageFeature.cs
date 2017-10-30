/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureExpectedFromProjectManageFeature.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit {0} {1} From {2}", FieldDefinitionEnum.PerformanceMeasure, FieldDefinitionEnum.ExpectedValue, FieldDefinitionEnum.Project)]
    public class PerformanceMeasureExpectedFromProjectManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public PerformanceMeasureExpectedFromProjectManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.Normal, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<Project>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, Project contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            if (!hasPermissionByPerson)
            {
                return new PermissionCheckResult(
                    $"You don't have permission to Edit {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} {FieldDefinition.ExpectedValue.GetFieldDefinitionLabelPluralized()} for {FieldDefinition.Project.GetFieldDefinitionLabel()} {contextModelObject.DisplayName}");
            }

            // Admin can edit anything
            if (new FirmaAdminFeature().HasPermissionByPerson(person))
            {
                return new PermissionCheckResult();
            }

            // Beyond here, we are dealing with a logged-in user of some kind

            var projectIsDeferred = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.Deferred.ProjectStageID;
            var projectIsPlanningDesign = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.PlanningDesign.ProjectStageID;

            var isMyProject = contextModelObject.IsMyProject(person);

            if ((projectIsDeferred || projectIsPlanningDesign) && isMyProject)
            {
                return new PermissionCheckResult();
            }

            return new PermissionCheckResult(
                $"You don't have permission to Edit {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()} {FieldDefinition.ExpectedValue.GetFieldDefinitionLabelPluralized()} for {FieldDefinition.Project.GetFieldDefinitionLabel()} {contextModelObject.DisplayName}");
        }
    }
}
