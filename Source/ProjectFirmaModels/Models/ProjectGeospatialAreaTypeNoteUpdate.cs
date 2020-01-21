namespace ProjectFirmaModels.Models
{
    public partial class ProjectGeospatialAreaTypeNoteUpdate : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"GeospatialAreaType: {GeospatialAreaTypeID}, Project Update Batch: {ProjectUpdateBatchID}";
        }
    }
}