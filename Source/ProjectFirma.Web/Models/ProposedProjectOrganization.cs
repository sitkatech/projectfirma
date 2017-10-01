using LtInfo.Common.Views;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProposedProjectOrganization : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var proposedProject = HttpRequestStorage.DatabaseEntities.AllProposedProjects.Find(ProposedProjectID);
                var organization = HttpRequestStorage.DatabaseEntities.AllOrganizations.Find(OrganizationID);
                var proposedProjectName = proposedProject != null ? proposedProject.AuditDescriptionString : ViewUtilities.NotFoundString;
                var organizationName = organization != null ? organization.AuditDescriptionString : ViewUtilities.NotFoundString;
                return $"Proposed Project: {proposedProjectName}, Organization: {organizationName}";
            }
        }
    }
}