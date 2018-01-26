
namespace ProjectFirma.Web.Models
{
    public interface IProjectOrganization
    {
        Organization Organization { get; set; }

        RelationshipType RelationshipType { get; set; }
    }
}