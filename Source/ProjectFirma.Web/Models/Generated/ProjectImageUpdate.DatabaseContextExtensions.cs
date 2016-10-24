//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImageUpdate]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectImageUpdate GetProjectImageUpdate(this IQueryable<ProjectImageUpdate> projectImageUpdates, int projectImageUpdateID)
        {
            var projectImageUpdate = projectImageUpdates.SingleOrDefault(x => x.ProjectImageUpdateID == projectImageUpdateID);
            Check.RequireNotNullThrowNotFound(projectImageUpdate, "ProjectImageUpdate", projectImageUpdateID);
            return projectImageUpdate;
        }

        public static void DeleteProjectImageUpdate(this IQueryable<ProjectImageUpdate> projectImageUpdates, List<int> projectImageUpdateIDList)
        {
            if(projectImageUpdateIDList.Any())
            {
                projectImageUpdates.Where(x => projectImageUpdateIDList.Contains(x.ProjectImageUpdateID)).Delete();
            }
        }

        public static void DeleteProjectImageUpdate(this IQueryable<ProjectImageUpdate> projectImageUpdates, ICollection<ProjectImageUpdate> projectImageUpdatesToDelete)
        {
            if(projectImageUpdatesToDelete.Any())
            {
                var projectImageUpdateIDList = projectImageUpdatesToDelete.Select(x => x.ProjectImageUpdateID).ToList();
                projectImageUpdates.Where(x => projectImageUpdateIDList.Contains(x.ProjectImageUpdateID)).Delete();
            }
        }

        public static void DeleteProjectImageUpdate(this IQueryable<ProjectImageUpdate> projectImageUpdates, int projectImageUpdateID)
        {
            DeleteProjectImageUpdate(projectImageUpdates, new List<int> { projectImageUpdateID });
        }

        public static void DeleteProjectImageUpdate(this IQueryable<ProjectImageUpdate> projectImageUpdates, ProjectImageUpdate projectImageUpdateToDelete)
        {
            DeleteProjectImageUpdate(projectImageUpdates, new List<ProjectImageUpdate> { projectImageUpdateToDelete });
        }
    }
}