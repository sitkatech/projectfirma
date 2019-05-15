//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceRequest]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static TechnicalAssistanceRequest GetTechnicalAssistanceRequest(this IQueryable<TechnicalAssistanceRequest> technicalAssistanceRequests, int technicalAssistanceRequestID)
        {
            var technicalAssistanceRequest = technicalAssistanceRequests.SingleOrDefault(x => x.TechnicalAssistanceRequestID == technicalAssistanceRequestID);
            Check.RequireNotNullThrowNotFound(technicalAssistanceRequest, "TechnicalAssistanceRequest", technicalAssistanceRequestID);
            return technicalAssistanceRequest;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteTechnicalAssistanceRequest(this IQueryable<TechnicalAssistanceRequest> technicalAssistanceRequests, List<int> technicalAssistanceRequestIDList)
        {
            if(technicalAssistanceRequestIDList.Any())
            {
                technicalAssistanceRequests.Where(x => technicalAssistanceRequestIDList.Contains(x.TechnicalAssistanceRequestID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteTechnicalAssistanceRequest(this IQueryable<TechnicalAssistanceRequest> technicalAssistanceRequests, ICollection<TechnicalAssistanceRequest> technicalAssistanceRequestsToDelete)
        {
            if(technicalAssistanceRequestsToDelete.Any())
            {
                var technicalAssistanceRequestIDList = technicalAssistanceRequestsToDelete.Select(x => x.TechnicalAssistanceRequestID).ToList();
                technicalAssistanceRequests.Where(x => technicalAssistanceRequestIDList.Contains(x.TechnicalAssistanceRequestID)).Delete();
            }
        }

        public static void DeleteTechnicalAssistanceRequest(this IQueryable<TechnicalAssistanceRequest> technicalAssistanceRequests, int technicalAssistanceRequestID)
        {
            DeleteTechnicalAssistanceRequest(technicalAssistanceRequests, new List<int> { technicalAssistanceRequestID });
        }

        public static void DeleteTechnicalAssistanceRequest(this IQueryable<TechnicalAssistanceRequest> technicalAssistanceRequests, TechnicalAssistanceRequest technicalAssistanceRequestToDelete)
        {
            DeleteTechnicalAssistanceRequest(technicalAssistanceRequests, new List<TechnicalAssistanceRequest> { technicalAssistanceRequestToDelete });
        }
    }
}