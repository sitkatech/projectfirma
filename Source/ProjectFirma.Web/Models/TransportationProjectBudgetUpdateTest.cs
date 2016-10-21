using System.Linq;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class TransportationProjectBudgetUpdateTest
    {
        [Test]
        public void CloneTransportationProjectBudgetTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            var fundingSource1 = TestFramework.TestFundingSource.Create();

            // Arrange: test cloning a EIPPerformanceMeasureActual
            var transportationProjectBudget1 = TestFramework.TestTransportationProjectBudget.Create(project, fundingSource1, 2011, 555);

            const int newCalendarYear = 2017;

            // Act && Assert
            var newTransportationProjectBudgetUpdate = TransportationProjectBudgetUpdate.CloneTransportationProjectBudget(projectUpdateBatch, transportationProjectBudget1, newCalendarYear, transportationProjectBudget1.MonetaryAmount);
            AssertCloneTransportationProjectBudgetSuccessful(newTransportationProjectBudgetUpdate, projectUpdateBatch, transportationProjectBudget1, newCalendarYear, transportationProjectBudget1.MonetaryAmount);
        }

        [Test]
        public void CreateFromProjectTestStartYearAndCompletionYearTheSameAsExistingBudgetRecords()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            var projectUpdate = TestFramework.TestProjectUpdate.Create(projectUpdateBatch);

            var fundingSource1 = TestFramework.TestFundingSource.Create();
            var fundingSource2 = TestFramework.TestFundingSource.Create();

            // Arrange: test cloning a EIPPerformanceMeasureActual
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource1, 2011, 555);
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource1, 2012, 666);
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource2, 2013, 777);
            TestFramework.TestTransportationProjectBudget.Create(project, fundingSource2, 2014, 888);

            projectUpdate.PlanningDesignStartYear = project.TransportationProjectBudgets.Min(x => x.CalendarYear);
            projectUpdate.CompletionYear = project.TransportationProjectBudgets.Max(x => x.CalendarYear);

            // Act
            TransportationProjectBudgetUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            AssertThatNoProjectBudgetRecordsLeftBehind(project, projectUpdateBatch);

            Assert.That(project.TransportationProjectBudgets.Count, Is.EqualTo(projectUpdateBatch.TransportationProjectBudgetUpdates.Count), "Should not have any extra records, should be a match with existing Project record");
        }

        private static void AssertThatNoProjectBudgetRecordsLeftBehind(Project project, ProjectUpdateBatch projectUpdateBatch)
        {
            // Assert - all existing rows from the project record should be there
            foreach (var transportationProjectBudget in project.TransportationProjectBudgets)
            {
                var transportationProjectBudgetUpdate =
                    projectUpdateBatch.TransportationProjectBudgetUpdates.SingleOrDefault(
                        x =>
                            x.TransportationProjectCostTypeID == transportationProjectBudget.TransportationProjectCostTypeID && x.CalendarYear == transportationProjectBudget.CalendarYear &&
                            x.FundingSourceID == transportationProjectBudget.FundingSourceID && x.MonetaryAmount == transportationProjectBudget.MonetaryAmount);
                AssertCloneTransportationProjectBudgetSuccessful(transportationProjectBudgetUpdate, projectUpdateBatch, transportationProjectBudget);
            }
        }

        private static void AssertCloneTransportationProjectBudgetSuccessful(TransportationProjectBudgetUpdate newTransportationProjectBudgetUpdate, ProjectUpdateBatch projectUpdateBatch, ITransportationProjectBudgetAmount transportationProjectBudgetAmount)
        {
            Assert.That(newTransportationProjectBudgetUpdate.ProjectUpdateBatchID, Is.EqualTo(projectUpdateBatch.ProjectUpdateBatchID), "Should have assigned it to this project update batch");
            Assert.That(newTransportationProjectBudgetUpdate.TransportationProjectCostTypeID, Is.EqualTo(transportationProjectBudgetAmount.TransportationProjectCostTypeID), "Should have cloned transporation project cost type correctly");
            Assert.That(newTransportationProjectBudgetUpdate.FundingSourceID, Is.EqualTo(transportationProjectBudgetAmount.FundingSourceID), "Should have cloned funding source correctly");
            Assert.That(newTransportationProjectBudgetUpdate.CalendarYear, Is.EqualTo(transportationProjectBudgetAmount.CalendarYear), "Should be set to the new calendar year");
            Assert.That(newTransportationProjectBudgetUpdate.MonetaryAmount, Is.EqualTo(transportationProjectBudgetAmount.MonetaryAmount), "Should be set to the new budget amount");
        }

        private static void AssertCloneTransportationProjectBudgetSuccessful(TransportationProjectBudgetUpdate newTransportationProjectBudgetUpdate, ProjectUpdateBatch projectUpdateBatch, ITransportationProjectBudgetAmount transportationProjectBudgetAmount, int newCalendarYear, decimal? budgetedAmount)
        {
            Assert.That(newTransportationProjectBudgetUpdate.ProjectUpdateBatchID, Is.EqualTo(projectUpdateBatch.ProjectUpdateBatchID), "Should have assigned it to this project update batch");
            Assert.That(newTransportationProjectBudgetUpdate.TransportationProjectCostTypeID, Is.EqualTo(transportationProjectBudgetAmount.TransportationProjectCostTypeID), "Should have cloned transporation project cost type correctly");
            Assert.That(newTransportationProjectBudgetUpdate.FundingSourceID, Is.EqualTo(transportationProjectBudgetAmount.FundingSourceID), "Should have cloned funding source correctly");
            Assert.That(newTransportationProjectBudgetUpdate.CalendarYear, Is.EqualTo(newCalendarYear), "Should be set to the new calendar year");
            Assert.That(newTransportationProjectBudgetUpdate.MonetaryAmount, Is.EqualTo(budgetedAmount), "Should be set to the new budget amount");
        }
    }
}