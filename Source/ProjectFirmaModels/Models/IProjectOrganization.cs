
namespace ProjectFirmaModels.Models
{
    public interface IProjectOrganization
    {
        Organization Organization { get; set; }

        RelationshipType RelationshipType { get; set; }
    }
}