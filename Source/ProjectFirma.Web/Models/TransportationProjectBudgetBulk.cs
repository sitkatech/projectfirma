using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Models
{
    public class TransportationProjectBudgetBulk
    {
        public int ProjectID { get; set; }
        public int FundingSourceID { get; set; }
        public int TransportationProjectCostTypeID { get; set; }
        public List<CalendarYearMonetaryAmount> CalendarYearBudgets { get; set; }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public TransportationProjectBudgetBulk()
        {
        }

        public TransportationProjectBudgetBulk(int projectID,
            int fundingSourceID,
            int transportationProjectCostTypeID,
            List<ITransportationProjectBudgetAmount> transportationProjectBudgets,
            IEnumerable<int> calendarYearsToPopulate)
        {
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            TransportationProjectCostTypeID = transportationProjectCostTypeID;
            CalendarYearBudgets = new List<CalendarYearMonetaryAmount>();
            var transportationProjectBudgetsForThisProjectFundingSourceCostType =
                transportationProjectBudgets.Where(x => x.ProjectID == projectID && x.FundingSourceID == fundingSourceID && x.TransportationProjectCostTypeID == transportationProjectCostTypeID)
                    .ToList();
            Add(transportationProjectBudgetsForThisProjectFundingSourceCostType);
            // we need to fill in the other calendar years with blanks
            var usedCalendarYears = transportationProjectBudgetsForThisProjectFundingSourceCostType.Select(x => x.CalendarYear).ToList();
            CalendarYearBudgets.AddRange(calendarYearsToPopulate.Where(x => !usedCalendarYears.Contains(x)).ToList().Select(x => new CalendarYearMonetaryAmount(x, null)));
        }

        public static List<TransportationProjectBudgetBulk> MakeFromList(List<ITransportationProjectBudgetAmount> transportationProjectBudgets, List<int> calendarYearsToPopulate)
        {
            var distinctProjects = transportationProjectBudgets.Select(x => x.ProjectID).Distinct().ToList();
            var distinctFundingSources = transportationProjectBudgets.Select(x => x.FundingSourceID).Distinct().ToList();
            var allPossibleProjectFundingSourceCostTypes = new List<Tuple<int, int, int>>();
            foreach (var projectID in distinctProjects)
            {
                foreach (var fundingSourceID in distinctFundingSources)
                {
                    allPossibleProjectFundingSourceCostTypes.AddRange(
                        TransportationProjectCostType.All.Select(
                            transportationProjectCostType => new Tuple<int, int, int>(projectID, fundingSourceID, transportationProjectCostType.TransportationProjectCostTypeID)));
                }
            }
            var transportationProjectBudgetBulks =
                allPossibleProjectFundingSourceCostTypes.Select(
                    grouping => new TransportationProjectBudgetBulk(grouping.Item1, grouping.Item2, grouping.Item3, transportationProjectBudgets, calendarYearsToPopulate)).ToList();
            return transportationProjectBudgetBulks;
        }

        public void Add(List<ITransportationProjectBudgetAmount> transportationProjectBudgets)
        {
            transportationProjectBudgets.ForEach(Add);
        }

        public void Add(ITransportationProjectBudgetAmount transportationProjectBudget)
        {
            Check.Require(
                transportationProjectBudget.ProjectID == ProjectID && transportationProjectBudget.FundingSourceID == FundingSourceID &&
                transportationProjectBudget.TransportationProjectCostTypeID == TransportationProjectCostTypeID,
                "Row doesn't align with collection mismatch ProjectID and FundingSourceID and TransportationCostTypeID");
            CalendarYearBudgets.Add(new CalendarYearMonetaryAmount(transportationProjectBudget.CalendarYear, transportationProjectBudget.MonetaryAmount));
        }

        public List<TransportationProjectBudget> ToTransportationProjectBudgets()
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearBudgets.Where(x => x.MonetaryAmount.HasValue)
                    .Select(x => new TransportationProjectBudget(ProjectID, FundingSourceID, TransportationProjectCostTypeID, x.CalendarYear, x.MonetaryAmount.Value))
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }

        public List<TransportationProjectBudgetUpdate> ToTransportationProjectBudgetUpdates(ProjectUpdateBatch projectUpdateBatch)
        {
            // ReSharper disable PossibleInvalidOperationException
            return
                CalendarYearBudgets.Where(x => x.MonetaryAmount.HasValue)
                    .Select(
                        x =>
                            new TransportationProjectBudgetUpdate(projectUpdateBatch.ProjectUpdateBatchID, FundingSourceID, TransportationProjectCostTypeID, x.CalendarYear)
                            {
                                BudgetedAmount = x.MonetaryAmount
                            })
                    .ToList();
            // ReSharper restore PossibleInvalidOperationException
        }
    }
}