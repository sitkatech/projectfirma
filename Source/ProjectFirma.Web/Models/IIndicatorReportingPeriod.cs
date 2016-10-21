using System;

namespace ProjectFirma.Web.Models
{
    public interface IIndicatorReportingPeriod
    {
        int ReportingPeriodID { get; }
        DateTime ReportingPeriodBeginDate { get; }
        DateTime? ReportingPeriodEndDate { get; }
        string ReportingPeriodLabel { get; }
        double? TargetValue { get; }
        string TargetValueDescription { get; }
    }
}