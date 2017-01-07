using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class IndexViewData : FirmaViewData
    {
        public readonly PerformanceMeasureGridSpec PerformanceMeasureGridSpec;
        public readonly string PerformanceMeasureGridName;
        public readonly string PerformanceMeasureGridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {  
            PageTitle = "PerformanceMeasures";

            PerformanceMeasureGridSpec = new PerformanceMeasureGridSpec {
                ObjectNameSingular = "PerformanceMeasure",
                ObjectNamePlural = "PerformanceMeasures",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureGridName = "performanceMeasuresGrid";
            PerformanceMeasureGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.PerformanceMeasureGridJsonData());
        }
    }
}