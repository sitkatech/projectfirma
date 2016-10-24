using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Images for Project Updates")]
    public class ProjectImageUpdateEditFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<ProjectImageUpdate>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<ProjectImageUpdate> _lakeTahoeInfoFeatureWithContextImpl;

        public ProjectImageUpdateEditFeature() : base(new List<Role> {Role.Normal, Role.Approver, Role.Admin, Role.TMPOManager})
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<ProjectImageUpdate>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectImageUpdate contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectImageUpdate contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            var project = contextModelObject.ProjectUpdateBatch.Project;
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