using System;
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureReportedValue
    {
        string PerformanceMeasureName { get; }
        string PerformanceMeasureUrl { get; }
        MeasurementUnitType MeasurementUnitType { get; }
        List<IPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions { get; }
        string IndicatorSubcategoriesAsString { get; }
        string ReportedValueDisplay { get; }
        double? ReportedValue { get; }
        Int32 PerformanceMeasureID { get; }
        Int32 CalendarYear { get; }
        PerformanceMeasure PerformanceMeasure { get; }
    }
}