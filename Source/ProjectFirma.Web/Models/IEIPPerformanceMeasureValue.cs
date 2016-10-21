using System;
using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IEIPPerformanceMeasureValue
    {
        Int32 EIPPerformanceMeasureID { get; set; }
        List<IEIPPerformanceMeasureValueSubcategoryOption> IndicatorSubcategoryOptions { get; }
        EIPPerformanceMeasure EIPPerformanceMeasure { get; set; }
        double? ReportedValue { get; }
        string IndicatorSubcategoriesAsString { get; }
    }
}