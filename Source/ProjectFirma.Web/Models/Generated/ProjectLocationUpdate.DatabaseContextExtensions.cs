//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationUpdate]
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
        public static ProjectLocationUpdate GetProjectLocationUpdate(this IQueryable<ProjectLocationUpdate> projectLocationUpdates, int projectLocationUpdateID)
        {
            var projectLocationUpdate = projectLocationUpdates.SingleOrDefault(x => x.ProjectLocationUpdateID == projectLocationUpdateID);
            Check.RequireNotNullThrowNotFound(projectLocationUpdate, "ProjectLocationUpdate", projectLocationUpdateID);
            return projectLocationUpdate;
        }

        public static void DeleteProjectLocationUpdate(this IQueryable<ProjectLocationUpdate> projectLocationUpdates, List<int> projectLocationUpdateIDList)
        {
            if(projectLocationUpdateIDList.Any())
            {
                projectLocationUpdates.Where(x => projectLocationUpdateIDList.Contains(x.ProjectLocationUpdateID)).Delete();
            }
        }

        public static void DeleteProjectLocationUpdate(this IQueryable<ProjectLocationUpdate> projectLocationUpdates, ICollection<ProjectLocationUpdate> projectLocationUpdatesToDelete)
        {
            if(projectLocationUpdatesToDelete.Any())
            {
                var projectLocationUpdateIDList = projectLocationUpdatesToDelete.Select(x => x.ProjectLocationUpdateID).ToList();
                projectLocationUpdates.Where(x => projectLocationUpdateIDList.Contains(x.ProjectLocationUpdateID)).Delete();
            }
        }

        public static void DeleteProjectLocationUpdate(this IQueryable<ProjectLocationUpdate> projectLocationUpdates, int projectLocationUpdateID)
        {
            DeleteProjectLocationUpdate(projectLocationUpdates, new List<int> { projectLocationUpdateID });
        }

        public static void DeleteProjectLocationUpdate(this IQueryable<ProjectLocationUpdate> projectLocationUpdates, ProjectLocationUpdate projectLocationUpdateToDelete)
        {
            DeleteProjectLocationUpdate(projectLocationUpdates, new List<ProjectLocationUpdate> { projectLocationUpdateToDelete });
        }
    }
}