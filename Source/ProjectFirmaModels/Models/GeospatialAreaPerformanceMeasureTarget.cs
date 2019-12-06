namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaPerformanceMeasureTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Target Value: {GeospatialAreaPerformanceMeasureTargetValue}, Reporting Period ID: {PerformanceMeasureReportingPeriodID}";
        }
    }
}