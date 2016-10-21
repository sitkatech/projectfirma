using System.Collections.Generic;

namespace ProjectFirma.Web.Models
{
    public interface IIndicatorReported
    {
        int PrimaryKey { get; }
        int SortOrder { get; }
        IIndicatorReportingPeriod IndicatorReportingPeriod { get; }
        IIndicatorWithOnlyOneSubcategoryAndNotReportedInEIP IndicatorWithOnlyOneSubcategoryAndNotReportedInEIP { get; }
        double ReportedValue { get; }
        List<IIndicatorReportedSubcategoryOption> IndicatorReportedSubcategoryOptions { get; }
    }
}