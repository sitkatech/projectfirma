using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.EIPPerformanceMeasure
{
    public class InfoSheetViewData : FirmaViewData
    {
        public readonly Models.EIPPerformanceMeasure EIPPerformanceMeasure;
        public readonly bool HasReportedValues;
        public readonly List<KeyValuePair<Models.Program, bool>> EIPPerformanceMeasurePrograms;
        public readonly IndicatorChartViewData IndicatorChartViewData;
        public readonly string IndexUrl;
        
        public InfoSheetViewData(Person currentPerson, Models.EIPPerformanceMeasure eipPerformanceMeasure, IndicatorChartViewData indicatorChartViewData)
            : base(currentPerson)
        {
            EIPPerformanceMeasure = eipPerformanceMeasure;
            HtmlPageTitle = string.Format("PM {0}", eipPerformanceMeasure.EIPPerformanceMeasureID);
            EntityName = "Performance Measure";
            BreadCrumbTitle = "Info Sheet";

            HasReportedValues = eipPerformanceMeasure.EIPPerformanceMeasureActuals.Any();
            EIPPerformanceMeasurePrograms = eipPerformanceMeasure.GetPrograms().OrderBy(x => x.Key.DisplayName).ToList();
            IndicatorChartViewData = indicatorChartViewData;

            IndexUrl = SitkaRoute<EIPPerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}