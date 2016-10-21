using System.Collections.Generic;
using System.Linq;
using ApprovalTests.Reporters;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    [TestFixture]
    public class FundingSourceCalendarYearExpenditureTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CreateFromFundingSourcesAndCalendarYearsTest()
        {
            // Arrange
            var fundingSource1 = TestFramework.TestFundingSource.Create();
            fundingSource1.FundingSourceName = "Funding Source 1";
            var fundingSource2 = TestFramework.TestFundingSource.Create();
            fundingSource2.FundingSourceName = "Funding Source 2";
            var fundingSource3 = TestFramework.TestFundingSource.Create();
            fundingSource3.FundingSourceName = "Funding Source 3";
            var fundingSource4 = TestFramework.TestFundingSource.Create();
            fundingSource4.FundingSourceName = "Funding Source 4";
            var calendarYears = new List<int> {2010, 2011, 2012, 2013, 2014};
            var fundingSources = new List<Models.FundingSource> {fundingSource1, fundingSource2, fundingSource3, fundingSource4};

            var project = TestFramework.TestProject.Create();

            var projectFundingSourceExpenditure1 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource1, 2010, 1000);
            var projectFundingSourceExpenditure2 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource1, 2011, 2000);
            var projectFundingSourceExpenditure3 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource2, 2012, 3000);
            var projectFundingSourceExpenditure4 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource3, 2014, 4000);
            var projectFundingSourceExpenditure5 = TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource4, 2012, 5000);

            var projectFundingSourceExpenditures = new List<Models.ProjectFundingSourceExpenditure>
            {
                projectFundingSourceExpenditure1,
                projectFundingSourceExpenditure2,
                projectFundingSourceExpenditure3,
                projectFundingSourceExpenditure4,
                projectFundingSourceExpenditure5
            };

            // Act
            var result = FundingSourceCalendarYearExpenditure.CreateFromFundingSourcesAndCalendarYears(new List<IFundingSourceExpenditure>(projectFundingSourceExpenditures), calendarYears);

            // Assert
            Assert.That(result.Count, Is.EqualTo(fundingSources.Count));
            ObjectApproval.ObjectApprover.VerifyWithJson(result.Select(x => new {x.FundingSourceName, x.CalendarYearExpenditure}));
        }
    }
}