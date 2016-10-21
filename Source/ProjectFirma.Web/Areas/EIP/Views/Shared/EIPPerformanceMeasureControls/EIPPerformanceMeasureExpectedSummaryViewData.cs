using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.EIPPerformanceMeasureControls
{
    public class EIPPerformanceMeasureExpectedSummaryViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<IEIPPerformanceMeasureValue> EIPPerformanceMeasureExpecteds;

        public EIPPerformanceMeasureExpectedSummaryViewData(List<IEIPPerformanceMeasureValue> eipPerformanceMeasureExpecteds)
        {
            EIPPerformanceMeasureExpecteds = eipPerformanceMeasureExpecteds;
        }
    }
}