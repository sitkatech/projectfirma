//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectExternalLinkUpdate]
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
        public static ProjectExternalLinkUpdate GetProjectExternalLinkUpdate(this IQueryable<ProjectExternalLinkUpdate> projectExternalLinkUpdates, int projectExternalLinkUpdateID)
        {
            var projectExternalLinkUpdate = projectExternalLinkUpdates.SingleOrDefault(x => x.ProjectExternalLinkUpdateID == projectExternalLinkUpdateID);
            Check.RequireNotNullThrowNotFound(projectExternalLinkUpdate, "ProjectExternalLinkUpdate", projectExternalLinkUpdateID);
            return projectExternalLinkUpdate;
        }

        public static void DeleteProjectExternalLinkUpdate(this IQueryable<ProjectExternalLinkUpdate> projectExternalLinkUpdates, List<int> projectExternalLinkUpdateIDList)
        {
            if(projectExternalLinkUpdateIDList.Any())
            {
                projectExternalLinkUpdates.Where(x => projectExternalLinkUpdateIDList.Contains(x.ProjectExternalLinkUpdateID)).Delete();
            }
        }

        public static void DeleteProjectExternalLinkUpdate(this IQueryable<ProjectExternalLinkUpdate> projectExternalLinkUpdates, ICollection<ProjectExternalLinkUpdate> projectExternalLinkUpdatesToDelete)
        {
            if(projectExternalLinkUpdatesToDelete.Any())
            {
                var projectExternalLinkUpdateIDList = projectExternalLinkUpdatesToDelete.Select(x => x.ProjectExternalLinkUpdateID).ToList();
                projectExternalLinkUpdates.Where(x => projectExternalLinkUpdateIDList.Contains(x.ProjectExternalLinkUpdateID)).Delete();
            }
        }

        public static void DeleteProjectExternalLinkUpdate(this IQueryable<ProjectExternalLinkUpdate> projectExternalLinkUpdates, int projectExternalLinkUpdateID)
        {
            DeleteProjectExternalLinkUpdate(projectExternalLinkUpdates, new List<int> { projectExternalLinkUpdateID });
        }

        public static void DeleteProjectExternalLinkUpdate(this IQueryable<ProjectExternalLinkUpdate> projectExternalLinkUpdates, ProjectExternalLinkUpdate projectExternalLinkUpdateToDelete)
        {
            DeleteProjectExternalLinkUpdate(projectExternalLinkUpdates, new List<ProjectExternalLinkUpdate> { projectExternalLinkUpdateToDelete });
        }
    }
}