namespace ProjectFirma.Web.Models
{
    public partial class ImportExternalProjectStaging : IAuditableEntity
    {
        public string AuditDescriptionString =>
            $"Import External {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Staging created by {CreatePerson?.FullNameFirstLast ?? "<Person not Found>"} on {CreateDate}";
    }
}
