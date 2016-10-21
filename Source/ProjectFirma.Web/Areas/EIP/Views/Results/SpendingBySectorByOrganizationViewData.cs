using System.Collections.Generic;
using ProjectFirma.Web.Areas.EIP.Views.Project;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Results
{
    public class SpendingBySectorByOrganizationViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<FundingSourceCalendarYearExpenditure> FundingSourceCalendarYearExpenditures;
        public readonly Dictionary<int, string> CalendarYears;
        public readonly string ExcelUrl;

        public SpendingBySectorByOrganizationViewData(List<FundingSourceCalendarYearExpenditure> fundingSourceCalendarYearExpenditures, Dictionary<int, string> calendarYears, string excelUrl)
        {
            FundingSourceCalendarYearExpenditures = fundingSourceCalendarYearExpenditures;
            CalendarYears = calendarYears;
            ExcelUrl = excelUrl;
        }
    }
}