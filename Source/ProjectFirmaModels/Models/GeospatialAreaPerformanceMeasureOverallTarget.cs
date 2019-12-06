namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaPerformanceMeasureOverallTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Geospatial Area: {GeospatialAreaID}, Target Value: {GeospatialAreaPerformanceMeasureTargetValue}";
        }
    }
}