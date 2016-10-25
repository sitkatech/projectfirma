using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common.Models;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class EIPPerformanceMeasureActualUpdateTest
    {
        [Test]
        public void CloneEIPPerformanceMeasureValueTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var eipPerformanceMeasure = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(eipPerformanceMeasure.IndicatorSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");

            // Arrange: test cloning a EIPPerformanceMeasureActual
            var eipPerformanceMeasureActual = TestFramework.TestEIPPerformanceMeasureActual.Create(-2000, project, eipPerformanceMeasure, 777, 2014);

            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3000,
                eipPerformanceMeasureActual,
                eipPerformanceMeasure.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4000,
                eipPerformanceMeasureActual,
                eipPerformanceMeasure.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5000,
                eipPerformanceMeasureActual,
                eipPerformanceMeasure.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());

            const int newCalendarYear = 2017;

            // Act && Assert
            AssertCloneEIPPerformanceMeasureValueSuccessful(projectUpdateBatch, eipPerformanceMeasureActual, newCalendarYear, eipPerformanceMeasureActual.ReportedValue);

            // Arrange: test cloning a EIPPerformanceMeasureExpected
            var eipPerformanceMeasureExpected = TestFramework.TestEIPPerformanceMeasureExpected.Create(-2001, project, eipPerformanceMeasure, 877);

            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-3001,
                eipPerformanceMeasureExpected,
                eipPerformanceMeasure.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-4001,
                eipPerformanceMeasureExpected,
                eipPerformanceMeasure.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-5001,
                eipPerformanceMeasureExpected,
                eipPerformanceMeasure.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());

            // Act && Assert
            AssertCloneEIPPerformanceMeasureValueSuccessful(projectUpdateBatch, eipPerformanceMeasureExpected, newCalendarYear, eipPerformanceMeasureExpected.ReportedValue);
        }

        [Test]
        public void CreateEIPPerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYearTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var eipPerformanceMeasure2 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1001, "EIPPerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(eipPerformanceMeasure1.IndicatorSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");
            Assert.That(eipPerformanceMeasure2.IndicatorSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");

            var eipPerformanceMeasureActual1 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2000, project, eipPerformanceMeasure1, 777, 2009);
            var eipPerformanceMeasureActual2 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2001, project, eipPerformanceMeasure2, 888, 2009);

            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3000,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4000,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5000,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3001,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4001,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5001,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());

            const int yearToStartFrom = 2010;
            const int endYear = 2014;
            const int numberOfYears = ((endYear - yearToStartFrom) + 1);
            var eipPerformanceMeasureValuesToClone = new List<IEIPPerformanceMeasureValue> {eipPerformanceMeasureActual1, eipPerformanceMeasureActual2};
            var result = EIPPerformanceMeasureActualUpdate.CreateEIPPerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                eipPerformanceMeasureValuesToClone,
                yearToStartFrom,
                endYear);
            Assert.That(result.Count, Is.EqualTo(eipPerformanceMeasureValuesToClone.Count*numberOfYears), "Should have created records from start year to end year");
            Enumerable.Range(yearToStartFrom, numberOfYears).ToList().ForEach(x =>
            {
                AssertCloneEIPPerformanceMeasureValueSuccessful(projectUpdateBatch, eipPerformanceMeasureActual1, x, null);
                AssertCloneEIPPerformanceMeasureValueSuccessful(projectUpdateBatch, eipPerformanceMeasureActual2, x, null);
            });
        }

        [Test]
        public void CreateFromProjectExpectNoRecordsWhenThereAreNoActualOrExpectedTest()
        {
            // Scenario 1 # - No existing performance measure actual values, no performance measure expected values
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.EIPPerformanceMeasureActuals.Any(), Is.False, "Precondition: no performance measure actual values");
            Assert.That(project.EIPPerformanceMeasureExpecteds.Any(), Is.False, "Precondition: no performance measure expected values");

            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            Assert.That(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.Count, Is.EqualTo(0), "Should not have any performance measure values");
        }

        [Test]
        public void CreateFromProjectWhenNoActualValuesExpectOnlyCurrentYearIfNoStartYearProvidedAndStartYearToCurrentYearIfThereIsStartYearTest()
        {
            // Scenario 2 # - No existing performance measure actual values, has performance measure expected values
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var eipPerformanceMeasure2 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1001, "EIPPerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            var eipPerformanceMeasureExpected1 = TestFramework.TestEIPPerformanceMeasureExpected.Create(-2001, project, eipPerformanceMeasure1, 877);
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-3001,
                eipPerformanceMeasureExpected1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-4001,
                eipPerformanceMeasureExpected1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-5001,
                eipPerformanceMeasureExpected1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureExpected2 = TestFramework.TestEIPPerformanceMeasureExpected.Create(-2002, project, eipPerformanceMeasure2, 997);
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-3002,
                eipPerformanceMeasureExpected2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-4002,
                eipPerformanceMeasureExpected2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-5002,
                eipPerformanceMeasureExpected2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            Assert.That(project.EIPPerformanceMeasureActuals.Any(), Is.False, "Precondition: no performance measure actual values");
            Assert.That(project.EIPPerformanceMeasureExpecteds.Any(), Is.True, "Precondition: has performance measure expected values");

            // If no start year, it should only create for current year
            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            IEnumerable<int> yearsExpected = new[] {currentYear};
            AssertFutureYearsCreatedCorrectly(projectUpdateBatch.EIPPerformanceMeasureActualUpdates, project.EIPPerformanceMeasureExpecteds, yearsExpected);

            // Set start year
            project.ImplementationStartYear = 2010;
            yearsExpected = Enumerable.Range(project.ImplementationStartYear.Value, currentYear - project.ImplementationStartYear.Value + 1);
            // we expect the PM expected values to be copied from Start Year to current year
            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);
            AssertFutureYearsCreatedCorrectly(projectUpdateBatch.EIPPerformanceMeasureActualUpdates, project.EIPPerformanceMeasureExpecteds, yearsExpected);
        }

        [Test]
        public void CreateFromProjectWhenNoCompletionYearAndHaveActualValuesExpectValuesFromLastEnteredYearToCurrentYearTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var eipPerformanceMeasure2 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1001, "EIPPerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.CompletionYear, Is.Null, "Precondition: Project Completion Year should not be set");

            var eipPerformanceMeasureActual1 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2001, project, eipPerformanceMeasure1, 177, 2010);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual2 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2002, project, eipPerformanceMeasure2, 297, 2011);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual3 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2003, project, eipPerformanceMeasure1, 377, 2011);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual4 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2004, project, eipPerformanceMeasure2, 497, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual5 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2005, project, eipPerformanceMeasure1, 577, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual6 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2006, project, eipPerformanceMeasure2, 697, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.Last());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.Last());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.Last());
            Assert.That(project.EIPPerformanceMeasureActuals.Any(), Is.True, "Precondition: has performance measure expected values");

            // Act
            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var maxEnteredYear = project.EIPPerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewEIPPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.EIPPerformanceMeasureActuals, currentYear, maxEnteredYear);
        }

        [Test]
        public void CreateFromProjectWhenHaveCompletionYearEarlierThanCurrentYearAndHaveActualValuesExpectValuesFromLastEnteredYearToCompletionYearTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            project.CompletionYear = 2013;
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var eipPerformanceMeasure2 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1001, "EIPPerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.CompletionYear, Is.LessThanOrEqualTo(DateTime.Today.Year), "Precondition: Project Completion Year should be less than or equal to current year");

            var eipPerformanceMeasureActual1 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2001, project, eipPerformanceMeasure1, 177, 2010);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual2 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2002, project, eipPerformanceMeasure2, 297, 2011);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual3 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2003, project, eipPerformanceMeasure1, 377, 2011);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual4 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2004, project, eipPerformanceMeasure2, 497, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual5 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2005, project, eipPerformanceMeasure1, 577, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual6 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2006, project, eipPerformanceMeasure2, 697, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.Last());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.Last());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.Last());
            Assert.That(project.EIPPerformanceMeasureActuals.Any(), Is.True, "Precondition: has performance measure expected values");

            // Act
            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var maxEnteredYear = project.EIPPerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewEIPPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.EIPPerformanceMeasureActuals, project.CompletionYear.Value, maxEnteredYear);
        }

        [Test]
        public void CreateFromProjectWhenHaveCompletionYearLaterThanCurrentYearAndHaveActualValuesExpectValuesFromLastEnteredYearToCurrentYearTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            project.CompletionYear = currentYear + 1;
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var eipPerformanceMeasure2 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1001, "EIPPerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.CompletionYear, Is.GreaterThan(currentYear), "Precondition: Project Completion Year should be later than current year");

            var eipPerformanceMeasureActual1 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2001, project, eipPerformanceMeasure1, 177, 2010);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual2 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2002, project, eipPerformanceMeasure2, 297, 2011);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual3 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2003, project, eipPerformanceMeasure1, 377, 2011);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual3,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual4 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2004, project, eipPerformanceMeasure2, 497, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual4,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual5 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2005, project, eipPerformanceMeasure1, 577, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual5,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual6 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2006, project, eipPerformanceMeasure2, 697, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.Last());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.Last());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5004,
                eipPerformanceMeasureActual6,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.Last());
            Assert.That(project.EIPPerformanceMeasureActuals.Any(), Is.True, "Precondition: has performance measure expected values");

            // Act
            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var maxEnteredYear = project.EIPPerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewEIPPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.EIPPerformanceMeasureActuals, currentYear, maxEnteredYear);
        }

        [Test]
        public void CreateFromProjectWhenHaveActualAndExpectedValuesShouldUseActualValuesTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            var eipPerformanceMeasureExpected = TestFramework.TestEIPPerformanceMeasureExpected.Create(-2001, project, eipPerformanceMeasure1, 877);
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-3001,
                eipPerformanceMeasureExpected,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-4001,
                eipPerformanceMeasureExpected,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureExpectedSubcategoryOption.Create(-5001,
                eipPerformanceMeasureExpected,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            var eipPerformanceMeasureActual = TestFramework.TestEIPPerformanceMeasureActual.Create(-2002, project, eipPerformanceMeasure1, 977, 2012);
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3003,
                eipPerformanceMeasureActual,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4003,
                eipPerformanceMeasureActual,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5003,
                eipPerformanceMeasureActual,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());

            // Act
            EIPPerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var maxEnteredYear = project.EIPPerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewEIPPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.EIPPerformanceMeasureActuals, currentYear, maxEnteredYear);
        }

        [Test]
        public void CreateEIPPerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYearWithExemptionsTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var eipPerformanceMeasure1 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1000, "EIPPerformanceMeasure1");
            var eipPerformanceMeasure2 = TestFramework.TestEIPPerformanceMeasure.CreateWithSubcategories(-1001, "EIPPerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            var projectExemptReportingYear1 = TestFramework.TestProjectExemptReportingYear.Create(project, 2011);
            var projectExemptReportingYear2 = TestFramework.TestProjectExemptReportingYear.Create(project, 2013);
            var projectExemptReportingYears = new List<ProjectExemptReportingYear> {projectExemptReportingYear1, projectExemptReportingYear2};

            Assert.That(eipPerformanceMeasure1.IndicatorSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");
            Assert.That(eipPerformanceMeasure2.IndicatorSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");

            var eipPerformanceMeasureActual1 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2000, project, eipPerformanceMeasure1, 777, 2009);
            var eipPerformanceMeasureActual2 = TestFramework.TestEIPPerformanceMeasureActual.Create(-2001, project, eipPerformanceMeasure2, 888, 2009);

            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3000,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4000,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5000,
                eipPerformanceMeasureActual1,
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure1.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-3001,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[0].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-4001,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[1].IndicatorSubcategoryOptions.First());
            TestFramework.TestEIPPerformanceMeasureActualSubcategoryOption.Create(-5001,
                eipPerformanceMeasureActual2,
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2],
                eipPerformanceMeasure2.GetIndicatorSubcategories()[2].IndicatorSubcategoryOptions.First());

            const int yearToStartFrom = 2010;
            const int endYear = 2014;
            const int numberOfYears = ((endYear - yearToStartFrom) + 1);
            var yearsToFill = Enumerable.Range(yearToStartFrom, numberOfYears).Where(x => !projectExemptReportingYears.Select(y => y.CalendarYear).Contains(x)).ToList();
            var eipPerformanceMeasureValuesToClone = new List<IEIPPerformanceMeasureValue> {eipPerformanceMeasureActual1, eipPerformanceMeasureActual2};
            var result = EIPPerformanceMeasureActualUpdate.CreateEIPPerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                eipPerformanceMeasureValuesToClone,
                yearToStartFrom,
                endYear);
            Assert.That(result.Count, Is.EqualTo(eipPerformanceMeasureValuesToClone.Count*yearsToFill.Count), "Should have created records from start year to end year");
            Assert.That(result.Select(x => x.CalendarYear).Intersect(projectExemptReportingYears.Select(x => x.CalendarYear)), Is.Empty, "Should not have any of the exempt years");
            yearsToFill.ForEach(x =>
            {
                AssertCloneEIPPerformanceMeasureValueSuccessful(projectUpdateBatch, eipPerformanceMeasureActual1, x, null);
                AssertCloneEIPPerformanceMeasureValueSuccessful(projectUpdateBatch, eipPerformanceMeasureActual2, x, null);
            });
        }

        private static void AssertNewEIPPerformanceMeasureActualUpdateCreatedCorrectly(ProjectUpdateBatch projectUpdateBatch,
            ICollection<EIPPerformanceMeasureActual> currentProjectEIPPerformanceMeasureValues,
            int currentYear,
            int maxEnteredYear)
        {
            var futureEIPPerformanceMeasureActualUpdates = projectUpdateBatch.EIPPerformanceMeasureActualUpdates.Where(x => x.CalendarYear > maxEnteredYear).ToList();
            var startYear = maxEnteredYear + 1;
            var yearsExpected = Enumerable.Range(startYear, currentYear - startYear + 1).ToList();
            var projectEIPPerformanceMeasureValuesForMaxEnteredYear = currentProjectEIPPerformanceMeasureValues.Where(x => x.CalendarYear == maxEnteredYear).ToList();
            AssertFutureYearsCreatedCorrectly(futureEIPPerformanceMeasureActualUpdates, projectEIPPerformanceMeasureValuesForMaxEnteredYear, yearsExpected);
            Assert.That(
                projectUpdateBatch.EIPPerformanceMeasureActualUpdates.Where(x => x.CalendarYear <= maxEnteredYear)
                    .Select(pmavu => EIPPerformanceMeasureValueToString(pmavu, pmavu.CalendarYear, pmavu.ActualValue)),
                Is.EquivalentTo(currentProjectEIPPerformanceMeasureValues.Select(pmev => EIPPerformanceMeasureValueToString(pmev, pmev.CalendarYear, pmev.ActualValue))),
                "Should have copied the PM expected values and set them to current year with null actual value");
        }

        private static void AssertFutureYearsCreatedCorrectly(IEnumerable<EIPPerformanceMeasureActualUpdate> futureEIPPerformanceMeasureActualUpdates,
            IEnumerable<IEIPPerformanceMeasureValue> currentProjectEIPPerformanceMeasureValues,
            IEnumerable<int> yearsExpected)
        {
            Assert.That(futureEIPPerformanceMeasureActualUpdates.Select(pmavu => EIPPerformanceMeasureValueToString(pmavu, pmavu.CalendarYear, null)),
                Is.EquivalentTo(currentProjectEIPPerformanceMeasureValues.SelectMany(pmev => yearsExpected.Select(year => EIPPerformanceMeasureValueToString(pmev, year, null)))),
                "Should have copied the PM expected values and set them to the future year with null actual value");
        }

        private static void AssertCloneEIPPerformanceMeasureValueSuccessful(ProjectUpdateBatch projectUpdateBatch,
            IEIPPerformanceMeasureValue eipPerformanceMeasureValue,
            int newCalendarYear,
            double? reportedValue)
        {
            // Act
            var result = EIPPerformanceMeasureActualUpdate.CloneEIPPerformanceMeasureValue(projectUpdateBatch, eipPerformanceMeasureValue, newCalendarYear, reportedValue);

            // Assert
            Assert.That(result.ProjectUpdateBatchID, Is.EqualTo(projectUpdateBatch.ProjectUpdateBatchID), "Should have assigned it to this project update batch");
            Assert.That(result.EIPPerformanceMeasureID, Is.EqualTo(eipPerformanceMeasureValue.EIPPerformanceMeasureID), "Should have cloned correctly");
            Assert.That(result.ActualValue, Is.EqualTo(reportedValue), "Should have cloned the reported value correctly");
            Assert.That(result.CalendarYear, Is.EqualTo(newCalendarYear), "Should be set to the new calendar year");
            Assert.That(result.EIPPerformanceMeasureActualSubcategoryOptionUpdates.Select(EIPPerformanceMeasureValueSubcategoryOptionToString),
                Is.EquivalentTo(eipPerformanceMeasureValue.IndicatorSubcategoryOptions.Select(EIPPerformanceMeasureValueSubcategoryOptionToString)),
                "Should have copied the indicatorSubcategory options correctly");
        }

        private static string EIPPerformanceMeasureValueToString(IEIPPerformanceMeasureValue pmev, int year, double? actualValueExpected)
        {
            return string.Format("EIPPerformanceMeasureID: {0}; CalendarYear: {1}; ActualValue: {2}; IndicatorSubcategoryOptions: {3}",
                pmev.EIPPerformanceMeasureID,
                year,
                actualValueExpected,
                string.Join(", ", pmev.IndicatorSubcategoryOptions.Select(EIPPerformanceMeasureValueSubcategoryOptionToString)));
        }

        private static string EIPPerformanceMeasureValueSubcategoryOptionToString(IEIPPerformanceMeasureValueSubcategoryOption pmavsco)
        {
            return string.Format("EIPPerformanceMeasureID: {0}, IndicatorSubcategoryID: {1}, IndicatorSubcategoryOptionID: {2}",
                pmavsco.EIPPerformanceMeasureID,
                pmavsco.IndicatorSubcategoryID,
                pmavsco.IndicatorSubcategoryOption != null ? pmavsco.IndicatorSubcategoryOption.IndicatorSubcategoryOptionID : ModelObjectHelpers.NotYetAssignedID);
        }
    }
}