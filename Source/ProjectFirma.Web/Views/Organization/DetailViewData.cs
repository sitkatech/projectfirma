using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Organization
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Organization Organization;
        public readonly bool UserHasOrganizationManagePermissions;
        public readonly string EditOrganizationUrl;
        public readonly ProjectOrganizationsGridSpec ProjectOrganizationsGridSpec;
        public readonly string ProjectOrganizationsGridName;
        public readonly string ProjectOrganizationsGridDataUrl;
        public readonly CalendarYearExpendituresLineChartViewData CalendarYearExpendituresLineChartViewData;
        
        public readonly string ManageFundingSourcesUrl;
        public readonly string IndexUrl;

        public readonly MapInitJson MapInitJson;
        public readonly bool HasSpatialData;

        public DetailViewData(Person currentPerson,
            Models.Organization organization,
            CalendarYearExpendituresLineChartViewData calendarYearExpendituresLineChartViewData,
            MapInitJson mapInitJson,
            bool hasSpatialData) : base(currentPerson)
        {
            Organization = organization;
            CalendarYearExpendituresLineChartViewData = calendarYearExpendituresLineChartViewData;
            PageTitle = organization.DisplayName;
            EntityName = "Organization";
            UserHasOrganizationManagePermissions = new OrganizationManageFeature().HasPermissionByPerson(CurrentPerson);

            EditOrganizationUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Edit(organization));

            ProjectOrganizationsGridSpec = new ProjectOrganizationsGridSpec(organization.GetCalendarYearsForProjectExpenditures())
            {
                ObjectNameSingular = "Project",
                ObjectNamePlural = string.Format("Projects associated with {0}", organization.DisplayName),
                SaveFiltersInCookie = true
            };

            ProjectOrganizationsGridName = "projectOrganizationsFromOrganizationGrid";
            ProjectOrganizationsGridDataUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(tc => tc.ProjectOrganizationsGridJsonData(organization));
            ManageFundingSourcesUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.Index());
            IndexUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Index());

            MapInitJson = mapInitJson;
            HasSpatialData = hasSpatialData;
        }
    }
}