using System;
using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("View PerformanceMeasure Expected Value From Project")]
    public class EIPPerformanceMeasureExpectedFromProjectViewFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<Project>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<Project> _lakeTahoeInfoFeatureWithContextImpl;

        public EIPPerformanceMeasureExpectedFromProjectViewFeature() : base(new List<EIPRole> {EIPRole.Normal, EIPRole.Approver, EIPRole.Admin})
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<Project>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, Project contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
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

            return new PermissionCheckResult(String.Format("You don't have permission to View Performance Measure Expected Values for Project {0}", contextModelObject.DisplayName));
        }
    }
}