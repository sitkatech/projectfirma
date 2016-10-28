using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.PerformanceMeasureControls
{
    public class PerformanceMeasureExpectedSummaryViewData : FirmaUserControlViewData
    {
        public readonly List<IPerformanceMeasureValue> PerformanceMeasureExpecteds;

        public PerformanceMeasureExpectedSummaryViewData(List<IPerformanceMeasureValue> performanceMeasureExpecteds)
        {
            PerformanceMeasureExpecteds = performanceMeasureExpecteds;
        }
    }
}