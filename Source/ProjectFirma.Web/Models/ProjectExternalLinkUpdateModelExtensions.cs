using System.Linq;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectExternalLinkUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectExternalLinkUpdates =
                project.ProjectExternalLinks.Select(
                    pn => new ProjectExternalLinkUpdate(projectUpdateBatch, pn.ExternalLinkLabel, pn.ExternalLinkUrl)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectExternalLinksFromProjectUpdate =
                projectUpdateBatch.ProjectExternalLinkUpdates.Select(
                    x => new ProjectExternalLink(project.ProjectID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList();
            project.ProjectExternalLinks.Merge(projectExternalLinksFromProjectUpdate, (x, y) => x.ProjectID == y.ProjectID && x.ExternalLinkLabel == y.ExternalLinkLabel && x.ExternalLinkUrl == y.ExternalLinkUrl, databaseEntities);
        }
    }
}