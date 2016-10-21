using ProjectFirma.Web.Common;
using LtInfo.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectImplementingOrganization : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.Projects.Find(ProjectID);
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.Find(OrganizationID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var organizationName = organization != null ? organization.AuditDescriptionString : ViewUtilities.NotFoundString;
                var isLeadOrganization = IsLeadOrganization.ToYesNo();
                return string.Format("Project: {0}, Organization: {1}, Is Lead Implementer: {2}", projectName, organizationName, isLeadOrganization);
            }
        }
    }
}