using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationProjectBudget
{
    [TestFixture]
    public class EditTransportationProjectBudgetsViewModelTest
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
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource1);
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource2);
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource3);
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource4);

            var allFundingSources = new List<Models.FundingSource> {fundingSource1, fundingSource2, fundingSource3, fundingSource4};

            // Act
            var transportationProjectBudgets = project.TransportationProjectBudgets.ToList();
            var calendarYearRangeForExpenditures = transportationProjectBudgets.CalculateCalendarYearRangeForBudgets(project);
            var viewModel = new EditTransportationProjectBudgetsViewModel(transportationProjectBudgets, calendarYearRangeForExpenditures);

            // Assert
            Assert.That(viewModel.TransportationProjectBudgets.Select(x => x.FundingSourceID).Distinct(), Is.EquivalentTo(allFundingSources.Select(x => x.FundingSourceID)));
        }
    }
}