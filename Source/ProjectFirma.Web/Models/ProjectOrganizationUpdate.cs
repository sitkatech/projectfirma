namespace ProjectFirma.Web.Models
{
    public partial class ProjectOrganizationUpdate : IAuditableEntity, IProjectOrganization
    {
        public string GetAuditDescriptionString()
        {
            return $"{FieldDefinition.Project.GetFieldDefinitionLabel()} Update Batch: {ProjectUpdateBatchID}, Organization: {OrganizationID}";
        }
    }
}