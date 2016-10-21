using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestFundingSource
        {
            public static FundingSource Create()
            {
                var organization = TestOrganization.Create();
                var fundingSource = FundingSource.CreateNewBlank(organization);
                fundingSource.IsActive = true;
                return fundingSource;
            }

            public static FundingSource Create(Organization organization, string fundingSourceName)
            {
                var fundingSource = new FundingSource(organization, string.Format("{0}{1}", organization.OrganizationName, fundingSourceName), true, false);
                return fundingSource;
            }

            public static FundingSource CreateWithoutChangingName(Organization organization, string fundingSourceName)
            {
                var fundingSource = new FundingSource(organization, fundingSourceName, true, false);
                return fundingSource;
            }

            public static FundingSource Create(DatabaseEntities dbContext)
            {
                var organization = TestOrganization.Insert(dbContext);
                string testFundingSourceName = TestFramework.MakeTestName("Test Funding Source");
                var fundingSource = new FundingSource(organization, testFundingSourceName, true, false);

                dbContext.FundingSources.Add(fundingSource);
                return fundingSource;
            }

            public static FundingSource Insert(DatabaseEntities dbContext)
            {
                var fundingSource = Create(dbContext);
                HttpRequestStorage.DetectChangesAndSave();
                return fundingSource;
            }
        }
    }
}