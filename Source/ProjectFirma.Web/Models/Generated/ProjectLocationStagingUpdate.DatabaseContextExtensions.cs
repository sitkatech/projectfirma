//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationStagingUpdate]
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
        public static ProjectLocationStagingUpdate GetProjectLocationStagingUpdate(this IQueryable<ProjectLocationStagingUpdate> projectLocationStagingUpdates, int projectLocationStagingUpdateID)
        {
            var projectLocationStagingUpdate = projectLocationStagingUpdates.SingleOrDefault(x => x.ProjectLocationStagingUpdateID == projectLocationStagingUpdateID);
            Check.RequireNotNullThrowNotFound(projectLocationStagingUpdate, "ProjectLocationStagingUpdate", projectLocationStagingUpdateID);
            return projectLocationStagingUpdate;
        }

        public static void DeleteProjectLocationStagingUpdate(this IQueryable<ProjectLocationStagingUpdate> projectLocationStagingUpdates, List<int> projectLocationStagingUpdateIDList)
        {
            if(projectLocationStagingUpdateIDList.Any())
            {
                projectLocationStagingUpdates.Where(x => projectLocationStagingUpdateIDList.Contains(x.ProjectLocationStagingUpdateID)).Delete();
            }
        }

        public static void DeleteProjectLocationStagingUpdate(this IQueryable<ProjectLocationStagingUpdate> projectLocationStagingUpdates, ICollection<ProjectLocationStagingUpdate> projectLocationStagingUpdatesToDelete)
        {
            if(projectLocationStagingUpdatesToDelete.Any())
            {
                var projectLocationStagingUpdateIDList = projectLocationStagingUpdatesToDelete.Select(x => x.ProjectLocationStagingUpdateID).ToList();
                projectLocationStagingUpdates.Where(x => projectLocationStagingUpdateIDList.Contains(x.ProjectLocationStagingUpdateID)).Delete();
            }
        }

        public static void DeleteProjectLocationStagingUpdate(this IQueryable<ProjectLocationStagingUpdate> projectLocationStagingUpdates, int projectLocationStagingUpdateID)
        {
            DeleteProjectLocationStagingUpdate(projectLocationStagingUpdates, new List<int> { projectLocationStagingUpdateID });
        }

        public static void DeleteProjectLocationStagingUpdate(this IQueryable<ProjectLocationStagingUpdate> projectLocationStagingUpdates, ProjectLocationStagingUpdate projectLocationStagingUpdateToDelete)
        {
            DeleteProjectLocationStagingUpdate(projectLocationStagingUpdates, new List<ProjectLocationStagingUpdate> { projectLocationStagingUpdateToDelete });
        }
    }
}