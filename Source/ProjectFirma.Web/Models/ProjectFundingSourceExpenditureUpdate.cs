using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectFundingSourceExpenditureUpdate : IFundingSourceExpenditure
    {
        public decimal? MonetaryAmount
        {
            get { return ExpenditureAmount; }
        }

        public string ExpenditureAmountDisplay
        {
            get { return ExpenditureAmount.ToStringCurrency(); }
        }

        public static void CreateFromProject(ProjectUpdateBatch projectUpdateBatch)
        {
            var project = projectUpdateBatch.Project;
            projectUpdateBatch.ProjectFundingSourceExpenditureUpdates =
                project.ProjectFundingSourceExpenditures.Select(
                    projectFundingSourceExpenditure =>
                        new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch,
                            projectFundingSourceExpenditure.FundingSource,
                            projectFundingSourceExpenditure.CalendarYear,
                            projectFundingSourceExpenditure.ExpenditureAmount)).ToList();
        }

        public static void CommitChangesToProject(ProjectUpdateBatch projectUpdateBatch, IList<ProjectFundingSourceExpenditure> allProjectFundingSourceExpenditures)
        {
            var project = projectUpdateBatch.Project;
            var projectFundingSourceExpendituresFromProjectUpdate =
                projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.Select(
                    x => new ProjectFundingSourceExpenditure(project.ProjectID, x.FundingSource.FundingSourceID, x.CalendarYear, x.ExpenditureAmount)).ToList();
            project.ProjectFundingSourceExpenditures.Merge(projectFundingSourceExpendituresFromProjectUpdate,
                allProjectFundingSourceExpenditures,
                (x, y) => x.ProjectID == y.ProjectID && x.CalendarYear == y.CalendarYear && x.FundingSourceID == y.FundingSourceID,
                (x, y) => x.ExpenditureAmount = y.ExpenditureAmount);
        }
    }
}