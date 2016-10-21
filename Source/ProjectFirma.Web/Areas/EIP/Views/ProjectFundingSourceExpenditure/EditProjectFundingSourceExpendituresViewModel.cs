using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProjectFundingSourceExpenditure
{
    public class EditProjectFundingSourceExpendituresViewModel : FormViewModel
    {
        public List<ProjectFundingSourceExpenditureBulk> ProjectFundingSourceExpenditures { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectFundingSourceExpendituresViewModel()
        {
        }

        public EditProjectFundingSourceExpendituresViewModel(List<Models.ProjectFundingSourceExpenditure> projectFundingSourceExpenditures, List<int> calendarYearsToPopulate)
        {
            ProjectFundingSourceExpenditures = ProjectFundingSourceExpenditureBulk.MakeFromList(projectFundingSourceExpenditures, calendarYearsToPopulate);
        }

        public void UpdateModel(List<Models.ProjectFundingSourceExpenditure> currentProjectFundingSourceExpenditures, IList<Models.ProjectFundingSourceExpenditure> allProjectFundingSourceExpenditures)
        {
            var projectFundingSourceExpendituresUpdated = new List<Models.ProjectFundingSourceExpenditure>();
            if (ProjectFundingSourceExpenditures != null)
            {
                // Completely rebuild the list
                projectFundingSourceExpendituresUpdated = ProjectFundingSourceExpenditures.SelectMany(x => x.ToProjectFundingSourceExpenditures()).ToList();
            }

            currentProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresUpdated,
                allProjectFundingSourceExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount);
        }
    }
}