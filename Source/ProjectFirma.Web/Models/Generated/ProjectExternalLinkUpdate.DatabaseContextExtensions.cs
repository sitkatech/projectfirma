//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLinkUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectExternalLinkUpdate GetProjectExternalLinkUpdate(this IQueryable<ProjectExternalLinkUpdate> projectExternalLinkUpdates, int projectExternalLinkUpdateID)
        {
            var projectExternalLinkUpdate = projectExternalLinkUpdates.SingleOrDefault(x => x.ProjectExternalLinkUpdateID == projectExternalLinkUpdateID);
            Check.RequireNotNullThrowNotFound(projectExternalLinkUpdate, "ProjectExternalLinkUpdate", projectExternalLinkUpdateID);
            return projectExternalLinkUpdate;
        }

        public static void DeleteProjectExternalLinkUpdate(this List<int> projectExternalLinkUpdateIDList)
        {
            if(projectExternalLinkUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExternalLinkUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectExternalLinkUpdates.Where(x => projectExternalLinkUpdateIDList.Contains(x.ProjectExternalLinkUpdateID)));
            }
        }

        public static void DeleteProjectExternalLinkUpdate(this ICollection<ProjectExternalLinkUpdate> projectExternalLinkUpdatesToDelete)
        {
            if(projectExternalLinkUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectExternalLinkUpdates.RemoveRange(projectExternalLinkUpdatesToDelete);
            }
        }

        public static void DeleteProjectExternalLinkUpdate(this int projectExternalLinkUpdateID)
        {
            DeleteProjectExternalLinkUpdate(new List<int> { projectExternalLinkUpdateID });
        }

        public static void DeleteProjectExternalLinkUpdate(this ProjectExternalLinkUpdate projectExternalLinkUpdateToDelete)
        {
            DeleteProjectExternalLinkUpdate(new List<ProjectExternalLinkUpdate> { projectExternalLinkUpdateToDelete });
        }
    }
}