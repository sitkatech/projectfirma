using System.Collections.Generic;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared.ProjectDocument
{
    public class ProjectDocumentsDetailViewData
    {
        public ProjectDocumentsDetailViewData(ProjectFirmaModels.Models.Project project, Person currentPerson)
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

        public ProjectDocumentsDetailViewData(ProjectFirmaModels.Models.Project project, Person currentPerson, bool showNewButton) : this(project, currentPerson)
        {
            UserHasProjectManagePermissions = UserHasProjectManagePermissions && showNewButton;
        }

        public List<EntityDocument> Documents { get; }
        public string AddDocumentUrl { get; }
        public string ProjectName { get; }
        public bool CanEditDocuments { get; }

        public ProjectDocumentsDetailViewData(List<EntityDocument> documents, string addDocumentUrl, string projectName, bool canEditDocuments)
        {
            Documents = documents;
            AddDocumentUrl = addDocumentUrl;
            ProjectName = projectName;
            CanEditDocuments = canEditDocuments;
            ShowDownload = true;
        }

        public ProjectDocumentsDetailViewData(List<EntityDocument> documents, string addDocumentUrl, string projectName,
            bool canEditDocuments, bool showDownload) : this(documents,addDocumentUrl,projectName,canEditDocuments)
        {
            ShowDownload = showDownload;
        }

        public bool ShowDownload { get; }

        public ProjectFirmaModels.Models.Project Project { get; set; }
        public string NewProjectDocumentUrl { get; set; }
        public UrlTemplate<int> EditProjectDocumentUrlTemplate { get; set; }
        public UrlTemplate<int> DeleteProjectDocumentUrlTemplate { get; set; }
        public Person CurrentPerson { get; set; }
        public bool UserHasProjectManagePermissions { get; set; }
        public ProjectDocumentEditAsAdminFeature ProjectDocumentEditAsAdminFeature { get; set; }
    }
}
