using System;

namespace ProjectFirma.Web.Models
{
    public partial class SustainabilityIndicatorReportingPeriod : IAuditableEntity, IIndicatorReportingPeriod
    {
        public string AuditDescriptionString
        {
            get { return SustainabilityIndicatorReportingPeriodLabel; }
        }
        public int ReportingPeriodID
        {
            get { return SustainabilityIndicatorReportingPeriodID; }
        }
        public DateTime ReportingPeriodBeginDate
        {
            get { return SustainabilityIndicatorReportingPeriodBeginDate; }
        }
        public DateTime? ReportingPeriodEndDate
        {
            get { return SustainabilityIndicatorReportingPeriodEndDate; }
        }
        public string ReportingPeriodLabel
        {
            get { return SustainabilityIndicatorReportingPeriodLabel; }
        }
    }
}