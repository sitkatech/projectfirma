namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaPerformanceMeasureFixedTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Geospatial Area: {GeospatialAreaID}, Target Value: {GeospatialAreaPerformanceMeasureTargetValue}";
        }
    }
}