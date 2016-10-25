using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Results
{
    public class InvestmentByFundingSectorViewData : FirmaViewData
    {
        public readonly List<FundingSectorExpenditure> FundingSectorExpenditures;
        public readonly int? SelectedCalendarYear;
        public readonly string ProjectFundingSourceExpendituresBySectorUrl;
        public readonly string InvestmentByFundingSectorUrl;
        public readonly IEnumerable<SelectListItem> CalendarYears;
        public readonly int ProjectCount;
        public readonly bool IsPreReportingYear;
        public readonly string SpendingBySectorAndOrganizationUrl;
        public readonly string ReportingYearRangeTitle;
        public readonly GoogleChartJson GoogleChartJson;

        public InvestmentByFundingSectorViewData(Person currentPerson,
            Models.ProjectFirmaPage projectFirmaPage,
            List<FundingSectorExpenditure> fundingSectorExpenditures,
            int? selectedCalendarYear,
            IEnumerable<SelectListItem> calendarYears,
            int projectCount,
            string reportingYearRangeTitle) : base(currentPerson, projectFirmaPage)
        {
            FundingSectorExpenditures = fundingSectorExpenditures;
            PageTitle = "EIP Investment by Funding Sector";
            SelectedCalendarYear = selectedCalendarYear;
            CalendarYears = calendarYears;
            ProjectCount = projectCount;
            ReportingYearRangeTitle = reportingYearRangeTitle;
            ProjectFundingSourceExpendituresBySectorUrl =
                SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.ProjectFundingSourceExpendituresBySector(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            SpendingBySectorAndOrganizationUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.SpendingBySectorByOrganization(UrlTemplate.Parameter1Int, UrlTemplate.Parameter2Int));
            InvestmentByFundingSectorUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.InvestmentByFundingSector(UrlTemplate.Parameter1Int));
            IsPreReportingYear = SelectedCalendarYear.HasValue && SelectedCalendarYear.Value < ProjectFirmaDateUtilities.GetMinimumYearForReportingExpenditures();

            GoogleChartJson = ResultsController.GetInvestmentByFundingSectorGoogleChart(FundingSectorExpenditures, selectedCalendarYear);
            GoogleChartJson.GoogleChartConfiguration.SetSize(300, 350);
        }
    }
}