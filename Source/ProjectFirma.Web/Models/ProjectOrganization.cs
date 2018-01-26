using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectOrganization : IAuditableEntity, IProjectOrganization
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.Find(OrganizationID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var organizationName = organization != null ? organization.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"Project: {projectName}, Organization: {organizationName}";
            }
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