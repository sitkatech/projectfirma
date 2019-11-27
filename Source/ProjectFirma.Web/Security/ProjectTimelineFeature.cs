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
            // if the person is a project steward but can't steward this project, deny them permissions to see it
            if (firmaSession.Role.RoleID == Role.ProjectSteward.RoleID && !firmaSession.Person.CanStewardProject(contextModelObject))
            {
                return new PermissionCheckResult("Does not have privelege to access this Project History Timeline");
            }

            if (HasPermissionByFirmaSession(firmaSession))
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