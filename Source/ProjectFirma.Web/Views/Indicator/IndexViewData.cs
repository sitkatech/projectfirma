using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Indicator
{
    public class IndexViewData : FirmaViewData
    {
        public readonly IndicatorGridSpec IndicatorGridSpec;
        public readonly string IndicatorGridName;
        public readonly string IndicatorGridDataUrl;

        public IndexViewData(Person currentPerson, Models.ProjectFirmaPage projectFirmaPage) : base(currentPerson, projectFirmaPage)
        {  
            PageTitle = "Indicators";

            IndicatorGridSpec = new IndicatorGridSpec {
                ObjectNameSingular = "Indicator",
                ObjectNamePlural = "Indicators",
                SaveFiltersInCookie = true
            };

            IndicatorGridName = "indicatorsGrid";
            IndicatorGridDataUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.IndicatorGridJsonData());
        }
    }
}