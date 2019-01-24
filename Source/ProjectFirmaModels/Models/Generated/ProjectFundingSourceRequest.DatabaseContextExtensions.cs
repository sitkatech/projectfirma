//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequest]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceRequest GetProjectFundingSourceRequest(this IQueryable<ProjectFundingSourceRequest> projectFundingSourceRequests, int projectFundingSourceRequestID)
        {
            var projectFundingSourceRequest = projectFundingSourceRequests.SingleOrDefault(x => x.ProjectFundingSourceRequestID == projectFundingSourceRequestID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceRequest, "ProjectFundingSourceRequest", projectFundingSourceRequestID);
            return projectFundingSourceRequest;
        }

    }
}