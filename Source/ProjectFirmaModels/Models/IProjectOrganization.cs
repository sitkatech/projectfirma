
namespace ProjectFirmaModels.Models
{
    public interface IProjectOrganization
    {
        Organization Organization { get; set; }

        OrganizationRelationshipType OrganizationRelationshipType { get; set; }
    }
}