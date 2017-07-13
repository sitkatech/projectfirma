namespace ProjectFirma.Web.Models
{
    public partial class RelationshipType : IAuditableEntity
    {
        public string AuditDescriptionString => RelationshipTypeName;
    }
}