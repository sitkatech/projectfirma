using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ExpendituresViewModel : FormViewModel
    {
        [DisplayName("Show Validation Warnings?")]
        public bool ShowValidationWarnings { get; set; }

        [DisplayName("Review Comments")]
        [StringLength(ProjectUpdateBatch.FieldLengths.ExpendituresComment)]
        public string Comments { get; set; }

        public List<ProjectFundingSourceExpenditureBulk> ProjectFundingSourceExpenditures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public ExpendituresViewModel()
        {
        }

        public ExpendituresViewModel(List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates,
            List<int> calendarYearsToPopulate,
            bool showExpendituresValidationWarnings,
            string comments)
        {
            ProjectFundingSourceExpenditures = ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditureUpdates, calendarYearsToPopulate);
            ShowValidationWarnings = showExpendituresValidationWarnings;
            Comments = comments;
        }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch,
            List<ProjectFundingSourceExpenditureUpdate> currentProjectFundingSourceExpenditureUpdates,
            IList<ProjectFundingSourceExpenditureUpdate> allProjectFundingSourceExpenditureUpdates)
        {
            var projectFundingSourceExpenditureUpdatesUpdated = new List<ProjectFundingSourceExpenditureUpdate>();
            if (ProjectFundingSourceExpenditures != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpenditureUpdatesUpdated = ProjectFundingSourceExpenditures.SelectMany(x => x.ToProjectFundingSourceExpenditureUpdates(projectUpdateBatch)).ToList();
            }

            currentProjectFundingSourceExpenditureUpdates.Merge(projectFundingSourceExpenditureUpdatesUpdated,
                allProjectFundingSourceExpenditureUpdates,
                (x, y) => x.ProjectUpdateBatchID == y.ProjectUpdateBatchID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount);

            projectUpdateBatch.ShowExpendituresValidationWarnings = ShowValidationWarnings;
        }
    }
}