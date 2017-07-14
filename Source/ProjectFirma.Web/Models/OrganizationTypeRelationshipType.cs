namespace ProjectFirma.Web.Models
{
    public partial class OrganizationTypeRelationshipType : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var organizationType = OrganizationType?.OrganizationTypeName;
                var relationshipType = RelationshipType?.RelationshipTypeName;
                return $"Organization Type: {organizationType}, Relationship Type: {relationshipType}";
            }
        }
    }
}