namespace ProjectFirmaModels.Models
{
    public class ProjectOrganizationRelationship
    {
        public Project Project { get; }
        public Organization Organization { get; }
        public string OtherPartners { get; }
        public string OrganizationRelationshipTypeName { get; }
        public bool OrganizationRelationshipCanStewardProjects { get; }
        public string DisplayCssClass { get; }


        public ProjectOrganizationRelationship(Project project, Organization organization, OrganizationRelationshipType organizationRelationshipType)
        {
            Project = project;
            Organization = organization;
            OrganizationRelationshipTypeName = organizationRelationshipType.OrganizationRelationshipTypeName;
            OrganizationRelationshipCanStewardProjects = organizationRelationshipType.CanStewardProjects;
        }

        public ProjectOrganizationRelationship(Project project, Organization organization, string organizationRelationshipTypeName, bool canStewardProjects)
        {
            Project = project;
            Organization = organization;
            OrganizationRelationshipTypeName = organizationRelationshipTypeName;
            OrganizationRelationshipCanStewardProjects = canStewardProjects;
        }

        public ProjectOrganizationRelationship(Project project, Organization organization, OrganizationRelationshipType organizationRelationshipType, string displayCssClass) : this(project, organization, organizationRelationshipType)
        {
            DisplayCssClass = displayCssClass;
        }

        public ProjectOrganizationRelationship(Project project, string otherPartners, string organizationRelationshipTypeName, bool canStewardProjects)
        {
            Project = project;
            OtherPartners = otherPartners;
            OrganizationRelationshipTypeName = organizationRelationshipTypeName;
            OrganizationRelationshipCanStewardProjects = canStewardProjects;
        }
    }
}