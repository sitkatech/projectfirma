namespace ProjectFirmaModels.Models
{
    public interface IProjectContact
    {
        Person Contact { get; set; }

        ContactRelationshipType ContactRelationshipType { get; set; }
    }
}