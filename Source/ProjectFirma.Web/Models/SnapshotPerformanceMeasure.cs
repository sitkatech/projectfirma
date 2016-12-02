using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class SnapshotPerformanceMeasure : IPerformanceMeasureReportedValue
    {
        public string PerformanceMeasureName
        {
            get { return PerformanceMeasure.DisplayName; }
        }

        public string PerformanceMeasureUrl
        {
            get { return PerformanceMeasure.GetSummaryUrl(); }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return PerformanceMeasure.MeasurementUnitType; }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(SnapshotPerformanceMeasureSubcategoryOptions); }
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                return SnapshotPerformanceMeasureSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        SnapshotPerformanceMeasureSubcategoryOptions.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                            .Select(x => string.Format("{0}: {1}", x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName, x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)))
                    : ViewUtilities.NoneString;
            }
        }

        public string ReportedValueDisplay
        {
            get { return MeasurementUnitType.DisplayValue(ReportedValue); }
        }

        public double? ReportedValue
        {
            get { return ActualValue; }
        }
    }
}