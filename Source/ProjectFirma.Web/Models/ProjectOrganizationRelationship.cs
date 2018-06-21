namespace ProjectFirma.Web.Models
{
    public class ProjectOrganizationRelationship
    {
        public Project Project { get; }
        public Organization Organization { get; }
        public RelationshipType RelationshipType { get; }
        public string DisplayCssClass { get; }


        public ProjectOrganizationRelationship(Project project, Organization organization, RelationshipType relationshipType)
        {
            Project = project;
            Organization = organization;
            RelationshipType = relationshipType;
        }

        public ProjectOrganizationRelationship(Project project, Organization organization, RelationshipType relationshipType, string displayCssClass) : this(project, organization, relationshipType)
        {
            DisplayCssClass = displayCssClass;
        }
    }
}