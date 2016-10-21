using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class TransportationProjectBudgetAmount
    {
        public readonly int FundingSourceID;
        public readonly string FundingSourceName;
        public readonly string FundingSourceDisplayName;
        public readonly TransportationProjectCostType TransportationProjectCostType;
        public readonly int CalendarYear;
        public readonly decimal? MonetaryAmount;
        public readonly bool IsRealEntry;

        private TransportationProjectBudgetAmount(int fundingSourceID, string fundingSourceName, string fundingSourceDisplayName, TransportationProjectCostType transportationProjectCostType, int calendarYear, decimal? monetaryAmount, bool isRealEntry)
        {
            FundingSourceID = fundingSourceID;
            FundingSourceName = fundingSourceName;
            FundingSourceDisplayName = fundingSourceDisplayName;
            TransportationProjectCostType = transportationProjectCostType;
            CalendarYear = calendarYear;
            MonetaryAmount = monetaryAmount;
            IsRealEntry = isRealEntry;
        }

        public static List<TransportationProjectBudgetAmount> CreateFromTransportationProjectBudgets(List<ITransportationProjectBudgetAmount> transportationProjectBudgetAmounts)
        {
            return
                transportationProjectBudgetAmounts.Select(
                    x =>
                        new TransportationProjectBudgetAmount(x.FundingSourceID,
                            x.FundingSource.FundingSourceName,
                            x.FundingSource.DisplayNameAsUrl.ToString(),
                            x.TransportationProjectCostType,
                            x.CalendarYear,
                            x.MonetaryAmount,
                            true)).ToList();
        }

        public static TransportationProjectBudgetAmount CloneEmpty(TransportationProjectBudgetAmount transportationProjectBudgetAmountToDiff)
        {
            return new TransportationProjectBudgetAmount(transportationProjectBudgetAmountToDiff.FundingSourceID,
                transportationProjectBudgetAmountToDiff.FundingSourceName,
                string.Empty,
                transportationProjectBudgetAmountToDiff.TransportationProjectCostType,
                transportationProjectBudgetAmountToDiff.CalendarYear,
                null,
                false);
        }
    }
}