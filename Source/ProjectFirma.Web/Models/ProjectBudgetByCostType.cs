using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Protocols;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectBudgetByCostType
    {
        public int FundingSourceID { get; }
        public string FundingSourceName { get; }
        public List<ProjectCostTypeCalendarYearBudgetAmount> ProjectCostTypeCalendarYearBudgetAmounts { get; }
        public List<ProjectCostTypeBudgetAmount> ProjectCostTypeBudgetAmounts { get; }
        public string DisplayCssClass { get; set; }

        private ProjectBudgetByCostType(int fundingSourceID, string fundingSourceName, List<ProjectCostTypeCalendarYearBudgetAmount> projectCostTypeCalendarYearBudgetAmounts, string displayCssClass)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            ProjectCostTypeCalendarYearBudgetAmounts = projectCostTypeCalendarYearBudgetAmounts;
            DisplayCssClass = displayCssClass;
        }

        private ProjectBudgetByCostType(int fundingSourceID, string fundingSourceName, List<ProjectCostTypeBudgetAmount> projectCostTypeBudgetAmounts, string displayCssClass)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            ProjectCostTypeBudgetAmounts = projectCostTypeBudgetAmounts;
            DisplayCssClass = displayCssClass;
        }

        public static List<ProjectBudgetByCostType> CreateFromProjectBudgets(List<ICostTypeFundingSourceBudgetAmount> costTypeFundingSourceBudgets, List<int> calendarYears)
        {
            var distinctFundingSources = costTypeFundingSourceBudgets.Select(x => x.FundingSource).Distinct(new HavePrimaryKeyComparer<FundingSource>());
            var distinctCostTypeIDs = costTypeFundingSourceBudgets.Select(x => x.CostTypeID).Distinct();
            var distinctCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.Where(x => distinctCostTypeIDs.Contains(x.CostTypeID)).ToList();

            // Budget varies by Year
            if (calendarYears.Any())
            {
                var fundingSourcesCrossJoinCalendarYears =
                    distinctFundingSources.Select(
                        x =>
                            new ProjectBudgetByCostType(x.FundingSourceID,
                                x.FundingSourceName,
                                distinctCostTypes.Select(
                                    y => new ProjectCostTypeCalendarYearBudgetAmount(y.CostTypeID, calendarYears.Select(calendarYear => new CalendarYearBudgetAmounts(calendarYear, null, null)).ToList())).ToList(),
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
                            a.TargetedAmount = budgets.Where(x => x.CalendarYear == calendarYear)
                                .Sum(x => x.GetMonetaryAmount(false));
                        }
                    }
                }
                return fundingSourcesCrossJoinCalendarYears;

            }
            // Budget Same each year
            else
            {
                var fundingSourcesCrossJoin =
                    distinctFundingSources.Select(
                        x =>
                            new ProjectBudgetByCostType(x.FundingSourceID,
                                x.FundingSourceName,
                                distinctCostTypes.Select(
                                    y => new ProjectCostTypeBudgetAmount(y.CostTypeID, null, null)).ToList(), null)).ToList();
                foreach (var projectFundingSourceBudget in costTypeFundingSourceBudgets.GroupBy(x => x.FundingSource.FundingSourceID))
                {
                    var currentFundingSource = fundingSourcesCrossJoin.Single(x => x.FundingSourceID == projectFundingSourceBudget.Key);
                    foreach (var budget in projectFundingSourceBudget.GroupBy(x => x.CostTypeID))
                    {
                        var budgetValue = budget.Single(x => x.CostTypeID == budget.Key);
                        var currentCostType = currentFundingSource.ProjectCostTypeBudgetAmounts.Single(x => x.CostTypeID == budget.Key);
                        currentCostType.SecuredAmount = budgetValue.SecuredAmount;
                        currentCostType.TargetedAmount = budgetValue.TargetedAmount;

                    }
                }

                return fundingSourcesCrossJoin;
            }

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
    public class ProjectCostTypeBudgetAmount
    {
        public int CostTypeID { get; }
        public decimal? SecuredAmount { get; set; }
        public decimal? TargetedAmount { get; set; }


        public ProjectCostTypeBudgetAmount(int costTypeId, decimal? securedAmount, decimal? targetedAmount)
        {
            CostTypeID = costTypeId;
            SecuredAmount = securedAmount;
            TargetedAmount = targetedAmount;
        }
    }
}