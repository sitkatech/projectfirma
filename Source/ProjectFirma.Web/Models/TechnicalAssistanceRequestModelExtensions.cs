using System.Collections.Generic;
using System.Linq;
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

        public static int GetHoursRequestedTotal(this List<TechnicalAssistanceRequest> technicalAssistanceRequests)
        {
            return technicalAssistanceRequests.Sum(x => x.HoursRequested ?? 0);
        }

        public static int GetHoursAllocatedTotal(this List<TechnicalAssistanceRequest> technicalAssistanceRequests)
        {
            return technicalAssistanceRequests.Sum(x => x.HoursAllocated ?? 0);
        }

        public static int GetHoursProvidedTotal(this List<TechnicalAssistanceRequest> technicalAssistanceRequests)
        {
            return technicalAssistanceRequests.Sum(x => x.HoursProvided ?? 0);
        }

        public static decimal GetDollarValueProvidedTotal(this List<TechnicalAssistanceRequest> technicalAssistanceRequests, List<TechnicalAssistanceParameter> technicalAssistanceParameters)
        {
            return technicalAssistanceRequests.Sum(x => x.GetValueProvided(technicalAssistanceParameters));
        }
    }
}