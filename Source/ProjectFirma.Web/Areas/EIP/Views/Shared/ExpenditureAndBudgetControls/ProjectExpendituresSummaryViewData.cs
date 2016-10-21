using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ExpenditureAndBudgetControls
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