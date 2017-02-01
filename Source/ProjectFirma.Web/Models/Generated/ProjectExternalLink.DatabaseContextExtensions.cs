//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLink]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExternalLink GetProjectExternalLink(this IQueryable<ProjectExternalLink> projectExternalLinks, int projectExternalLinkID)
        {
            var projectExternalLink = projectExternalLinks.SingleOrDefault(x => x.ProjectExternalLinkID == projectExternalLinkID);
            Check.RequireNotNullThrowNotFound(projectExternalLink, "ProjectExternalLink", projectExternalLinkID);
            return projectExternalLink;
        }

        public static void DeleteProjectExternalLink(this IQueryable<ProjectExternalLink> projectExternalLinks, List<int> projectExternalLinkIDList)
        {
            if(projectExternalLinkIDList.Any())
            {
                projectExternalLinks.Where(x => projectExternalLinkIDList.Contains(x.ProjectExternalLinkID)).Delete();
            }
        }

        public static void DeleteProjectExternalLink(this IQueryable<ProjectExternalLink> projectExternalLinks, ICollection<ProjectExternalLink> projectExternalLinksToDelete)
        {
            if(projectExternalLinksToDelete.Any())
            {
                var projectExternalLinkIDList = projectExternalLinksToDelete.Select(x => x.ProjectExternalLinkID).ToList();
                projectExternalLinks.Where(x => projectExternalLinkIDList.Contains(x.ProjectExternalLinkID)).Delete();
            }
        }

        public static void DeleteProjectExternalLink(this IQueryable<ProjectExternalLink> projectExternalLinks, int projectExternalLinkID)
        {
            DeleteProjectExternalLink(projectExternalLinks, new List<int> { projectExternalLinkID });
        }

        public static void DeleteProjectExternalLink(this IQueryable<ProjectExternalLink> projectExternalLinks, ProjectExternalLink projectExternalLinkToDelete)
        {
            DeleteProjectExternalLink(projectExternalLinks, new List<ProjectExternalLink> { projectExternalLinkToDelete });
        }
    }
}