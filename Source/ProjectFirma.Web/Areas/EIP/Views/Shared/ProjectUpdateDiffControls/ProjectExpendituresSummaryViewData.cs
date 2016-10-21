using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectUpdateDiffControls
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