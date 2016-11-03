using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class BudgetsViewModel : FormViewModel
    {
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        [DisplayName("Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public List<ProjectBudgetBulk> ProjectBudgets { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public BudgetsViewModel()
        {
        }

        public BudgetsViewModel(List<ProjectBudgetUpdate> ProjectBudgetUpdates,
            List<int> calendarYearsToPopulate,
            bool showBudgetsValidationWarnings,
            string comments)
        {
            ProjectBudgets = ProjectBudgetBulk.MakeFromList(new List<IProjectBudgetAmount>(ProjectBudgetUpdates), calendarYearsToPopulate);
            ShowValidationWarnings = showBudgetsValidationWarnings;
            Comments = comments;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectBudgetUpdate> currentProjectBudgetUpdates,
            IList<ProjectBudgetUpdate> allProjectBudgetUpdates)
        {
            var projectFundingSourceExpenditureUpdatesUpdated = new List<ProjectBudgetUpdate>();
            if (ProjectBudgets != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpenditureUpdatesUpdated = ProjectBudgets.SelectMany(x => x.ToProjectBudgetUpdates(projectUpdateBatch)).ToList();
            }

            currentProjectBudgetUpdates.Merge(projectFundingSourceExpenditureUpdatesUpdated,
                allProjectBudgetUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID  && x.ProjectCostTypeID == y.ProjectCostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);

            projectUpdateBatch.ShowBudgetsValidationWarnings = ShowValidationWarnings;
        }
    }
}