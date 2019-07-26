using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectFundingSourceBudgetUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectFundingSourceBudgetUpdates = project.ProjectFundingSourceBudgets.Select(
                projectFundingSourceBudget =>
                    new ProjectFundingSourceBudgetUpdate(projectUpdateBatch,
                        projectFundingSourceBudget.FundingSource)
                    {
                        SecuredAmount = projectFundingSourceBudget.SecuredAmount,
                        TargetedAmount = projectFundingSourceBudget.TargetedAmount
                    }
            ).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            IList<ProjectFundingSourceBudget> allProjectFundingSourceBudget)
        {
            var project = projectUpdateBatch.Project;
            project.NoFundingSourceIdentifiedYet = projectUpdateBatch.ProjectUpdate.NoFundingSourceIdentifiedYet;
            project.FundingTypeID = projectUpdateBatch.ProjectUpdate.FundingTypeID;
            var projectFundingSourceExpectedFundingFromProjectUpdate = projectUpdateBatch
                .ProjectFundingSourceBudgetUpdates
                .Select(x => new ProjectFundingSourceBudget(project.ProjectID, x.FundingSource.FundingSourceID)
                    {
                        SecuredAmount = x.SecuredAmount,
                        TargetedAmount = x.TargetedAmount
                    }
                ).ToList();
            project.ProjectFundingSourceBudgets.Merge(projectFundingSourceExpectedFundingFromProjectUpdate,
                allProjectFundingSourceBudget,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.TargetedAmount = y.TargetedAmount;
                }, HttpRequestStorage.DatabaseEntities);
        }
    }
}