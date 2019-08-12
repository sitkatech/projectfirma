using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetByCostType
    {
        public int FundingSourceID { get; }
        public string FundingSourceName { get; }
        public List<ProjectCostTypeCalendarYearAmount> ProjectCostTypeCalendarYearAmounts { get; }
        public string DisplayCssClass { get; set; }

        private ProjectBudgetByCostType(int fundingSourceID, string fundingSourceName, List<ProjectCostTypeCalendarYearAmount> projectCostTypeCalendarYearAmounts, string displayCssClass)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            ProjectCostTypeCalendarYearAmounts = projectCostTypeCalendarYearAmounts;
            DisplayCssClass = displayCssClass;
        }

        public static List<ProjectBudgetByCostType> CreateFromProjectBudgets(List<ICostTypeFundingSourceBudgetAmount> costTypeFundingSourceBudgets, List<int> calendarYears)
        {
            var distinctFundingSources = costTypeFundingSourceBudgets.Select(x => x.FundingSource).Distinct(new HavePrimaryKeyComparer<FundingSource>());
            var distinctCostTypes = costTypeFundingSourceBudgets.Select(x => x.CostType).Distinct(new HavePrimaryKeyComparer<CostType>());
            var fundingSourcesCrossJoinCalendarYears =
                distinctFundingSources.Select(
                    x =>
                        new ProjectBudgetByCostType(x.FundingSourceID,
                            x.FundingSourceName,
                            distinctCostTypes.Select(
                                    y => new ProjectCostTypeCalendarYearAmount(y.CostTypeID, calendarYears.ToDictionary<int, int, decimal?>(calendarYear => calendarYear, calendarYear => null)))
                                .ToList(),
                            null)).ToList();

            foreach (var projectFundingSourceBudget in costTypeFundingSourceBudgets.GroupBy(x => x.FundingSource.FundingSourceID))
            {
                var currentFundingSource = fundingSourcesCrossJoinCalendarYears.Single(x => x.FundingSourceID == projectFundingSourceBudget.Key);
                foreach (var budgets in projectFundingSourceBudget.GroupBy(x => x.CostTypeID))
                {
                    var current = currentFundingSource.ProjectCostTypeCalendarYearAmounts.Single(x => x.CostTypeID == budgets.Key);
                    foreach (var calendarYear in calendarYears)
                    {
                        current.CalendarYearAmount[calendarYear] =
                            budgets.Where(x => x. CalendarYear == calendarYear).Select(x => x.GetMonetaryAmount(true) + x.GetMonetaryAmount(false)).Sum();
                    }
                }
            }
            return fundingSourcesCrossJoinCalendarYears;
        }

        public static ProjectBudgetByCostType Clone(ProjectBudgetByCostType fundingSourceCalendarYearBudgetToDiff, string displayCssClass)
        {
            return new ProjectBudgetByCostType(fundingSourceCalendarYearBudgetToDiff.FundingSourceID,
                fundingSourceCalendarYearBudgetToDiff.FundingSourceName,
                fundingSourceCalendarYearBudgetToDiff.ProjectCostTypeCalendarYearAmounts.Select(
                    x => new ProjectCostTypeCalendarYearAmount(x.CostTypeID, x.CalendarYearAmount.ToDictionary(y => y.Key, y => y.Value))).ToList(),
                displayCssClass);
        }
    }
}