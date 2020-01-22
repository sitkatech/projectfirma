using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can access project timeline")]
    public class ProjectTimelineFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectTimelineFeature() : base(new List<Role> {Role.SitkaAdmin, Role.Admin, Role.ProjectSteward})
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureForProject(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }
        
        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            var timelinePermissionCheckResult = new ProjectStartUpdateWorkflowFeature().HasPermission(firmaSession, contextModelObject);

            if (timelinePermissionCheckResult.HasPermission)
            {
                return new PermissionCheckResult();
            }
            
            return new PermissionCheckResult("Does not have privilege to access the Project History Timeline");
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}