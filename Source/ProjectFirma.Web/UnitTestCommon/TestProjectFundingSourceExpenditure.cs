using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectFundingSourceExpenditure
        {
            public static ProjectFundingSourceExpenditure Create()
            {
                var project = TestProject.Create();
                var fundingSource = TestFundingSource.Create();
                return Create(project, fundingSource);
            }

            public static ProjectFundingSourceExpenditure Create(Project project, FundingSource fundingSource)
            {
                var projectFundingSourceExpenditure = ProjectFundingSourceExpenditure.CreateNewBlank(project, fundingSource);
                return projectFundingSourceExpenditure;
            }

            public static ProjectFundingSourceExpenditure Create(Project project, FundingSource fundingSource, int calendarYear)
            {
                var projectFundingSourceExpenditure = Create(project, fundingSource);
                projectFundingSourceExpenditure.CalendarYear = calendarYear;
                return projectFundingSourceExpenditure;
            }

            public static ProjectFundingSourceExpenditure Create(Project project, FundingSource fundingSource, int calendarYear, decimal expenditureAmount)
            {
                var projectFundingSourceExpenditure = Create(project, fundingSource, calendarYear);
                projectFundingSourceExpenditure.ExpenditureAmount = expenditureAmount;
                return projectFundingSourceExpenditure;
            }
        }
    }
}