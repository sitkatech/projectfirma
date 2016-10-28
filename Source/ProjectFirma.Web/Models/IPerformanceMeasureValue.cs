using System;
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureValue
    {
        Int32 PerformanceMeasureID { get; set; }
        List<IPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions { get; }
        PerformanceMeasure PerformanceMeasure { get; set; }
        double? ReportedValue { get; }
        string IndicatorSubcategoriesAsString { get; }
    }
}