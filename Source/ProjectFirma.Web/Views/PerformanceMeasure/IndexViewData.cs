using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class IndexViewData : FirmaViewData
    {
        public readonly PerformanceMeasureGridSpec PerformanceMeasureGridSpec;
        public readonly string PerformanceMeasureGridName;
        public readonly string PerformanceMeasureGridDataUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {  
            PageTitle = MultiTenantHelpers.GetPerformanceMeasureName();

            PerformanceMeasureGridSpec = new PerformanceMeasureGridSpec {
                ObjectNameSingular = MultiTenantHelpers.GetPerformanceMeasureName(),
                ObjectNamePlural = MultiTenantHelpers.GetPerformanceMeasureNamePluralized(),
                SaveFiltersInCookie = true
            };

            PerformanceMeasureGridName = "performanceMeasuresGrid";
            PerformanceMeasureGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.PerformanceMeasureGridJsonData());
        }
    }
}