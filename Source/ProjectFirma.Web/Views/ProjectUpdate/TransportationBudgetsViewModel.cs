using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class TransportationBudgetsViewModel : FormViewModel
    {
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public List<TransportationProjectBudgetBulk> TransportationProjectBudgets { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public TransportationBudgetsViewModel()
        {
        }

        public TransportationBudgetsViewModel(List<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates,
            List<int> calendarYearsToPopulate,
            bool showTransportationBudgetsValidationWarnings,
            string comments)
        {
            TransportationProjectBudgets = TransportationProjectBudgetBulk.MakeFromList(new List<ITransportationProjectBudgetAmount>(transportationProjectBudgetUpdates), calendarYearsToPopulate);
            ShowValidationWarnings = showTransportationBudgetsValidationWarnings;
            Comments = comments;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<TransportationProjectBudgetUpdate> currentTransportationProjectBudgetUpdates,
            IList<TransportationProjectBudgetUpdate> allTransportationProjectBudgetUpdates)
        {
            var projectFundingSourceExpenditureUpdatesUpdated = new List<TransportationProjectBudgetUpdate>();
            if (TransportationProjectBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpenditureUpdatesUpdated = TransportationProjectBudgets.SelectMany(x => x.ToTransportationProjectBudgetUpdates(projectUpdateBatch)).ToList();
            }

            currentTransportationProjectBudgetUpdates.Merge(projectFundingSourceExpenditureUpdatesUpdated,
                allTransportationProjectBudgetUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID  && x.TransportationProjectCostTypeID == y.TransportationProjectCostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);

            projectUpdateBatch.ShowTransportationBudgetsValidationWarnings = ShowValidationWarnings;
        }
    }
}