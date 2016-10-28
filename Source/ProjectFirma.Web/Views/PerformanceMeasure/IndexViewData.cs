using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndexGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            PageTitle = "Performance Measures";
            EntityName = "Performance Measure";

            GridSpec = new IndexGridSpec()
            {
                ObjectNameSingular = "Performance Measure",
                ObjectNamePlural = "Performance Measures",
                SaveFiltersInCookie = true
            };

            GridName = "performanceMeasuresGrid";
            GridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
        }
    }
}