/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureExpectedFromProjectViewFeature.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View PerformanceMeasure Expected Value From Project")]
    public class PerformanceMeasureExpectedFromProjectViewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public PerformanceMeasureExpectedFromProjectViewFeature()
            : base(new List<Role> { Role.Normal, Role.SitkaAdmin, Role.Admin })
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
            var userIsAnonymous = person == null || person.IsAnonymousUser;

            var projectIsDeferred = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.Deferred.ProjectStageID;
            var projectIsPlanningDesign = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.PlanningDesign.ProjectStageID;
            var projectIsImplementation = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.Implementation.ProjectStageID;
            var projectIsPostImplementation = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.PostImplementation.ProjectStageID;
            var projectIsCompleted = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.Completed.ProjectStageID;
            var projectIsTerminated = contextModelObject.ProjectStage.ProjectStageID == ProjectStage.Terminated.ProjectStageID;

            if (projectIsPlanningDesign)
            {
                // For these stages, any user at all is allowed
                return new PermissionCheckResult();
            }

            if (!userIsAnonymous && (projectIsImplementation || projectIsPostImplementation || projectIsCompleted || projectIsTerminated || projectIsDeferred))
            {
                // *any* logged-in user is allowed
                return new PermissionCheckResult();
            }

            return new PermissionCheckResult(
                $"You don't have permission to View {FieldDefinition.PerformanceMeasure.GetFieldDefinitionLabel()} {FieldDefinition.ExpectedValue.GetFieldDefinitionLabelPluralized()} for Project {contextModelObject.DisplayName}");
        }
    }
}
