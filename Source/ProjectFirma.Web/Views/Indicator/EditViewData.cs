using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.Indicator
{
    public class EditViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> MeasurementUnitTypes;
        public readonly IEnumerable<SelectListItem> IndicatorTypes;

        public EditViewData(IEnumerable<SelectListItem> measurementUnitTypes, IEnumerable<SelectListItem> indicatorTypes)
        {
            MeasurementUnitTypes = measurementUnitTypes;
            IndicatorTypes = indicatorTypes;
        }
    }
}