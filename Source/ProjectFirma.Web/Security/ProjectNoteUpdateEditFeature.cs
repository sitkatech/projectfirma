using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Edit Notes for Project Updates")]
    public class ProjectNoteUpdateEditFeature : EIPFeatureWithContext, ILakeTahoeInfoBaseFeatureWithContext<ProjectNoteUpdate>
    {
        private readonly LakeTahoeInfoFeatureWithContextImpl<ProjectNoteUpdate> _lakeTahoeInfoFeatureWithContextImpl;

        public ProjectNoteUpdateEditFeature() : base(new List<EIPRole> {EIPRole.Normal, EIPRole.Approver, EIPRole.Admin, EIPRole.TMPOManager})
        {
            _lakeTahoeInfoFeatureWithContextImpl = new LakeTahoeInfoFeatureWithContextImpl<ProjectNoteUpdate>(this);
            ActionFilter = _lakeTahoeInfoFeatureWithContextImpl;
        }

        public void DemandPermission(Person person, ProjectNoteUpdate contextModelObject)
        {
            _lakeTahoeInfoFeatureWithContextImpl.DemandPermission(person, contextModelObject);
        }

        public PermissionCheckResult HasPermission(Person person, ProjectNoteUpdate contextModelObject)
        {
            var hasPermissionByPerson = HasPermissionByPerson(person);
            var project = contextModelObject.ProjectUpdateBatch.Project;
            if (!hasPermissionByPerson || person.IsReadOnly())
            {
                return new PermissionCheckResult(string.Format("You don't have permission to Edit Project Note for Project {0}", project.DisplayName));
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