//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[TechnicalAssistanceRequest]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
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

    }
}