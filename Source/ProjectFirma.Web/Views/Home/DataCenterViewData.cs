using System.Linq;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Home
{
    public class DataCenterViewData : SiteLayoutViewData
    {
        public readonly HtmlString DataCenterIntroContent;

        public readonly string ManageIndicatorsUrl;
        public readonly string ManageLocalAndRegionalPlansUrl;
        public readonly string ManageWaterShedUrl;

        public readonly string WebServicesUrl;
        public readonly string ManageOrganizationsUrl;
        public readonly string ManageMonitoringProgramsUrl;

        public readonly int IndicatorsCount;
        public readonly int ThresholdCategoriesCount;
        public readonly int LocalAndRegionalPlansCount;
        public readonly int WatershedsCount;
        public readonly int OrganizationsCount;
        public readonly int MonitoringProgramsCount;

        public DataCenterViewData(Person currentPerson)
            : base(currentPerson)
        {
            PageTitle = "Data Center";

            DataCenterIntroContent = Models.ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.LTInfoDataCenter).ProjectFirmaPageContentHtmlString;

            ManageIndicatorsUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.Index());
            ManageLocalAndRegionalPlansUrl = SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(c => c.Index());
            ManageWaterShedUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(c => c.Index());

            WebServicesUrl = SitkaRoute<WebServicesController>.BuildUrlFromExpression(c => c.Index());
            ManageOrganizationsUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(c => c.Index());
            ManageMonitoringProgramsUrl = SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(c => c.Index());

            IndicatorsCount = HttpRequestStorage.DatabaseEntities.Indicators.Count();
            ThresholdCategoriesCount = HttpRequestStorage.DatabaseEntities.ThresholdCategories.Count();
            LocalAndRegionalPlansCount = HttpRequestStorage.DatabaseEntities.LocalAndRegionalPlans.Count();
            WatershedsCount = HttpRequestStorage.DatabaseEntities.Watersheds.Count();
            OrganizationsCount = HttpRequestStorage.DatabaseEntities.Organizations.Count();
            MonitoringProgramsCount = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.Count();
        }
    }
}