namespace ProjectFirma.Web.Models
{
    public partial class ImportExternalProjectStaging : IAuditableEntity
    {
        public string GetAuditDescriptionString() =>
            $"Import External {FieldDefinition.Project.GetFieldDefinitionLabel()} Staging created by {CreatePerson.GetFullNameFirstLast() ?? "<Person not Found>"} on {CreateDate}";
    }
}
