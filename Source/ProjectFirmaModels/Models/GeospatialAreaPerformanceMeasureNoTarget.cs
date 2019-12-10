namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaPerformanceMeasureNoTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Geospatial Area: {GeospatialAreaID}";
        }
    }
}