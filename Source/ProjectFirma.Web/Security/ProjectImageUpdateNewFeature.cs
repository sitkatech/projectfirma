using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Add Images for Project Updates")]
    public class ProjectImageUpdateNewFeature : FirmaFeatureWithContext, IFirmaBaseFeatureWithContext<ProjectUpdateBatch>
    {
        private readonly FirmaFeatureWithContextImpl<ProjectUpdateBatch> _firmaFeatureWithContextImpl;

        public ProjectImageUpdateNewFeature()
            : base(new List<Role> { Role.Normal, Role.Approver, Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
        {
            _firmaFeatureWithContextImpl = new FirmaFeatureWithContextImpl<ProjectUpdateBatch>(this);
            ActionFilter = _firmaFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectUpdateBatch contextModelObject)
        {
            _firmaFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectUpdateBatch contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            var project = contextModelObject.Project;
            if (!hasPermissionByPerson || person.IsReadOnly())
            {
                return new PermissionCheckResult(string.Format("You don't have permission to Edit Project Image for Project {0}", project.DisplayName));
            }

            var projectIsEditableByUser = new AdminAndTMPOAdminFeature().HasPermissionByPerson(person) || project.IsMyProject(person);
            if (!projectIsEditableByUser)
            {
                return new PermissionCheckResult(string.Format("Project {0} is not editable by you.", project.ProjectID));
            }

            return new PermissionCheckResult();
        }
    }
}