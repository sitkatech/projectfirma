namespace ProjectFirmaModels.Models
{
    public partial class PerformanceMeasureTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Target Value: {PerformanceMeasureTargetValue}, Reporting Period ID: {PerformanceMeasureReportingPeriodID}";
        }
    }
}