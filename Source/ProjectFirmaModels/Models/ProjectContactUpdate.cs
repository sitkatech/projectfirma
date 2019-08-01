namespace ProjectFirmaModels.Models
{
    public partial class ProjectContactUpdate : IAuditableEntity, IProjectContact
    {
        public string GetAuditDescriptionString()
        {
            return $"Project Update Batch: {ProjectUpdateBatchID}, PersonID: {ContactID}";
        }
    }
}