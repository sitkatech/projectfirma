using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.EIPPerformanceMeasure
{
    public class IndexViewData : FirmaViewData
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