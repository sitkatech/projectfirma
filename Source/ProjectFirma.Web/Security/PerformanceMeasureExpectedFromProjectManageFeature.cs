using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Performance Measure Expected Value From Project")]
    public class PerformanceMeasureExpectedFromProjectManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public PerformanceMeasureExpectedFromProjectManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.Normal })
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
                return new PermissionCheckResult(String.Format("You don't have permission to Edit Performance Measure Expected Values for Project {0}", contextModelObject.DisplayName));
            }

            // Admin can edit anything
            if (new AdminFeature().HasPermissionByPerson(person))
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

            return new PermissionCheckResult(String.Format("You don't have permission to Edit Performance Measure Expected Values for Project {0}", contextModelObject.DisplayName));
        }
    }
}