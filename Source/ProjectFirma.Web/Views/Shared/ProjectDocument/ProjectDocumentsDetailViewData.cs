using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared.ProjectDocument
{
    public class ProjectDocumentsDetailViewData
    {
        public ProjectDocumentsDetailViewData(Models.Project project, Person currentPerson)
        {
            Project = project;
            CurrentPerson = currentPerson;

            NewProjectDocumentUrl = SitkaRoute<ProjectDocumentController>.BuildUrlFromExpression(c => c.New(project));
            EditProjectDocumentUrlTemplate = new UrlTemplate<int>(
                SitkaRoute<ProjectDocumentController>.BuildUrlFromExpression(c => c.Edit(UrlTemplate.Parameter1Int)));
            DeleteProjectDocumentUrlTemplate = new UrlTemplate<int>(
                SitkaRoute<ProjectDocumentController>.BuildUrlFromExpression(c => c.Delete(UrlTemplate.Parameter1Int)));

            UserHasProjectManagePermissions =
                Project.IsProposal() ?
                new ProjectCreateFeature().HasPermission(currentPerson, project).HasPermission
                 : new ProjectEditAsAdminFeature().HasPermission(currentPerson, project).HasPermission;
            ProjectDocumentEditAsAdminFeature = new ProjectDocumentEditAsAdminFeature();
        }

        public ProjectDocumentsDetailViewData(Models.Project project, Person currentPerson, bool showNewButton) : this(project, currentPerson)
        {
            UserHasProjectManagePermissions = UserHasProjectManagePermissions && showNewButton;
        }

        public Models.Project Project { get; set; }
        public string NewProjectDocumentUrl { get; set; }
        public UrlTemplate<int> EditProjectDocumentUrlTemplate { get; set; }
        public UrlTemplate<int> DeleteProjectDocumentUrlTemplate { get; set; }
        public Models.Person CurrentPerson { get; set; }
        public bool UserHasProjectManagePermissions { get; set; }
        public ProjectDocumentEditAsAdminFeature ProjectDocumentEditAsAdminFeature { get; set; }
    }
}
