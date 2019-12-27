namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaPerformanceMeasureReportingPeriodTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Geospatial Area: {GeospatialAreaID}, Target Value: {GeospatialAreaPerformanceMeasureTargetValue}, Reporting Period ID: {PerformanceMeasureReportingPeriodID}";
        }
    }
}