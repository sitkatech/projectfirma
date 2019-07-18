namespace ProjectFirmaModels.Models
{
    public class ProjectOrganizationRelationship
    {
        public Project Project { get; }
        public Organization Organization { get; }
        public string OrganizationRelationshipTypeName { get; }
        public string DisplayCssClass { get; }


        public ProjectOrganizationRelationship(Project project, Organization organization, OrganizationRelationshipType organizationRelationshipType)
        {
            Project = project;
            Organization = organization;
            OrganizationRelationshipTypeName = organizationRelationshipType.OrganizationRelationshipTypeName;
        }

        public ProjectOrganizationRelationship(Project project, Organization organization, string organizationRelationshipTypeName)
        {
            Project = project;
            Organization = organization;
            OrganizationRelationshipTypeName = organizationRelationshipTypeName;
        }

        public ProjectOrganizationRelationship(Project project, Organization organization, OrganizationRelationshipType organizationRelationshipType, string displayCssClass) : this(project, organization, organizationRelationshipType)
        {
            DisplayCssClass = displayCssClass;
        }
    }
}