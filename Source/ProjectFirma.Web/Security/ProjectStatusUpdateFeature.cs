using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can add, edit, or delete project status entries")]
    public class ProjectStatusUpdateFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectStatusUpdateFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.ProjectSteward })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureForProject(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public PermissionCheckResult HasPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            // if the person is a project steward but can't steward this project, deny them permissions to see it
            if (firmaSession.Role.RoleID == Role.ProjectSteward.RoleID && !firmaSession.Person.CanStewardProject(contextModelObject))
            {
                return new PermissionCheckResult("Does not have privilege to add, edit, or delete project statuses");
            }

            if (HasPermissionByFirmaSession(firmaSession))
            {
                return new PermissionCheckResult();
            }
            return new PermissionCheckResult("Does not have privilege to add, edit, or delete project statuses");
        }

        public void DemandPermission(FirmaSession firmaSession, Project contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(firmaSession, contextModelObject);
        }
    }
}