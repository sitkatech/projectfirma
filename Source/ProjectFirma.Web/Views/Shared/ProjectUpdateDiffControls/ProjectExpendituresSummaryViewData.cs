using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public class ProjectExpendituresSummaryViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<CalendarYearString> CalendarYears;
        public readonly List<FundingSourceCalendarYearExpenditure> FundingSourceExpenditures;

        public ProjectExpendituresSummaryViewData(List<FundingSourceCalendarYearExpenditure> fundingSourceExpenditures, List<CalendarYearString> calendarYears)
        {
            FundingSourceExpenditures = fundingSourceExpenditures;
            CalendarYears = calendarYears;
        }
    }
}