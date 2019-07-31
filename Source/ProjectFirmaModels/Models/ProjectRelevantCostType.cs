namespace ProjectFirmaModels.Models
{
    public partial class ProjectRelevantCostType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Project: {ProjectID}, Cost Type ID: {CostTypeID}";
        }
    }
}