using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureReported
    {
        int PrimaryKey { get; }
        int SortOrder { get; }
        IPerformanceMeasureReportingPeriod PerformanceMeasureReportingPeriod { get; }
        IPerformanceMeasureWithOnlyOneSubcategory PerformanceMeasureWithOnlyOneSubcategory { get; }
        double ReportedValue { get; }
        List<IPerformanceMeasureReportedSubcategoryOption> PerformanceMeasureReportedSubcategoryOptions { get; }
    }
}