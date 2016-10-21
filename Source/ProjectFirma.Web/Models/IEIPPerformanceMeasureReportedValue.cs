using System;
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IEIPPerformanceMeasureReportedValue
    {
        string EIPPerformanceMeasureName { get; }
        string EIPPerformanceMeasureUrl { get; }
        EIPPerformanceMeasureType EIPPerformanceMeasureType { get; }
        MeasurementUnitType MeasurementUnitType { get; }
        List<IEIPPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions { get; }
        string IndicatorSubcategoriesAsString { get; }
        string ReportedValueDisplay { get; }
        double? ReportedValue { get; }
        Int32 EIPPerformanceMeasureID { get; }
        Int32 CalendarYear { get; }
        EIPPerformanceMeasure EIPPerformanceMeasure { get; }
    }
}