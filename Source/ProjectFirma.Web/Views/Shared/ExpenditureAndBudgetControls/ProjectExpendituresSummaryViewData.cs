using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectExpendituresSummaryViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<int> CalendarYears;
        public readonly List<FundingSourceCalendarYearExpenditure> FundingSourceExpenditures;

        public ProjectExpendituresSummaryViewData(List<FundingSourceCalendarYearExpenditure> fundingSourceExpenditures, List<int> calendarYears)
        {
            FundingSourceExpenditures = fundingSourceExpenditures;
            CalendarYears = calendarYears;
        }
    }
}