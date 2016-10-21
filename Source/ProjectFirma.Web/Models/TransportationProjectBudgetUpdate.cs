using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TransportationProjectBudgetUpdate : ITransportationProjectBudgetAmount
    {
        public string ExpenditureAmountDisplay
        {
            get { return MonetaryAmount.ToStringCurrency(); }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            projectUpdateBatch.TransportationProjectBudgetUpdates =
                projectUpdateBatch.Project.TransportationProjectBudgets.Select(tpb => CloneTransportationProjectBudget(projectUpdateBatch, tpb, tpb.CalendarYear, tpb.MonetaryAmount)).ToList();
        }

        public static TransportationProjectBudgetUpdate CloneTransportationProjectBudget(ProjectUpdateBatch projectUpdateBatch, ITransportationProjectBudgetAmount transportationProjectBudgetAmount, int calendarYear, decimal? budgetedAmount)
        {
            return new TransportationProjectBudgetUpdate(projectUpdateBatch, transportationProjectBudgetAmount.FundingSource, transportationProjectBudgetAmount.TransportationProjectCostType, calendarYear) {BudgetedAmount = budgetedAmount};
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<TransportationProjectBudget> allTransportationProjectBudgets)
        {
            var project = projectUpdateBatch.Project;
            var transportationProjectBudgetsFromProjectUpdate =
                projectUpdateBatch.TransportationProjectBudgetUpdates.Select(
                    x => new TransportationProjectBudget(project.ProjectID, x.FundingSource.FundingSourceID, x.TransportationProjectCostTypeID, x.CalendarYear, x.MonetaryAmount ?? 0)).ToList();
            project.TransportationProjectBudgets.Merge(transportationProjectBudgetsFromProjectUpdate,
                allTransportationProjectBudgets,
                (x, y) =>
                    x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.FundingSourceID == y.FundingSourceID && x.TransportationProjectCostTypeID == y.TransportationProjectCostTypeID,
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