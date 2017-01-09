using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class InfoSheetViewData : FirmaViewData
    {
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly bool HasReportedValues;
        public readonly List<KeyValuePair<Models.TaxonomyTierTwo, bool>> PerformanceMeasureTaxonomyTierTwos;
        public readonly PerformanceMeasureChartViewData PerformanceMeasureChartViewData;
        public readonly string IndexUrl;
        
        public InfoSheetViewData(Person currentPerson, Models.PerformanceMeasure performanceMeasure, PerformanceMeasureChartViewData performanceMeasureChartViewData)
            : base(currentPerson)
        {
            PerformanceMeasure = performanceMeasure;
            HtmlPageTitle = string.Format("{0}: {1}", MultiTenantHelpers.GetPerformanceMeasureName(), performanceMeasure.PerformanceMeasureDisplayName);
            EntityName = MultiTenantHelpers.GetPerformanceMeasureName();
            BreadCrumbTitle = "Info Sheet";

            HasReportedValues = performanceMeasure.PerformanceMeasureActuals.Any();
            PerformanceMeasureTaxonomyTierTwos = performanceMeasure.GetTaxonomyTierTwos().OrderBy(x => x.Key.DisplayName).ToList();
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;

            IndexUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}