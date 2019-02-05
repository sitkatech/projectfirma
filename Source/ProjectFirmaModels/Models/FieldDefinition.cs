namespace ProjectFirmaModels.Models
{
    public partial class FieldDefinition : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"{FieldDefinitionDisplayName} updated";
        }
    }
}