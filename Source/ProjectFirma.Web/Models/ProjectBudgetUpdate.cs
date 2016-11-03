using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectBudgetUpdate : IProjectBudgetAmount
    {
        public string ExpenditureAmountDisplay
        {
            get { return MonetaryAmount.ToStringCurrency(); }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.ProjectBudgetUpdates =
                projectUpdateBatch.Project.ProjectBudgets.Select(tpb => CloneProjectBudget(projectUpdateBatch, tpb, tpb.CalendarYear, tpb.MonetaryAmount)).ToList();
        }

        public static ProjectBudgetUpdate CloneProjectBudget(ProjectUpdateBatch projectUpdateBatch, IProjectBudgetAmount ProjectBudgetAmount, int calendarYear, decimal? budgetedAmount)
        {
            return new ProjectBudgetUpdate(projectUpdateBatch, ProjectBudgetAmount.FundingSource, ProjectBudgetAmount.ProjectCostType, calendarYear) {BudgetedAmount = budgetedAmount};
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectBudget> allProjectBudgets)
        {
            var project = projectUpdateBatch.Project;
            var ProjectBudgetsFromProjectUpdate =
                projectUpdateBatch.ProjectBudgetUpdates.Select(
                    x => new ProjectBudget(project.ProjectID, x.FundingSource.FundingSourceID, x.ProjectCostTypeID, x.CalendarYear, x.MonetaryAmount ?? 0)).ToList();
            project.ProjectBudgets.Merge(ProjectBudgetsFromProjectUpdate,
                allProjectBudgets,
                (x, y) =>
                    x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.FundingSourceID == y.FundingSourceID && x.ProjectCostTypeID == y.ProjectCostTypeID,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);
        }

        public decimal? MonetaryAmount
        {
            get { return BudgetedAmount ?? 0; }
        }

        public int ProjectID
        {
            get { return ProjectUpdateBatch.ProjectID; }
        }
    }
}