using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectFundingSourceExpenditureUpdate
        {
            public static ProjectFundingSourceExpenditureUpdate Create(ProjectUpdateBatch projectUpdateBatch, FundingSource fundingSource, int calendarYear, decimal expenditureAmount)
            {
                var projectFundingSourceExpenditureUpdate = new ProjectFundingSourceExpenditureUpdate(projectUpdateBatch, fundingSource, calendarYear, expenditureAmount);
                return projectFundingSourceExpenditureUpdate;
            }
        }
    }
}