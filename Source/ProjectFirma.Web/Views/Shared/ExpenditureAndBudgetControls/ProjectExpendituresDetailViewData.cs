using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectExpendituresDetailViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYears;
        public readonly List<FundingSourceCalendarYearExpenditure> FundingSourceExpenditures;

        public ProjectExpendituresDetailViewData(List<FundingSourceCalendarYearExpenditure> fundingSourceExpenditures, List<int> calendarYears)
        {
            FundingSourceExpenditures = fundingSourceExpenditures;
            CalendarYears = calendarYears;
        }
    }
}