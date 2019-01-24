namespace ProjectFirmaModels.Models
{
    public partial class ProjectOrganization : IAuditableEntity, IProjectOrganization
    {
        public string GetAuditDescriptionString()
        {
            return $"Project: {ProjectID}, Organization: {OrganizationID}";
        }

        public ProjectOrganization(Organization organization, RelationshipType relationshipType, string displayCssClass)
        {
            Organization = organization;
            RelationshipType = relationshipType;
            DisplayCssClass = displayCssClass;
        }

        public string DisplayCssClass { get; set; }

        public ProjectOrganization(IProjectOrganization projectOrganization)
        {
            Organization = projectOrganization.Organization;
            RelationshipType = projectOrganization.RelationshipType;
        }
    }
}