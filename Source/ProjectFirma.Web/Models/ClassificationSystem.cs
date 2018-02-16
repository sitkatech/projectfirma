namespace ProjectFirma.Web.Models
{
    public partial class ClassificationSystem : IAuditableEntity
    {
        public string AuditDescriptionString => ClassificationSystemName;

        public string ClassificationSystemNamePluralized => FieldDefinition.PluralizationService.Pluralize(ClassificationSystemName);

    }
}