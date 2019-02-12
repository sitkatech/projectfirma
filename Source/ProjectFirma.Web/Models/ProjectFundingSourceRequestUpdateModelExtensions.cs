using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirmaModels.Models
{
    public static class ProjectFundingSourceRequestUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectFundingSourceRequestUpdates = project.ProjectFundingSourceRequests.Select(
                projectFundingSourceRequest =>
                    new ProjectFundingSourceRequestUpdate(projectUpdateBatch,
                        projectFundingSourceRequest.FundingSource)
                    {
                        SecuredAmount = projectFundingSourceRequest.SecuredAmount,
                        UnsecuredAmount = projectFundingSourceRequest.UnsecuredAmount
                    }
            ).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            IList<ProjectFundingSourceRequest> allProjectFundingSourceRequests)
        {
            var project = projectUpdateBatch.Project;
            var projectFundingSourceExpectedFundingFromProjectUpdate = projectUpdateBatch
                .ProjectFundingSourceRequestUpdates
                .Select(x => new ProjectFundingSourceRequest(project.ProjectID, x.FundingSource.FundingSourceID)
                    {
                        SecuredAmount = x.SecuredAmount,
                        UnsecuredAmount = x.UnsecuredAmount
                    }
                ).ToList();
            project.ProjectFundingSourceRequests.Merge(projectFundingSourceExpectedFundingFromProjectUpdate,
                allProjectFundingSourceRequests,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.UnsecuredAmount = y.UnsecuredAmount;
                }, HttpRequestStorage.DatabaseEntities);
        }
    }
}