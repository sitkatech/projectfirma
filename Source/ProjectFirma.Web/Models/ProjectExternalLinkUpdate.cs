using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectExternalLinkUpdate : IEntityExternalLink
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectExternalLinkUpdates =
                project.ProjectExternalLinks.Select(
                    pn => new ProjectExternalLinkUpdate(projectUpdateBatch, pn.ExternalLinkLabel, pn.ExternalLinkUrl)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectExternalLink> allProjectExternalLinks)
        {
            var project = projectUpdateBatch.Project;
            var projectExternalLinksFromProjectUpdate =
                projectUpdateBatch.ProjectExternalLinkUpdates.Select(
                    x => new ProjectExternalLink(project.ProjectID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList();
            project.ProjectExternalLinks.Merge(projectExternalLinksFromProjectUpdate, allProjectExternalLinks, (x, y) => x.ProjectID == y.ProjectID && x.ExternalLinkLabel == y.ExternalLinkLabel && x.ExternalLinkUrl == y.ExternalLinkUrl);
        }

        public HtmlString GetExternalLinkAsUrl()
        {
            return UrlTemplate.MakeHrefString(ExternalLinkUrl, ExternalLinkLabel, new Dictionary<string, string> { { "target", "_blank" } });
        }
    }
}