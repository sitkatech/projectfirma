using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.Indicator
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> MeasurementUnitTypes;
        public readonly IEnumerable<SelectListItem> IndicatorTypes;
        public readonly bool ReportedInThresholdDashboard;

        public EditViewData(IEnumerable<SelectListItem> measurementUnitTypes, IEnumerable<SelectListItem> indicatorTypes, bool reportedInThresholdDashboard)
        {
            MeasurementUnitTypes = measurementUnitTypes;
            IndicatorTypes = indicatorTypes;
            ReportedInThresholdDashboard = reportedInThresholdDashboard;
        }
    }
}