using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public class ProjectFundingSourceSectorExpenditure
    {
        public readonly Project Project;
        public readonly FundingSource FundingSource;
        public readonly decimal ExpenditureAmount;

        public ProjectFundingSourceSectorExpenditure(Project project, FundingSource fundingSource, decimal expenditureAmount)
        {
            Project = project;
            FundingSource = fundingSource;
            ExpenditureAmount = expenditureAmount;
        }

        public static List<ProjectFundingSourceSectorExpenditure> MakeFromProjectFundingSourceExpenditures(List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            return
                projectFundingSourceExpenditures.GroupBy(x => new {x.Project, x.FundingSource})
                    .Select(x => new ProjectFundingSourceSectorExpenditure(x.Key.Project, x.Key.FundingSource, x.Sum(y => y.ExpenditureAmount)))
                    .ToList();
        }
    }
}