using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectFundingSourceExpenditure
{
    [TestFixture]
    public class EditProjectFundingSourceExpendituresViewModelTest
    {
        [Test]
        public void AllViewModelFieldsAreSetFromConstructorTest()
        {
            // Arrange
            var fundingSource1 = TestFramework.TestFundingSource.Create();
            var fundingSource2 = TestFramework.TestFundingSource.Create();
            var fundingSource3 = TestFramework.TestFundingSource.Create();
            var fundingSource4 = TestFramework.TestFundingSource.Create();

            var project = TestFramework.TestProject.Create();
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource1);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource2);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource3);
            TestFramework.TestProjectFundingSourceExpenditure.Create(project, fundingSource4);

            var allFundingSources = new List<Models.FundingSource> {fundingSource1, fundingSource2, fundingSource3, fundingSource4};

            // Act
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var calendarYearRangeForExpenditures = projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project);
            var viewModel = new EditProjectFundingSourceExpendituresViewModel(projectFundingSourceExpenditures, calendarYearRangeForExpenditures);

            // Assert
            Assert.That(viewModel.ProjectFundingSourceExpenditures.Select(x => x.FundingSourceID), Is.EquivalentTo(allFundingSources.Select(x => x.FundingSourceID)));
        }
    }
}