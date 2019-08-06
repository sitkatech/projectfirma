using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectOrganizationForDiff : IProjectOrganization
    {
        public ProjectFirmaModels.Models.Organization Organization { get; set; }
        public OrganizationRelationshipType OrganizationRelationshipType { get; set; }

        public int OrganizationID => Organization?.OrganizationID ?? ModelObjectHelpers.NotYetAssignedID;
        public int OrganizationRelationshipTypeID => OrganizationRelationshipType?.OrganizationRelationshipTypeID ?? ModelObjectHelpers.NotYetAssignedID;

        public string DisplayCssClass { get; set; }

        public ProjectOrganizationForDiff(IProjectOrganization iProjectOrganization)
        {
            Organization = iProjectOrganization.Organization;
            OrganizationRelationshipType = iProjectOrganization.OrganizationRelationshipType;
        }

        public ProjectOrganizationForDiff(ProjectFirmaModels.Models.Organization organization, OrganizationRelationshipType organizationRelationshipType, string displayCssClassDeletedElement)
        {
            Organization = organization;
            OrganizationRelationshipType = organizationRelationshipType;
            DisplayCssClass = displayCssClassDeletedElement;
        }
    }
}