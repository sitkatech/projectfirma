using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Views.ProjectBudget
{
    [TestFixture]
    public class EditProjectBudgetsViewModelTest
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
            TestFramework.TestProjectBudget.Create(project, fundingSource1);
            TestFramework.TestProjectBudget.Create(project, fundingSource2);
            TestFramework.TestProjectBudget.Create(project, fundingSource3);
            TestFramework.TestProjectBudget.Create(project, fundingSource4);

            var allFundingSources = new List<Models.FundingSource> {fundingSource1, fundingSource2, fundingSource3, fundingSource4};

            // Act
            var ProjectBudgets = project.ProjectBudgets.ToList();
            var calendarYearRangeForExpenditures = ProjectBudgets.CalculateCalendarYearRangeForBudgets(project);
            var viewModel = new EditProjectBudgetsViewModel(ProjectBudgets, calendarYearRangeForExpenditures);

            // Assert
            Assert.That(viewModel.ProjectBudgets.Select(x => x.FundingSourceID).Distinct(), Is.EquivalentTo(allFundingSources.Select(x => x.FundingSourceID)));
        }
    }
}