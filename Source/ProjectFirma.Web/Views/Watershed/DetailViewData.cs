using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Results;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Watershed
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.Watershed Watershed;
        public readonly bool UserHasWatershedManagePermissions;
        public readonly string IndexUrl;
        public readonly BasicProjectInfoGridSpec BasicProjectInfoGridSpec;
        public readonly string BasicProjectInfoGridName;
        public readonly string BasicProjectInfoGridDataUrl;
        public readonly MapInitJson MapInitJson;
        public readonly CalendarYearExpendituresLineChartViewData CalendarYearExpendituresLineChartViewData;
        public readonly string ManageWatershedsUrl;

        public DetailViewData(Person currentPerson, Models.Watershed watershed, MapInitJson mapInitJson, CalendarYearExpendituresLineChartViewData calendarYearExpendituresLineChartViewData) : base(currentPerson)
        {
            Watershed = watershed;
            MapInitJson = mapInitJson;
            CalendarYearExpendituresLineChartViewData = calendarYearExpendituresLineChartViewData;
            PageTitle = watershed.WatershedName;
            EntityName = "Watershed";
            UserHasWatershedManagePermissions = new WatershedManageFeature().HasPermissionByPerson(currentPerson);
            IndexUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(x => x.Index());

            BasicProjectInfoGridName = "watershedProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, false)
            {
                ObjectNameSingular = "Project in this Watershed",
                ObjectNamePlural = "Projects in this Watershed",
                SaveFiltersInCookie = true
            };
          
            BasicProjectInfoGridDataUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(tc => tc.ProjectsGridJsonData(watershed));
            ManageWatershedsUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(c => c.Index());
        }

        
    }
}