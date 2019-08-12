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
        public List<ProjectCostTypeCalendarYearBudgetAmount> ProjectCostTypeCalendarYearBudgetAmounts { get; }
        public string DisplayCssClass { get; set; }

        private ProjectBudgetByCostType(int fundingSourceID, string fundingSourceName, List<ProjectCostTypeCalendarYearBudgetAmount> projectCostTypeCalendarYearBudgetAmounts, string displayCssClass)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            ProjectCostTypeCalendarYearBudgetAmounts = projectCostTypeCalendarYearBudgetAmounts;
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
                                    y => new ProjectCostTypeCalendarYearBudgetAmount(y.CostTypeID, calendarYears.Select(calendarYear => new CalendarYearBudgetAmounts(calendarYear, null, null)).ToList()))
                                .ToList(),
                            null)).ToList();

            foreach (var projectFundingSourceBudget in costTypeFundingSourceBudgets.GroupBy(x => x.FundingSource.FundingSourceID))
            {
                var currentFundingSource = fundingSourcesCrossJoinCalendarYears.Single(x => x.FundingSourceID == projectFundingSourceBudget.Key);
                foreach (var budgets in projectFundingSourceBudget.GroupBy(x => x.CostTypeID))
                {
                    var current = currentFundingSource.ProjectCostTypeCalendarYearBudgetAmounts.Single(x => x.CostTypeID == budgets.Key);
                    foreach (var calendarYear in calendarYears)
                    {
                        var a = current.CalendarYearBudgetAmounts.Single(x => x.CalendarYear == calendarYear);
                        a.SecuredAmount = budgets.Where(x => x.CalendarYear == calendarYear)
                            .Sum(x => x.GetMonetaryAmount(true));
                        a.TargetedAmount= budgets.Where(x => x.CalendarYear == calendarYear)
                            .Sum(x => x.GetMonetaryAmount(false));
                    }
                }
            }
            return fundingSourcesCrossJoinCalendarYears;
        }

        public static ProjectBudgetByCostType Clone(ProjectBudgetByCostType fundingSourceCalendarYearBudgetToDiff, string displayCssClass)
        {
            return new ProjectBudgetByCostType(fundingSourceCalendarYearBudgetToDiff.FundingSourceID,
                fundingSourceCalendarYearBudgetToDiff.FundingSourceName,
                fundingSourceCalendarYearBudgetToDiff.ProjectCostTypeCalendarYearBudgetAmounts.Select(
                    x => new ProjectCostTypeCalendarYearBudgetAmount(x.CostTypeID, x.CalendarYearBudgetAmounts.Select(y => new CalendarYearBudgetAmounts(y.CalendarYear, y.SecuredAmount, y.TargetedAmount)).ToList())).ToList(),
                displayCssClass);
        }
    }
    public class ProjectCostTypeCalendarYearBudgetAmount
    {
        public int CostTypeID { get; }
        public List<CalendarYearBudgetAmounts> CalendarYearBudgetAmounts { get; }


        public ProjectCostTypeCalendarYearBudgetAmount(int costTypeId, List<CalendarYearBudgetAmounts> calendarYearBudgetAmounts)
        {
            CostTypeID = costTypeId;
            CalendarYearBudgetAmounts = calendarYearBudgetAmounts;
        }
    }
}