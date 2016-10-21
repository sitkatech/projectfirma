using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Results;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.FundingSource
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.FundingSource FundingSource;
        public readonly bool UserHasFundingSourceManagePermissions;
        public readonly bool UserHasProjectFundingSourceExpenditureManagePermissions;
        public readonly string EditFundingSourceUrl;
        public readonly string EditReportedExpendituresUrl;
        public readonly string ManageFundingSourcesUrl;

        public readonly List<int> CalendarYearsForProjectExpenditures;

        public readonly ProjectCalendarYearExpendituresGridSpec ProjectCalendarYearExpendituresGridSpec;
        public readonly string ProjectCalendarYearExpendituresGridName;
        public readonly string ProjectCalendarYearExpendituresGridDataUrl;
        public readonly CalendarYearExpendituresLineChartViewData CalendarYearExpendituresLineChartViewData;

        public SummaryViewData(Person currentPerson, Models.FundingSource fundingSource, CalendarYearExpendituresLineChartViewData calendarYearExpendituresLineChartViewData) : base(currentPerson)
        {
            CalendarYearExpendituresLineChartViewData = calendarYearExpendituresLineChartViewData;
            FundingSource = fundingSource;
            PageTitle = fundingSource.DisplayName;
            EntityName = "Funding Source";
            UserHasFundingSourceManagePermissions = new FundingSourceManageFeature().HasPermissionByPerson(CurrentPerson);
            UserHasProjectFundingSourceExpenditureManagePermissions = new ProjectFundingSourceExpenditureFromFundingSourceManageFeature().HasPermissionByPerson(currentPerson);
            EditFundingSourceUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Edit(fundingSource));
            EditReportedExpendituresUrl = SitkaRoute<ProjectFundingSourceExpenditureController>.BuildUrlFromExpression(c => c.EditProjectFundingSourceExpendituresForFundingSource(fundingSource));

            var projectFundingSourceExpenditures = FundingSource.ProjectFundingSourceExpenditures.ToList();
            CalendarYearsForProjectExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(fundingSource);

            ProjectCalendarYearExpendituresGridSpec = new ProjectCalendarYearExpendituresGridSpec(CalendarYearsForProjectExpenditures)
            {
                ObjectNameSingular = "Project",
                ObjectNamePlural = "Projects",
                SaveFiltersInCookie = true
            };

            ProjectCalendarYearExpendituresGridName = "projectsCalendarYearExpendituresFromFundingSourceGrid";
            ProjectCalendarYearExpendituresGridDataUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(tc => tc.ProjectCalendarYearExpendituresGridJsonData(fundingSource));
            ManageFundingSourcesUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Index());
        }
    }
}