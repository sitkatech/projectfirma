//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudgetUpdate]
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
        public static ProjectBudgetUpdate GetProjectBudgetUpdate(this IQueryable<ProjectBudgetUpdate> projectBudgetUpdates, int projectBudgetUpdateID)
        {
            var projectBudgetUpdate = projectBudgetUpdates.SingleOrDefault(x => x.ProjectBudgetUpdateID == projectBudgetUpdateID);
            Check.RequireNotNullThrowNotFound(projectBudgetUpdate, "ProjectBudgetUpdate", projectBudgetUpdateID);
            return projectBudgetUpdate;
        }

        public static void DeleteProjectBudgetUpdate(this IQueryable<ProjectBudgetUpdate> projectBudgetUpdates, List<int> projectBudgetUpdateIDList)
        {
            if(projectBudgetUpdateIDList.Any())
            {
                projectBudgetUpdates.Where(x => projectBudgetUpdateIDList.Contains(x.ProjectBudgetUpdateID)).Delete();
            }
        }

        public static void DeleteProjectBudgetUpdate(this IQueryable<ProjectBudgetUpdate> projectBudgetUpdates, ICollection<ProjectBudgetUpdate> projectBudgetUpdatesToDelete)
        {
            if(projectBudgetUpdatesToDelete.Any())
            {
                var projectBudgetUpdateIDList = projectBudgetUpdatesToDelete.Select(x => x.ProjectBudgetUpdateID).ToList();
                projectBudgetUpdates.Where(x => projectBudgetUpdateIDList.Contains(x.ProjectBudgetUpdateID)).Delete();
            }
        }

        public static void DeleteProjectBudgetUpdate(this IQueryable<ProjectBudgetUpdate> projectBudgetUpdates, int projectBudgetUpdateID)
        {
            DeleteProjectBudgetUpdate(projectBudgetUpdates, new List<int> { projectBudgetUpdateID });
        }

        public static void DeleteProjectBudgetUpdate(this IQueryable<ProjectBudgetUpdate> projectBudgetUpdates, ProjectBudgetUpdate projectBudgetUpdateToDelete)
        {
            DeleteProjectBudgetUpdate(projectBudgetUpdates, new List<ProjectBudgetUpdate> { projectBudgetUpdateToDelete });
        }
    }
}