//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudget]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectBudget GetProjectBudget(this IQueryable<ProjectBudget> projectBudgets, int projectBudgetID)
        {
            var projectBudget = projectBudgets.SingleOrDefault(x => x.ProjectBudgetID == projectBudgetID);
            Check.RequireNotNullThrowNotFound(projectBudget, "ProjectBudget", projectBudgetID);
            return projectBudget;
        }

        public static void DeleteProjectBudget(this List<int> projectBudgetIDList)
        {
            if(projectBudgetIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectBudgets.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectBudgets.Where(x => projectBudgetIDList.Contains(x.ProjectBudgetID)));
            }
        }

        public static void DeleteProjectBudget(this ICollection<ProjectBudget> projectBudgetsToDelete)
        {
            if(projectBudgetsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectBudgets.RemoveRange(projectBudgetsToDelete);
            }
        }

        public static void DeleteProjectBudget(this int projectBudgetID)
        {
            DeleteProjectBudget(new List<int> { projectBudgetID });
        }

        public static void DeleteProjectBudget(this ProjectBudget projectBudgetToDelete)
        {
            DeleteProjectBudget(new List<ProjectBudget> { projectBudgetToDelete });
        }
    }
}