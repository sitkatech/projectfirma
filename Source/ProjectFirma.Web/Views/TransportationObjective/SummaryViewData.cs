using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.TransportationObjective
{
    public class SummaryViewData : EIPViewData
    {
        public readonly Models.TransportationObjective TransportationObjective;
        public readonly bool UserHasTransportationObjectiveManagePermissions;
        public readonly string EditTransportationObjectiveUrl;
        public readonly TransportationListProjectGridSpec TransportationListProjectGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;
        public readonly string EditDescriptionUrl;

        public readonly TransportationExpendituresBarChartViewData TransportationExpendituresBarChartViewData;

        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly string EipProjectMapFilteredUrl;

        public SummaryViewData(Person currentPerson, 
            Models.TransportationObjective transportationObjective, 
            TransportationExpendituresBarChartViewData transportationExpendituresBarChartViewData,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData) 
            : base(currentPerson)
        {
            TransportationObjective = transportationObjective;
            PageTitle = transportationObjective.DisplayName;
            EntityName = "Transportation Objective";

            TransportationExpendituresBarChartViewData = transportationExpendituresBarChartViewData;

            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationsMapViewData = projectLocationsMapViewData;

            EipProjectMapFilteredUrl = ProjectLocationsMapInitJson.ProjectMapCustomization.GetCustomizedUrl();

            UserHasTransportationObjectiveManagePermissions = new TransportationObjectiveManageFeature().HasPermissionByPerson(CurrentPerson);
            EditTransportationObjectiveUrl = SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(c => c.Edit(transportationObjective));

            FiveYearListProjectGridName = "transportationObjectiveProjectListGrid";
            TransportationListProjectGridSpec = new TransportationListProjectGridSpec(CurrentPerson)
            {
                ObjectNameSingular = "Project with this Transportation Objective",
                ObjectNamePlural = "Projects with this Transportation Objective",
                SaveFiltersInCookie = true
            };

            FiveYearListProjectGridDataUrl = SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(transportationObjective));
            EditDescriptionUrl = SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(tc => tc.EditDescription(transportationObjective));
        }
    }
}