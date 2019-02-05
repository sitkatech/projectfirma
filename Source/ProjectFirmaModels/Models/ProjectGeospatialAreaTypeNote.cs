namespace ProjectFirmaModels.Models
{
    public partial class ProjectGeospatialAreaTypeNote : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"GeospatialAreaType: {GeospatialAreaTypeID}, Project: {ProjectID}";
        }
    }
}