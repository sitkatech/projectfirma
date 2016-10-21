using System;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdIndicatorReportingPeriod : IAuditableEntity, IIndicatorReportingPeriod
    {
        public string AuditDescriptionString
        {
            get { return ThresholdIndicatorReportingPeriodLabel; }
        }
        public int ReportingPeriodID
        {
            get { return ThresholdIndicatorReportingPeriodID; }
        }
        public DateTime ReportingPeriodBeginDate
        {
            get { return ThresholdIndicatorReportingPeriodBeginDate; }
        }
        public DateTime? ReportingPeriodEndDate
        {
            get { return ThresholdIndicatorReportingPeriodEndDate; }
        }
        public string ReportingPeriodLabel
        {
            get { return ThresholdIndicatorReportingPeriodLabel; }
        }
    }
}