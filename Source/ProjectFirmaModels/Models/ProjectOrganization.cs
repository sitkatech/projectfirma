namespace ProjectFirmaModels.Models
{
    public partial class ProjectOrganization : IAuditableEntity, IProjectOrganization
    {
        private string _displayCssClass;

        public string GetAuditDescriptionString()
        {
            return $"Project: {ProjectID}, Organization: {OrganizationID}";
        }

        public ProjectOrganization(Organization organization, OrganizationRelationshipType organizationRelationshipType, string displayCssClass)
        {
            Organization = organization;
            OrganizationRelationshipType = organizationRelationshipType;
            SetDisplayCssClass(displayCssClass);
        }

        public void SetDisplayCssClass(string value)
        {
            _displayCssClass = value;
        }

        public string GetDisplayCssClass()
        {
            return _displayCssClass;
        }

        public ProjectOrganization(IProjectOrganization projectOrganization)
        {
            Organization = projectOrganization.Organization;
            OrganizationRelationshipType = projectOrganization.OrganizationRelationshipType;
        }
    }
}