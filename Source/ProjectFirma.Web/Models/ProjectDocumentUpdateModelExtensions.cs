using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class ProjectDocumentUpdateModelExtensions
    {
        public static string GetDeleteUrlImpl(ProjectDocumentUpdate projectDocumentUpdate)
        {
            return SitkaRoute<ProjectDocumentUpdateController>.BuildUrlFromExpression(x =>
                x.Delete(projectDocumentUpdate.ProjectDocumentUpdateID));
        }

        public static string GetEditUrlmpl(ProjectDocumentUpdate projectDocumentUpdate)
        {
            return SitkaRoute<ProjectDocumentUpdateController>.BuildUrlFromExpression(x =>
                x.Edit(projectDocumentUpdate.ProjectDocumentUpdateID));
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectUpdate.PrimaryContactPersonID = project.PrimaryContactPersonID;
            projectUpdateBatch.ProjectDocumentUpdates =
                project.ProjectDocuments.Select(
                    po => new ProjectDocumentUpdate(projectUpdateBatch, po.FileResource, po.DisplayName) { Description = po.Description}
                ).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectDocument> allProjectDocuments)
        {
            var project = projectUpdateBatch.Project;
            var projectDocumentsFromProjectUpdate =
                projectUpdateBatch.ProjectDocumentUpdates.Select(
                    x => new ProjectDocument(project.ProjectID, x.FileResourceID, x.DisplayName){Description = x.Description}).ToList();
            project.ProjectDocuments.Merge(projectDocumentsFromProjectUpdate, allProjectDocuments,
                (x, y) => x.ProjectID == y.ProjectID && x.FileResourceID == y.FileResourceID);
        }
    }
}