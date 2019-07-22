namespace ProjectFirmaModels.Models
{
    public partial class ContactTypeContactRelationshipType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var contactType = ContactType?.ContactTypeName;
            var contactRelationshipTypeName = ContactRelationshipType?.ContactRelationshipTypeName;
            return $"Contact Type: {contactType}, Contact Relationship Type: {contactRelationshipTypeName}";
        }
    }
}