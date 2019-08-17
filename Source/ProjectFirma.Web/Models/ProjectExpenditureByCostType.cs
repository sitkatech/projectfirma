using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class ProjectExpenditureByCostType
    {
        public readonly int FundingSourceID;
        public readonly string FundingSourceName;
        public readonly List<ProjectCostTypeCalendarYearAmount> ProjectCostTypeCalendarYearAmounts;
        public string DisplayCssClass;

        private ProjectExpenditureByCostType(int fundingSourceID, string fundingSourceName, List<ProjectCostTypeCalendarYearAmount> projectCostTypeCalendarYearAmounts, string displayCssClass)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            ProjectCostTypeCalendarYearAmounts = projectCostTypeCalendarYearAmounts;
            DisplayCssClass = displayCssClass;
        }

        public static List<ProjectExpenditureByCostType> CreateFromProjectFundingSourceExpenditures(List<ICostTypeFundingSourceExpenditure> costTypeFundingSourceExpenditures, List<int> calendarYears)
        {
            var distinctFundingSources = costTypeFundingSourceExpenditures.Select(x => x.FundingSource).Distinct(new HavePrimaryKeyComparer<FundingSource>());
            var distinctCostTypeIDs = costTypeFundingSourceExpenditures.Select(x => x.CostTypeID).Distinct();
            var distinctCostTypes = HttpRequestStorage.DatabaseEntities.CostTypes.Where(x => distinctCostTypeIDs.Contains(x.CostTypeID)).ToList();
            var fundingSourcesCrossJoinCalendarYears =
                distinctFundingSources.Select(
                    x =>
                        new ProjectExpenditureByCostType(x.FundingSourceID,
                            x.FundingSourceName,
                            distinctCostTypes.Select(
                                    y => new ProjectCostTypeCalendarYearAmount(y, calendarYears.ToDictionary<int, int, decimal?>(calendarYear => calendarYear, calendarYear => null)))
                                .ToList(),
                            null)).ToList();

            foreach (var projectFundingSourceExpenditure in costTypeFundingSourceExpenditures.GroupBy(x => x.FundingSourceID))
            {
                var currentFundingSource = fundingSourcesCrossJoinCalendarYears.Single(x => x.FundingSourceID == projectFundingSourceExpenditure.Key);
                foreach (var expenditures in projectFundingSourceExpenditure.GroupBy(x => x.CostTypeID))
                {
                    var current = currentFundingSource.ProjectCostTypeCalendarYearAmounts.Single(x => x.CostType.CostTypeID == expenditures.Key);
                    foreach (var calendarYear in calendarYears)
                    {
                        current.CalendarYearAmount[calendarYear] =
                            expenditures.Where(fundingSourceExpenditure => fundingSourceExpenditure.CalendarYear == calendarYear).Select(x => x.GetMonetaryAmount()).Sum();
                    }
                }
            }
            return fundingSourcesCrossJoinCalendarYears;
        }

        public static ProjectExpenditureByCostType Clone(ProjectExpenditureByCostType fundingSourceCalendarYearExpenditureToDiff, string displayCssClass)
        {
            return new ProjectExpenditureByCostType(fundingSourceCalendarYearExpenditureToDiff.FundingSourceID,
                fundingSourceCalendarYearExpenditureToDiff.FundingSourceName,
                fundingSourceCalendarYearExpenditureToDiff.ProjectCostTypeCalendarYearAmounts.Select(
                    x => new ProjectCostTypeCalendarYearAmount(x.CostType, x.CalendarYearAmount.ToDictionary(y => y.Key, y => y.Value))).ToList(),
                displayCssClass);
        }
    }

    public class ProjectCostTypeCalendarYearAmount
    {
        public CostType CostType { get; }
        public Dictionary<int, decimal?> CalendarYearAmount { get; }

        public ProjectCostTypeCalendarYearAmount(CostType costType, Dictionary<int, decimal?> calendarYearAmount)
        {
            CostType = costType;
            CalendarYearAmount = calendarYearAmount;
        }
    }

}