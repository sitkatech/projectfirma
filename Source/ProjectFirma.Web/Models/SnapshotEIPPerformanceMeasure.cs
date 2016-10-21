using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class SnapshotEIPPerformanceMeasure : IEIPPerformanceMeasureReportedValue
    {
        public string EIPPerformanceMeasureName
        {
            get { return EIPPerformanceMeasure.DisplayName; }
        }

        public string EIPPerformanceMeasureUrl
        {
            get { return EIPPerformanceMeasure.GetSummaryUrl(); }
        }

        public EIPPerformanceMeasureType EIPPerformanceMeasureType
        {
            get { return EIPPerformanceMeasure.EIPPerformanceMeasureType; }
        }

        public MeasurementUnitType MeasurementUnitType
        {
            get { return EIPPerformanceMeasure.Indicator.MeasurementUnitType; }
        }

        public List<IEIPPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions
        {
            get { return new List<IEIPPerformanceMeasureValueSubcategoryOption>(SnapshotEIPPerformanceMeasureSubcategoryOptions); }
        }

        public string IndicatorSubcategoriesAsString
        {
            get
            {
                return SnapshotEIPPerformanceMeasureSubcategoryOptions.Any()
                    ? string.Join("\r\n",
                        SnapshotEIPPerformanceMeasureSubcategoryOptions.OrderBy(x => x.IndicatorSubcategory.IndicatorSubcategoryDisplayName)
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