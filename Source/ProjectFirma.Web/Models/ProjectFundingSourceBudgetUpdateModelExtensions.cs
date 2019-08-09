using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectFundingSourceBudgetUpdateModelExtensions
    {
        public static List<int> CalculateCalendarYearRangeForBudgetsWithoutAccountingForExistingYears(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = projectUpdateBatch.ProjectUpdate;
            return FirmaDateUtilities.CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(new List<int>(), projectUpdate, DateTime.Today.Year);
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            if (MultiTenantHelpers.GetTenantAttribute().BudgetType == BudgetType.AnnualBudgetByCostType)
            {
                projectUpdateBatch.ProjectFundingSourceBudgetUpdates = project.ProjectFundingSourceBudgets.Select(
                    projectFundingSourceBudget =>
                        new ProjectFundingSourceBudgetUpdate(projectUpdateBatch, projectFundingSourceBudget.FundingSource, projectFundingSourceBudget.CalendarYear,
                            projectFundingSourceBudget.SecuredAmount ?? 0, projectFundingSourceBudget.TargetedAmount ?? 0, projectFundingSourceBudget.CostTypeID)
                ).ToList();
            }
            else
            {
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
            // this is on project, but setting here since it's related to budget. Maybe move FundingTypeID and NoFundingSourceIdentifiedYet here as well?
            projectUpdateBatch.ExpectedFundingUpdateNote = project.ExpectedFundingUpdateNote;
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch,
            IList<ProjectFundingSourceBudget> allProjectFundingSourceBudget)
        {
            var project = projectUpdateBatch.Project;
            project.NoFundingSourceIdentifiedYet = projectUpdateBatch.ProjectUpdate.NoFundingSourceIdentifiedYet;
            project.ExpectedFundingUpdateNote = projectUpdateBatch.ExpectedFundingUpdateNote;
            project.FundingTypeID = projectUpdateBatch.ProjectUpdate.FundingTypeID;
            var projectFundingSourceExpectedFundingFromProjectUpdate = projectUpdateBatch
                .ProjectFundingSourceBudgetUpdates
                .Select(x => new ProjectFundingSourceBudget(ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue(), project.ProjectID, x.FundingSource.FundingSourceID, 
                        x.SecuredAmount, x.TargetedAmount, x.CalendarYear, x.CostTypeID)
                ).ToList();
            project.ProjectFundingSourceBudgets.Merge(projectFundingSourceExpectedFundingFromProjectUpdate,
                allProjectFundingSourceBudget,
                (x, y) => x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID && x.CalendarYear == y.CalendarYear,
                (x, y) =>
                {
                    x.SecuredAmount = y.SecuredAmount;
                    x.TargetedAmount = y.TargetedAmount;
                }, HttpRequestStorage.DatabaseEntities);
        }
    }
}