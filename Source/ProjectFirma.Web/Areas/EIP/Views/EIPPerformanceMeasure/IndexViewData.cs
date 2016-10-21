using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.EIP.Views.EIPPerformanceMeasure
{
    public class IndexViewData : EIPViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Performance Measures";
            EntityName = "Performance Measure";

            GridSpec = new IndexGridSpec()
            {
                ObjectNameSingular = "Performance Measure",
                ObjectNamePlural = "Performance Measures",
                SaveFiltersInCookie = true
            };

            GridName = "eipPerformanceMeasuresGrid";
            GridDataUrl = SitkaRoute<EIPPerformanceMeasureController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}