using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Project Updates")]
    public class ProjectUpdateManageFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<Project>
    {
        private readonly FirmaFeatureWithContextImpl<Project> _firmaFeatureWithContextImpl;

        public ProjectUpdateManageFeature()
            : base(new List<Role> { Role.Normal, Role.Approver, Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
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
            if (!hasPermissionByPerson || person.IsReadOnly())
            {
                return new PermissionCheckResult(string.Format("You don't have permission to Edit Project {0}", contextModelObject.DisplayName));
            }

            if (!contextModelObject.IsUpdatableViaProjectUpdateProcess)
            {
                return new PermissionCheckResult(string.Format("Project {0} is not updatable via the Project Update process", contextModelObject.DisplayName));
            }

            var projectIsEditableByUser = new ProjectUpdateAdminFeature().HasPermissionByPerson(person) || contextModelObject.IsMyProject(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult(string.Format("Project {0} is not editable by you.", contextModelObject.ProjectID));
            }

            return new PermissionCheckResult();
        }
    }
}