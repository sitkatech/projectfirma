using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectFundingSourceExpenditureUpdateModelExtensions
    {
        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectFundingSourceExpenditureUpdates =
                project.ProjectFundingSourceExpenditures.Select(
                    projectFundingSourceExpenditure =>
                        new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch,
                            projectFundingSourceExpenditure.FundingSource,
                            projectFundingSourceExpenditure.CalendarYear,
                            projectFundingSourceExpenditure.ExpenditureAmount,
                            projectFundingSourceExpenditure.CostTypeID)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, DatabaseEntities databaseEntities)
        {
            var project = projectUpdateBatch.Project;
            var projectFundingSourceExpendituresFromProjectUpdate =
                projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.Select(
                    x => new ProjectFundingSourceExpenditure(project.ProjectID, x.FundingSource.FundingSourceID, x.CalendarYear, x.ExpenditureAmount, x.CostTypeID)).ToList();
            project.ProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresFromProjectUpdate,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.FundingSourceID == y.FundingSourceID && x.CostTypeID == y.CostTypeID,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount, databaseEntities);
        }

        public static List<int> CalculateCalendarYearRangeForExpenditures(this IList<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates, ProjectUpdate projectUpdate)
        {
            if (projectUpdate.CompletionYear < projectUpdate.ImplementationStartYear) return new List<int>();
            if (projectUpdate.CompletionYear < projectUpdate.PlanningDesignStartYear) return new List<int>();

            var existingYears = projectFundingSourceExpenditureUpdates.Select(x => x.CalendarYear).ToList();
            return FirmaDateUtilities.CalculateCalendarYearRangeForExpendituresAccountingForExistingYears(existingYears, projectUpdate, FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting());
        }

        public static List<int> CalculateCalendarYearRangeForExpendituresWithoutAccountingForExistingYears(this ProjectUpdate projectUpdate)
        {
            if (projectUpdate.CompletionYear < projectUpdate.ImplementationStartYear) return new List<int>();
            if (projectUpdate.CompletionYear < projectUpdate.PlanningDesignStartYear) return new List<int>();

            return FirmaDateUtilities.CalculateCalendarYearRangeForExpendituresAccountingForExistingYears(new List<int>(), projectUpdate, FirmaDateUtilities.CalculateCurrentYearToUseForUpToAllowableInputInReporting());
        }
    }
}