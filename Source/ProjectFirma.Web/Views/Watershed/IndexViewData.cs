using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Watershed
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Watersheds";            
            GridSpec = new IndexGridSpec {ObjectNameSingular = "Watershed", ObjectNamePlural = "Watersheds", SaveFiltersInCookie = true};
            GridName = "watershedsGrid";
            GridDataUrl = SitkaRoute<WatershedController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}