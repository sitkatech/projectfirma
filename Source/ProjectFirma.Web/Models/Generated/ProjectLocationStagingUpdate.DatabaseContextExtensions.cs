//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStagingUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationStagingUpdate GetProjectLocationStagingUpdate(this IQueryable<ProjectLocationStagingUpdate> projectLocationStagingUpdates, int projectLocationStagingUpdateID)
        {
            var projectLocationStagingUpdate = projectLocationStagingUpdates.SingleOrDefault(x => x.ProjectLocationStagingUpdateID == projectLocationStagingUpdateID);
            Check.RequireNotNullThrowNotFound(projectLocationStagingUpdate, "ProjectLocationStagingUpdate", projectLocationStagingUpdateID);
            return projectLocationStagingUpdate;
        }

        public static void DeleteProjectLocationStagingUpdate(this List<int> projectLocationStagingUpdateIDList)
        {
            if(projectLocationStagingUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationStagingUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectLocationStagingUpdates.Where(x => projectLocationStagingUpdateIDList.Contains(x.ProjectLocationStagingUpdateID)));
            }
        }

        public static void DeleteProjectLocationStagingUpdate(this ICollection<ProjectLocationStagingUpdate> projectLocationStagingUpdatesToDelete)
        {
            if(projectLocationStagingUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationStagingUpdates.RemoveRange(projectLocationStagingUpdatesToDelete);
            }
        }

        public static void DeleteProjectLocationStagingUpdate(this int projectLocationStagingUpdateID)
        {
            DeleteProjectLocationStagingUpdate(new List<int> { projectLocationStagingUpdateID });
        }

        public static void DeleteProjectLocationStagingUpdate(this ProjectLocationStagingUpdate projectLocationStagingUpdateToDelete)
        {
            DeleteProjectLocationStagingUpdate(new List<ProjectLocationStagingUpdate> { projectLocationStagingUpdateToDelete });
        }
    }
}