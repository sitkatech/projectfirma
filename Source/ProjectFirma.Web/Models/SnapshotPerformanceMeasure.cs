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

        public PerformanceMeasureType PerformanceMeasureType
        {
            get { return PerformanceMeasure.PerformanceMeasureType; }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return PerformanceMeasure.Indicator.MeasurementUnitType; }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(SnapshotPerformanceMeasureSubcategoryOptions); }
        }

        public string IndicatorSubcategoriesAsString
        {
            get
            {
                return SnapshotPerformanceMeasureSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        SnapshotPerformanceMeasureSubcategoryOptions.OrderBy(x => x.IndicatorSubcategory.IndicatorSubcategoryDisplayName)
                            .Select(x => string.Format("{0}: {1}", x.IndicatorSubcategory.IndicatorSubcategoryDisplayName, x.IndicatorSubcategoryOption.IndicatorSubcategoryOptionName)))
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