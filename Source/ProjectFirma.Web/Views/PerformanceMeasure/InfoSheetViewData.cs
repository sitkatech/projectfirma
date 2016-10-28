using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class InfoSheetViewData : FirmaViewData
    {
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly bool HasReportedValues;
        public readonly List<KeyValuePair<Models.Program, bool>> PerformanceMeasurePrograms;
        public readonly IndicatorChartViewData IndicatorChartViewData;
        public readonly string IndexUrl;
        
        public InfoSheetViewData(Person currentPerson, Models.PerformanceMeasure performanceMeasure, IndicatorChartViewData indicatorChartViewData)
            : base(currentPerson)
        {
            PerformanceMeasure = performanceMeasure;
            HtmlPageTitle = string.Format("PM {0}", performanceMeasure.PerformanceMeasureID);
            EntityName = "Performance Measure";
            BreadCrumbTitle = "Info Sheet";

            HasReportedValues = performanceMeasure.PerformanceMeasureActuals.Any();
            PerformanceMeasurePrograms = performanceMeasure.GetPrograms().OrderBy(x => x.Key.DisplayName).ToList();
            IndicatorChartViewData = indicatorChartViewData;

            IndexUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}