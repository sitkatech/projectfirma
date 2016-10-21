using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class TransportationProjectBudgetAmount2
    {
        public readonly int FundingSourceID;
        public readonly string FundingSourceName;
        public readonly List<TransportationProjectCostTypeCalendarYearBudget> TransportationProjectCostTypeCalendarYearBudgets;
        public string DisplayCssClass;

        private TransportationProjectBudgetAmount2(int fundingSourceID, string fundingSourceName, List<TransportationProjectCostTypeCalendarYearBudget> transportationProjectCostTypeCalendarYearBudgets, string displayCssClass)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            TransportationProjectCostTypeCalendarYearBudgets = transportationProjectCostTypeCalendarYearBudgets;
            DisplayCssClass = displayCssClass;
        }

        public static List<TransportationProjectBudgetAmount2> CreateFromTransportationProjectBudgets(List<ITransportationProjectBudgetAmount> transportationProjectBudgetAmounts, List<int> calendarYears)
        {
            var distinctFundingSources = transportationProjectBudgetAmounts.Select(x => x.FundingSource).Distinct(new HavePrimaryKeyComparer<FundingSource>());
            var fundingSourcesCrossJoinCalendarYears =
                distinctFundingSources.Select(
                    x =>
                        new TransportationProjectBudgetAmount2(x.FundingSourceID,
                            x.FundingSourceName,
                            TransportationProjectCostType.All.Select(
                                y => new TransportationProjectCostTypeCalendarYearBudget(y, calendarYears.ToDictionary<int, int, decimal?>(calendarYear => calendarYear, calendarYear => null)))
                                .ToList(),
                            null)).ToList();

            foreach (var projectFundingSourceExpenditure in transportationProjectBudgetAmounts.GroupBy(x => x.FundingSourceID))
            {
                var currentFundingSource = fundingSourcesCrossJoinCalendarYears.Single(x => x.FundingSourceID == projectFundingSourceExpenditure.Key);
                foreach (var transportationProjectBudgetAmount in projectFundingSourceExpenditure.GroupBy(x => x.TransportationProjectCostTypeID))
                {
                    var current = currentFundingSource.TransportationProjectCostTypeCalendarYearBudgets.Single(x => x.TransportationProjectCostType.TransportationProjectCostTypeID == transportationProjectBudgetAmount.Key);
                    foreach (var calendarYear in calendarYears)
                    {
                        current.CalendarYearBudget[calendarYear] =
                            transportationProjectBudgetAmount.Where(fundingSourceExpenditure => fundingSourceExpenditure.CalendarYear == calendarYear).Select(x => x.MonetaryAmount).Sum();
                    }
                }
            }
            return fundingSourcesCrossJoinCalendarYears;
        }

        public static TransportationProjectBudgetAmount2 Clone(TransportationProjectBudgetAmount2 fundingSourceCalendarYearExpenditureToDiff, string displayCssClass)
        {
            return new TransportationProjectBudgetAmount2(fundingSourceCalendarYearExpenditureToDiff.FundingSourceID,
                fundingSourceCalendarYearExpenditureToDiff.FundingSourceName,
                fundingSourceCalendarYearExpenditureToDiff.TransportationProjectCostTypeCalendarYearBudgets.Select(
                    x => new TransportationProjectCostTypeCalendarYearBudget(x.TransportationProjectCostType, x.CalendarYearBudget.ToDictionary(y => y.Key, y => y.Value))).ToList(),
                displayCssClass);
        }
    }

    public class TransportationProjectCostTypeCalendarYearBudget
    {
        public readonly TransportationProjectCostType TransportationProjectCostType;
        public readonly Dictionary<int, decimal?> CalendarYearBudget;

        public TransportationProjectCostTypeCalendarYearBudget(TransportationProjectCostType transportationProjectCostType, Dictionary<int, decimal?> calendarYearBudget)
        {
            TransportationProjectCostType = transportationProjectCostType;
            CalendarYearBudget = calendarYearBudget;
        }
    }
}