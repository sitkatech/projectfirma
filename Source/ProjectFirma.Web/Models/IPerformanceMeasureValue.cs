using System;
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureValue
    {
        Int32 PerformanceMeasureID { get; set; }
        List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions { get; }
        PerformanceMeasure PerformanceMeasure { get; set; }
        double? ReportedValue { get; }
        string PerformanceMeasureSubcategoriesAsString { get; }
    }
}