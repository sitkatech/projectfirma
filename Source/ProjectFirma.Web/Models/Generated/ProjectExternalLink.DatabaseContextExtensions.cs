//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLink]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteProjectExternalLink(this List<int> projectExternalLinkIDList)
        {
            if(projectExternalLinkIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExternalLinks.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectExternalLinks.Where(x => projectExternalLinkIDList.Contains(x.ProjectExternalLinkID)));
            }
        }

        public static void DeleteProjectExternalLink(this ICollection<ProjectExternalLink> projectExternalLinksToDelete)
        {
            if(projectExternalLinksToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExternalLinks.RemoveRange(projectExternalLinksToDelete);
            }
        }

        public static void DeleteProjectExternalLink(this int projectExternalLinkID)
        {
            DeleteProjectExternalLink(new List<int> { projectExternalLinkID });
        }

        public static void DeleteProjectExternalLink(this ProjectExternalLink projectExternalLinkToDelete)
        {
            DeleteProjectExternalLink(new List<ProjectExternalLink> { projectExternalLinkToDelete });
        }
    }
}