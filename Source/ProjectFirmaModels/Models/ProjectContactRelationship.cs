namespace ProjectFirmaModels.Models
{
    public class ProjectContactRelationship
    {
        public Project Project { get; }
        public Person Contact { get; }
        public string ContactRelationshipTypeName { get; }
        public string DisplayCssClass { get; }


        public ProjectContactRelationship(Project project, Person contact, ContactRelationshipType contactRelationshipType)
        {
            Project = project;
            Contact = contact;
            ContactRelationshipTypeName = contactRelationshipType.ContactRelationshipTypeName;
        }

        public ProjectContactRelationship(Project project, Person contact, string contactRelationshipTypeName)
        {
            Project = project;
            Contact = contact;
            ContactRelationshipTypeName = contactRelationshipTypeName;
        }

        public ProjectContactRelationship(Project project, Person contact, ContactRelationshipType contactRelationshipType, string displayCssClass) : this(project, contact, contactRelationshipType)
        {
            DisplayCssClass = displayCssClass;
        }
    }
}