namespace ProjectFirmaModels.Models
{
    public partial class ProjectOrganizationUpdate : IAuditableEntity, IProjectOrganization
    {
        public string GetAuditDescriptionString()
        {
            return $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Update Batch: {ProjectUpdateBatchID}, Organization: {OrganizationID}";
        }
    }
}