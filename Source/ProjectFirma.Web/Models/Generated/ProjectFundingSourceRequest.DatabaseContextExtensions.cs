//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectFundingSourceRequest]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectFundingSourceRequest GetProjectFundingSourceRequest(this IQueryable<ProjectFundingSourceRequest> projectFundingSourceRequests, int projectFundingSourceRequestID)
        {
            var projectFundingSourceRequest = projectFundingSourceRequests.SingleOrDefault(x => x.ProjectFundingSourceRequestID == projectFundingSourceRequestID);
            Check.RequireNotNullThrowNotFound(projectFundingSourceRequest, "ProjectFundingSourceRequest", projectFundingSourceRequestID);
            return projectFundingSourceRequest;
        }

        public static void DeleteProjectFundingSourceRequest(this List<int> projectFundingSourceRequestIDList)
        {
            if(projectFundingSourceRequestIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequests.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectFundingSourceRequests.Where(x => projectFundingSourceRequestIDList.Contains(x.ProjectFundingSourceRequestID)));
            }
        }

        public static void DeleteProjectFundingSourceRequest(this ICollection<ProjectFundingSourceRequest> projectFundingSourceRequestsToDelete)
        {
            if(projectFundingSourceRequestsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectFundingSourceRequests.RemoveRange(projectFundingSourceRequestsToDelete);
            }
        }

        public static void DeleteProjectFundingSourceRequest(this int projectFundingSourceRequestID)
        {
            DeleteProjectFundingSourceRequest(new List<int> { projectFundingSourceRequestID });
        }

        public static void DeleteProjectFundingSourceRequest(this ProjectFundingSourceRequest projectFundingSourceRequestToDelete)
        {
            DeleteProjectFundingSourceRequest(new List<ProjectFundingSourceRequest> { projectFundingSourceRequestToDelete });
        }
    }
}