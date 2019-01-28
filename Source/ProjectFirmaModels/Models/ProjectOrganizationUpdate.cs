namespace ProjectFirmaModels.Models
{
    public partial class ProjectOrganizationUpdate : IAuditableEntity, IProjectOrganization
    {
        public string GetAuditDescriptionString()
        {
            return $"Project Update Batch: {ProjectUpdateBatchID}, Organization: {OrganizationID}";
        }
    }
}