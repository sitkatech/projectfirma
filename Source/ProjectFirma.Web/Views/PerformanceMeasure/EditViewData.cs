using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditViewData : FirmaUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> MeasurementUnitTypes;
        public readonly IEnumerable<SelectListItem> PerformanceMeasureTypes;

        public EditViewData(IEnumerable<SelectListItem> measurementUnitTypes, IEnumerable<SelectListItem> performanceMeasureTypes)
        {
            MeasurementUnitTypes = measurementUnitTypes;
            PerformanceMeasureTypes = performanceMeasureTypes;
        }
    }
}