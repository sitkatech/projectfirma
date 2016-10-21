using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class MonitoringProgramPartner : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var monitoringProgram = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.Find(MonitoringProgramID);
                var organization = HttpRequestStorage.DatabaseEntities.Organizations.Find(OrganizationID);
                var monitoringProgramName = monitoringProgram != null ? monitoringProgram.AuditDescriptionString : ViewUtilities.NotFoundString;
                var organizationName = organization != null ? organization.AuditDescriptionString : ViewUtilities.NotFoundString;
                return string.Format("Monitoring Program: {0}, Organization: {1}", monitoringProgramName, organizationName);
            }
        }
    }
}