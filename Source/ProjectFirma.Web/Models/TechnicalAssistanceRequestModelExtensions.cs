using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class TechnicalAssistanceRequestModelExtensions
    {
        public static string GetEditUrl(this TechnicalAssistanceRequest technicalAssistanceRequest)
        {
            return SitkaRoute<TechnicalAssistanceRequestController>.BuildUrlFromExpression(c => c.EditTechnicalAssistanceRequestsForProject(technicalAssistanceRequest.Project.ProjectID));
        }
    }
}