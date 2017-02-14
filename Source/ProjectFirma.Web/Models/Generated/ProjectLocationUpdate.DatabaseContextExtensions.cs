//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationUpdate GetProjectLocationUpdate(this IQueryable<ProjectLocationUpdate> projectLocationUpdates, int projectLocationUpdateID)
        {
            var projectLocationUpdate = projectLocationUpdates.SingleOrDefault(x => x.ProjectLocationUpdateID == projectLocationUpdateID);
            Check.RequireNotNullThrowNotFound(projectLocationUpdate, "ProjectLocationUpdate", projectLocationUpdateID);
            return projectLocationUpdate;
        }

        public static void DeleteProjectLocationUpdate(this List<int> projectLocationUpdateIDList)
        {
            if(projectLocationUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectLocationUpdates.Where(x => projectLocationUpdateIDList.Contains(x.ProjectLocationUpdateID)));
            }
        }

        public static void DeleteProjectLocationUpdate(this ICollection<ProjectLocationUpdate> projectLocationUpdatesToDelete)
        {
            if(projectLocationUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationUpdates.RemoveRange(projectLocationUpdatesToDelete);
            }
        }

        public static void DeleteProjectLocationUpdate(this int projectLocationUpdateID)
        {
            DeleteProjectLocationUpdate(new List<int> { projectLocationUpdateID });
        }

        public static void DeleteProjectLocationUpdate(this ProjectLocationUpdate projectLocationUpdateToDelete)
        {
            DeleteProjectLocationUpdate(new List<ProjectLocationUpdate> { projectLocationUpdateToDelete });
        }
    }
}