using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Watershed
{
    public class SummaryViewData : FirmaViewData
    {
        public readonly Models.Watershed Watershed;
        public readonly bool UserHasWatershedManagePermissions;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string FiveYearListProjectGridName;
        public readonly string FiveYearListProjectGridDataUrl;
        public readonly MapInitJson MapInitJson;
        public readonly CalendarYearExpendituresLineChartViewData CalendarYearExpendituresLineChartViewData;
        public readonly string ManageWatershedsUrl;

        public SummaryViewData(Person currentPerson, Models.Watershed watershed, MapInitJson mapInitJson, CalendarYearExpendituresLineChartViewData calendarYearExpendituresLineChartViewData) : base(currentPerson)
        {
            Watershed = watershed;
            MapInitJson = mapInitJson;
            CalendarYearExpendituresLineChartViewData = calendarYearExpendituresLineChartViewData;
            PageTitle = watershed.WatershedName;
            EntityName = "Watershed";
            UserHasWatershedManagePermissions = new WatershedManageFeature().HasPermissionByPerson(currentPerson);

            FiveYearListProjectGridName = "watershedProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = "Project in this Watershed",
                ObjectNamePlural = "Projects in this Watershed",
                SaveFiltersInCookie = true
            };
          
            FiveYearListProjectGridDataUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(watershed));
            ManageWatershedsUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(c => c.Index());
        }
    }
}