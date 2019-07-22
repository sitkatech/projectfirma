namespace ProjectFirmaModels.Models
{
    public partial class ContactType : IAuditableEntity
    {
        public string GetAuditDescriptionString() => ContactTypeName;
    }
}