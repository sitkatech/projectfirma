//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectWatershedUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectWatershedUpdate GetProjectWatershedUpdate(this IQueryable<ProjectWatershedUpdate> projectWatershedUpdates, int projectWatershedUpdateID)
        {
            var projectWatershedUpdate = projectWatershedUpdates.SingleOrDefault(x => x.ProjectWatershedUpdateID == projectWatershedUpdateID);
            Check.RequireNotNullThrowNotFound(projectWatershedUpdate, "ProjectWatershedUpdate", projectWatershedUpdateID);
            return projectWatershedUpdate;
        }

        public static void DeleteProjectWatershedUpdate(this List<int> projectWatershedUpdateIDList)
        {
            if(projectWatershedUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectWatershedUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectWatershedUpdates.Where(x => projectWatershedUpdateIDList.Contains(x.ProjectWatershedUpdateID)));
            }
        }

        public static void DeleteProjectWatershedUpdate(this ICollection<ProjectWatershedUpdate> projectWatershedUpdatesToDelete)
        {
            if(projectWatershedUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectWatershedUpdates.RemoveRange(projectWatershedUpdatesToDelete);
            }
        }

        public static void DeleteProjectWatershedUpdate(this int projectWatershedUpdateID)
        {
            DeleteProjectWatershedUpdate(new List<int> { projectWatershedUpdateID });
        }

        public static void DeleteProjectWatershedUpdate(this ProjectWatershedUpdate projectWatershedUpdateToDelete)
        {
            DeleteProjectWatershedUpdate(new List<ProjectWatershedUpdate> { projectWatershedUpdateToDelete });
        }
    }
}