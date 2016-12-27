using System.Collections.Generic;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Results
{
    public class SpendingBySectorByOrganizationViewData : FirmaUserControlViewData
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