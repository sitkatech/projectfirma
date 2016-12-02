using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureWithOnlyOneSubcategory
    {
        PerformanceMeasure PerformanceMeasure { get; }
        PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        bool UseCustomDateRange { get; }
        List<IPerformanceMeasureReportingPeriod> GetPerformanceMeasureReportingPeriods();
        List<IPerformanceMeasureReported> GetPerformanceMeasureReportedValues();
        string GetChartPopupUrl();
    }
}