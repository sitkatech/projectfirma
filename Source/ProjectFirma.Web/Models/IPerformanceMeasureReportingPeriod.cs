using System;

namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureReportingPeriod
    {
        int ReportingPeriodID { get; }
        DateTime ReportingPeriodBeginDate { get; }
        DateTime? ReportingPeriodEndDate { get; }
        string ReportingPeriodLabel { get; }
        double? TargetValue { get; }
        string TargetValueDescription { get; }
    }
}