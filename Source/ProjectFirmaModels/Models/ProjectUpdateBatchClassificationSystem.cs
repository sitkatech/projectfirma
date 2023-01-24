namespace ProjectFirmaModels.Models
{
    public partial class ProjectUpdateBatchClassificationSystem : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectUpdateBatchClassificationSystemID: {ProjectUpdateBatchClassificationSystemID}, ProjectUpdateBatch: {ProjectUpdateBatchID}, ClassificationSystem: {ClassificationSystemID}";
        }
    }
}