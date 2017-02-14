//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudgetUpdate]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectBudgetUpdate GetProjectBudgetUpdate(this IQueryable<ProjectBudgetUpdate> projectBudgetUpdates, int projectBudgetUpdateID)
        {
            var projectBudgetUpdate = projectBudgetUpdates.SingleOrDefault(x => x.ProjectBudgetUpdateID == projectBudgetUpdateID);
            Check.RequireNotNullThrowNotFound(projectBudgetUpdate, "ProjectBudgetUpdate", projectBudgetUpdateID);
            return projectBudgetUpdate;
        }

        public static void DeleteProjectBudgetUpdate(this List<int> projectBudgetUpdateIDList)
        {
            if(projectBudgetUpdateIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectBudgetUpdates.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectBudgetUpdates.Where(x => projectBudgetUpdateIDList.Contains(x.ProjectBudgetUpdateID)));
            }
        }

        public static void DeleteProjectBudgetUpdate(this ICollection<ProjectBudgetUpdate> projectBudgetUpdatesToDelete)
        {
            if(projectBudgetUpdatesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectBudgetUpdates.RemoveRange(projectBudgetUpdatesToDelete);
            }
        }

        public static void DeleteProjectBudgetUpdate(this int projectBudgetUpdateID)
        {
            DeleteProjectBudgetUpdate(new List<int> { projectBudgetUpdateID });
        }

        public static void DeleteProjectBudgetUpdate(this ProjectBudgetUpdate projectBudgetUpdateToDelete)
        {
            DeleteProjectBudgetUpdate(new List<ProjectBudgetUpdate> { projectBudgetUpdateToDelete });
        }
    }
}