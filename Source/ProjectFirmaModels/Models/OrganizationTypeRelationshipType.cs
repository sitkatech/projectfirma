namespace ProjectFirmaModels.Models
{
    public partial class OrganizationTypeOrganizationRelationshipType : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            var organizationType = OrganizationType?.OrganizationTypeName;
            var organizationRelationshipTypeName = OrganizationRelationshipType?.OrganizationRelationshipTypeName;
            return $"Organization Type: {organizationType}, Organization Relationship Type: {organizationRelationshipTypeName}";
        }
    }
}