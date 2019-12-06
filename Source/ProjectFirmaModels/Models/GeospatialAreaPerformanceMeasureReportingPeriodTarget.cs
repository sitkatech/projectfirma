namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaPerformanceMeasureReportingPeriodTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Target Value: {GeospatialAreaPerformanceMeasureTargetValue}, Reporting Period ID: {PerformanceMeasureReportingPeriodID}";
        }
    }
}