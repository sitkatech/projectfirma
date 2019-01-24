namespace ProjectFirmaModels.Models
{
    public partial class ImportExternalProjectStaging : IAuditableEntity
    {
        public string GetAuditDescriptionString() =>
            $"Import External {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Staging created by {CreatePerson.GetFullNameFirstLast() ?? "<Person not Found>"} on {CreateDate}";
    }
}
