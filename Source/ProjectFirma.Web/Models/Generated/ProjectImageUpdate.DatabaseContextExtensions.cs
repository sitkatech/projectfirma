//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectImageUpdate]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteProjectImageUpdate(this List<int> projectImageUpdateIDList)
        {
            if(projectImageUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectImageUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectImageUpdates.Where(x => projectImageUpdateIDList.Contains(x.ProjectImageUpdateID)));
            }
        }

        public static void DeleteProjectImageUpdate(this ICollection<ProjectImageUpdate> projectImageUpdatesToDelete)
        {
            if(projectImageUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectImageUpdates.RemoveRange(projectImageUpdatesToDelete);
            }
        }

        public static void DeleteProjectImageUpdate(this int projectImageUpdateID)
        {
            DeleteProjectImageUpdate(new List<int> { projectImageUpdateID });
        }

        public static void DeleteProjectImageUpdate(this ProjectImageUpdate projectImageUpdateToDelete)
        {
            DeleteProjectImageUpdate(new List<ProjectImageUpdate> { projectImageUpdateToDelete });
        }
    }
}