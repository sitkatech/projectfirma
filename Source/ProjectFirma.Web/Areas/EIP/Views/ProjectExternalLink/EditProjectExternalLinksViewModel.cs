using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectExternalLink
{
    public class EditProjectExternalLinksViewModel : FormViewModel
    {
        public List<ProjectExternalLinkSimple> ProjectExternalLinks { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectExternalLinksViewModel()
        {
        }

        public EditProjectExternalLinksViewModel(List<ProjectExternalLinkSimple> projectExternalLinks)
        {
            ProjectExternalLinks = projectExternalLinks;
        }

        public void UpdateModel(List<Models.ProjectExternalLink> currentProjectExternalLinks, IList<Models.ProjectExternalLink> allProjectExternalLinks)
        {
            var projectExternalLinksUpdated = new List<Models.ProjectExternalLink>();
            if (ProjectExternalLinks != null)
            {
                // Completely rebuild the list
                projectExternalLinksUpdated = ProjectExternalLinks.Select(x => new Models.ProjectExternalLink(x.ProjectID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList();
            }
            currentProjectExternalLinks.Merge(projectExternalLinksUpdated,
                allProjectExternalLinks,
                (x, y) => x.ProjectID == y.ProjectID && x.ExternalLinkLabel == y.ExternalLinkLabel && x.ExternalLinkUrl == y.ExternalLinkUrl);
        }

        public void UpdateModel(List<Models.ProjectExternalLinkUpdate> currentProjectExternalLinkUpdates, IList<Models.ProjectExternalLinkUpdate> allProjectExternalLinkUpdates)
        {
            var projectExternalLinksUpdated = new List<Models.ProjectExternalLinkUpdate>();
            if (ProjectExternalLinks != null)
            {
                // Completely rebuild the list
                projectExternalLinksUpdated = ProjectExternalLinks.Select(x => new Models.ProjectExternalLinkUpdate(x.ProjectID, x.ExternalLinkLabel, x.ExternalLinkUrl)).ToList();
            }
            currentProjectExternalLinkUpdates.Merge(projectExternalLinksUpdated,
                allProjectExternalLinkUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.ExternalLinkLabel == y.ExternalLinkLabel && x.ExternalLinkUrl == y.ExternalLinkUrl);
        }
    }
}