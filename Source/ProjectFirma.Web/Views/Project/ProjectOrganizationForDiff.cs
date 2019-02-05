using LtInfo.Common.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class ProjectOrganizationForDiff : IProjectOrganization
    {
        public ProjectFirmaModels.Models.Organization Organization { get; set; }
        public RelationshipType RelationshipType { get; set; }

        public int OrganizationID => Organization?.OrganizationID ?? ModelObjectHelpers.NotYetAssignedID;
        public int RelationshipTypeID => RelationshipType?.RelationshipTypeID ?? ModelObjectHelpers.NotYetAssignedID;

        public string DisplayCssClass { get; set; }

        public ProjectOrganizationForDiff(IProjectOrganization iProjectOrganization)
        {
            Organization = iProjectOrganization.Organization;
            RelationshipType = iProjectOrganization.RelationshipType;
        }

        public ProjectOrganizationForDiff(ProjectFirmaModels.Models.Organization organization, RelationshipType relationshipType, string displayCssClassDeletedElement)
        {
            Organization = organization;
            RelationshipType = relationshipType;
            DisplayCssClass = displayCssClassDeletedElement;
        }
    }
}