namespace ProjectFirmaModels.Models
{
    public partial class ProjectRelevantCostTypeUpdate : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ProjectUpdateBatch: {ProjectUpdateBatchID}, Cost Type ID: {CostTypeID}";
        }
    }
}