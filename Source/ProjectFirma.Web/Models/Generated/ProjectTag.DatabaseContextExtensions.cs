//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectTag]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectTag GetProjectTag(this IQueryable<ProjectTag> projectTags, int projectTagID)
        {
            var projectTag = projectTags.SingleOrDefault(x => x.ProjectTagID == projectTagID);
            Check.RequireNotNullThrowNotFound(projectTag, "ProjectTag", projectTagID);
            return projectTag;
        }

        public static void DeleteProjectTag(this List<int> projectTagIDList)
        {
            if(projectTagIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectTags.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectTags.Where(x => projectTagIDList.Contains(x.ProjectTagID)));
            }
        }

        public static void DeleteProjectTag(this ICollection<ProjectTag> projectTagsToDelete)
        {
            if(projectTagsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectTags.RemoveRange(projectTagsToDelete);
            }
        }

        public static void DeleteProjectTag(this int projectTagID)
        {
            DeleteProjectTag(new List<int> { projectTagID });
        }

        public static void DeleteProjectTag(this ProjectTag projectTagToDelete)
        {
            DeleteProjectTag(new List<ProjectTag> { projectTagToDelete });
        }
    }
}