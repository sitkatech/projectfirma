using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Project Updates")]
    public class ProjectUpdateManageFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<Project>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<Project> _lakeTahoeInfoFeatureWithContextImpl;

        public ProjectUpdateManageFeature() : base(new List<EIPRole> {EIPRole.Normal, EIPRole.Approver, EIPRole.Admin, EIPRole.TMPOManager})
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