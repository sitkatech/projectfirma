using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetAmount
    {
        public readonly int FundingSourceID;
        public readonly string FundingSourceName;
        public readonly string FundingSourceDisplayName;
        public readonly ProjectCostType ProjectCostType;
        public readonly int CalendarYear;
        public readonly decimal? MonetaryAmount;
        public readonly bool IsRealEntry;

        private ProjectBudgetAmount(int fundingSourceID, string fundingSourceName, string fundingSourceDisplayName, ProjectCostType projectCostType, int calendarYear, decimal? monetaryAmount, bool isRealEntry)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            FundingSourceDisplayName = fundingSourceDisplayName;
            ProjectCostType = projectCostType;
            CalendarYear = calendarYear;
            MonetaryAmount = monetaryAmount;
            IsRealEntry = isRealEntry;
        }

        public static List<ProjectBudgetAmount> CreateFromProjectBudgets(List<IProjectBudgetAmount> projectBudgetAmounts)
        {
            return
                projectBudgetAmounts.Select(
                    x =>
                        new ProjectBudgetAmount(x.FundingSourceID,
                            x.FundingSource.FundingSourceName,
                            x.FundingSource.DisplayNameAsUrl.ToString(),
                            x.ProjectCostType,
                            x.CalendarYear,
                            x.MonetaryAmount,
                            true)).ToList();
        }

        public static ProjectBudgetAmount CloneEmpty(ProjectBudgetAmount projectBudgetAmountToDiff)
        {
            return new ProjectBudgetAmount(projectBudgetAmountToDiff.FundingSourceID,
                projectBudgetAmountToDiff.FundingSourceName,
                string.Empty,
                projectBudgetAmountToDiff.ProjectCostType,
                projectBudgetAmountToDiff.CalendarYear,
                null,
                false);
        }
    }
}