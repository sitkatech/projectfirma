namespace ProjectFirmaModels.Models
{
    public class ProjectOrganizationRelationship
    {
        public Project Project { get; }
        public Organization Organization { get; }
        public string RelationshipTypeName { get; }
        public string DisplayCssClass { get; }


        public ProjectOrganizationRelationship(Project project, Organization organization, RelationshipType relationshipType)
        {
            Project = project;
            Organization = organization;
            RelationshipTypeName = relationshipType.RelationshipTypeName;
        }

        public ProjectOrganizationRelationship(Project project, Organization organization, string relationshipTypeName)
        {
            Project = project;
            Organization = organization;
            RelationshipTypeName = relationshipTypeName;
        }

        public ProjectOrganizationRelationship(Project project, Organization organization, RelationshipType relationshipType, string displayCssClass) : this(project, organization, relationshipType)
        {
            DisplayCssClass = displayCssClass;
        }
    }
}