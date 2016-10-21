using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationProjectBudget
{
    public class EditTransportationProjectBudgetsViewModel : FormViewModel
    {
        public List<TransportationProjectBudgetBulk> TransportationProjectBudgets { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTransportationProjectBudgetsViewModel()
        {
        }

        public EditTransportationProjectBudgetsViewModel(List<Models.TransportationProjectBudget> transportationProjectBudgets, List<int> calendarYearsToPopulate)
        {
            TransportationProjectBudgets = TransportationProjectBudgetBulk.MakeFromList(new List<ITransportationProjectBudgetAmount>(transportationProjectBudgets), calendarYearsToPopulate);
        }

        public void UpdateModel(List<Models.TransportationProjectBudget> currentTransportationProjectBudgets, IList<Models.TransportationProjectBudget> allTransportationProjectBudgets)
        {
            var transportationProjectBudgetsUpdated = new List<Models.TransportationProjectBudget>();
            if (TransportationProjectBudgets != null)
            {
                // Completely rebuild the list
                transportationProjectBudgetsUpdated = TransportationProjectBudgets.SelectMany(x => x.ToTransportationProjectBudgets()).ToList();
            }

            currentTransportationProjectBudgets.Merge(transportationProjectBudgetsUpdated,
                allTransportationProjectBudgets,
                (x, y) =>
                    x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear && x.TransportationProjectCostTypeID == y.TransportationProjectCostTypeID,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);
        }
    }
}