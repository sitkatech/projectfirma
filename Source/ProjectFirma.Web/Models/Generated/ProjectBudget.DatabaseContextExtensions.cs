//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectBudget]
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
        public static ProjectBudget GetProjectBudget(this IQueryable<ProjectBudget> projectBudgets, int projectBudgetID)
        {
            var projectBudget = projectBudgets.SingleOrDefault(x => x.ProjectBudgetID == projectBudgetID);
            Check.RequireNotNullThrowNotFound(projectBudget, "ProjectBudget", projectBudgetID);
            return projectBudget;
        }

        public static void DeleteProjectBudget(this IQueryable<ProjectBudget> projectBudgets, List<int> projectBudgetIDList)
        {
            if(projectBudgetIDList.Any())
            {
                projectBudgets.Where(x => projectBudgetIDList.Contains(x.ProjectBudgetID)).Delete();
            }
        }

        public static void DeleteProjectBudget(this IQueryable<ProjectBudget> projectBudgets, ICollection<ProjectBudget> projectBudgetsToDelete)
        {
            if(projectBudgetsToDelete.Any())
            {
                var projectBudgetIDList = projectBudgetsToDelete.Select(x => x.ProjectBudgetID).ToList();
                projectBudgets.Where(x => projectBudgetIDList.Contains(x.ProjectBudgetID)).Delete();
            }
        }

        public static void DeleteProjectBudget(this IQueryable<ProjectBudget> projectBudgets, int projectBudgetID)
        {
            DeleteProjectBudget(projectBudgets, new List<int> { projectBudgetID });
        }

        public static void DeleteProjectBudget(this IQueryable<ProjectBudget> projectBudgets, ProjectBudget projectBudgetToDelete)
        {
            DeleteProjectBudget(projectBudgets, new List<ProjectBudget> { projectBudgetToDelete });
        }
    }
}