using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.TransportationStrategy
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.TransportationStrategy TransportationStrategy;
        public readonly bool UserHasTransportationStrategyManagePermissions;
        public readonly string EditTransportationStrategyUrl;

        public readonly string BackUrl;
        public readonly TransportationListProjectGridSpec TransportationListProjectGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;
        public readonly string EditDescriptionUrl;

        public readonly TransportationExpendituresBarChartViewData TransportationExpendituresBarChartViewData;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string EipProjectMapFilteredUrl;

        public SummaryViewData(Person currentPerson, 
            Models.TransportationStrategy transportationStrategy,
            TransportationExpendituresBarChartViewData transportationExpendituresBarChartViewData,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData)
            : base(currentPerson)
        {
            TransportationStrategy = transportationStrategy;
            PageTitle = transportationStrategy.DisplayName;
            EntityName = "Transportation Strategy";

            TransportationExpendituresBarChartViewData = transportationExpendituresBarChartViewData;

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;

            EipProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasTransportationStrategyManagePermissions = new TransportationStrategyManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTransportationStrategyUrl = SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(c => c.Edit(transportationStrategy.TransportationStrategyID));

            BackUrl = SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(c => c.Index());

            FiveYearListProjectGridName = "transportationStrategyProjectListGrid";
            TransportationListProjectGridSpec = new TransportationListProjectGridSpec(CurrentPerson)
            {
                ObjectNameSingular = "Project with this Transportation Strategy",
                ObjectNamePlural = "Projects with this Transportation Strategy",
                SaveFiltersInCookie = true
            };

            FiveYearListProjectGridDataUrl = SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(transportationStrategy));
            EditDescriptionUrl = SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(tc => tc.EditDescription(transportationStrategy));
        }
    }
}