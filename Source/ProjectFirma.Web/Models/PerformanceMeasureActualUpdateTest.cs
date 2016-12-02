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
    public class PerformanceMeasureActualUpdateTest
    {
        [Test]
        public void ClonePerformanceMeasureValueTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var performanceMeasure = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(performanceMeasure.PerformanceMeasureSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");

            // Arrange: test cloning a PerformanceMeasureActual
            var performanceMeasureActual = TestFramework.TestPerformanceMeasureActual.Create(-2000, project, performanceMeasure, 777, 2014);

            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3000,
                performanceMeasureActual,
                performanceMeasure.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4000,
                performanceMeasureActual,
                performanceMeasure.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5000,
                performanceMeasureActual,
                performanceMeasure.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());

            const int newCalendarYear = 2017;

            // Act && Assert
            AssertClonePerformanceMeasureValueSuccessful(projectUpdateBatch, performanceMeasureActual, newCalendarYear, performanceMeasureActual.ReportedValue);

            // Arrange: test cloning a PerformanceMeasureExpected
            var performanceMeasureExpected = TestFramework.TestPerformanceMeasureExpected.Create(-2001, project, performanceMeasure, 877);

            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-3001,
                performanceMeasureExpected,
                performanceMeasure.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-4001,
                performanceMeasureExpected,
                performanceMeasure.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-5001,
                performanceMeasureExpected,
                performanceMeasure.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());

            // Act && Assert
            AssertClonePerformanceMeasureValueSuccessful(projectUpdateBatch, performanceMeasureExpected, newCalendarYear, performanceMeasureExpected.ReportedValue);
        }

        [Test]
        public void CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYearTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1001, "PerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(performanceMeasure1.PerformanceMeasureSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");
            Assert.That(performanceMeasure2.PerformanceMeasureSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");

            var performanceMeasureActual1 = TestFramework.TestPerformanceMeasureActual.Create(-2000, project, performanceMeasure1, 777, 2009);
            var performanceMeasureActual2 = TestFramework.TestPerformanceMeasureActual.Create(-2001, project, performanceMeasure2, 888, 2009);

            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3000,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4000,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5000,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3001,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4001,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5001,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());

            const int yearToStartFrom = 2010;
            const int endYear = 2014;
            const int numberOfYears = ((endYear - yearToStartFrom) + 1);
            var performanceMeasureValuesToClone = new List<IPerformanceMeasureValue> {performanceMeasureActual1, performanceMeasureActual2};
            var result = PerformanceMeasureActualUpdate.CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                performanceMeasureValuesToClone,
                yearToStartFrom,
                endYear);
            Assert.That(result.Count, Is.EqualTo(performanceMeasureValuesToClone.Count*numberOfYears), "Should have created records from start year to end year");
            Enumerable.Range(yearToStartFrom, numberOfYears).ToList().ForEach(x =>
            {
                AssertClonePerformanceMeasureValueSuccessful(projectUpdateBatch, performanceMeasureActual1, x, null);
                AssertClonePerformanceMeasureValueSuccessful(projectUpdateBatch, performanceMeasureActual2, x, null);
            });
        }

        [Test]
        public void CreateFromProjectExpectNoRecordsWhenThereAreNoActualOrExpectedTest()
        {
            // Scenario 1 # - No existing performance measure actual values, no performance measure expected values
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.PerformanceMeasureActuals.Any(), Is.False, "Precondition: no performance measure actual values");
            Assert.That(project.PerformanceMeasureExpecteds.Any(), Is.False, "Precondition: no performance measure expected values");

            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            Assert.That(projectUpdateBatch.PerformanceMeasureActualUpdates.Count, Is.EqualTo(0), "Should not have any performance measure values");
        }

        [Test]
        public void CreateFromProjectWhenNoActualValuesExpectOnlyCurrentYearIfNoStartYearProvidedAndStartYearToCurrentYearIfThereIsStartYearTest()
        {
            // Scenario 2 # - No existing performance measure actual values, has performance measure expected values
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1001, "PerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            var performanceMeasureExpected1 = TestFramework.TestPerformanceMeasureExpected.Create(-2001, project, performanceMeasure1, 877);
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-3001,
                performanceMeasureExpected1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-4001,
                performanceMeasureExpected1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-5001,
                performanceMeasureExpected1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureExpected2 = TestFramework.TestPerformanceMeasureExpected.Create(-2002, project, performanceMeasure2, 997);
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-3002,
                performanceMeasureExpected2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-4002,
                performanceMeasureExpected2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-5002,
                performanceMeasureExpected2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            Assert.That(project.PerformanceMeasureActuals.Any(), Is.False, "Precondition: no performance measure actual values");
            Assert.That(project.PerformanceMeasureExpecteds.Any(), Is.True, "Precondition: has performance measure expected values");

            // If no start year, it should only create for current year
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            IEnumerable<int> yearsExpected = new[] {currentYear};
            AssertFutureYearsCreatedCorrectly(projectUpdateBatch.PerformanceMeasureActualUpdates, project.PerformanceMeasureExpecteds, yearsExpected);

            // Set start year
            project.ImplementationStartYear = 2010;
            yearsExpected = Enumerable.Range(project.ImplementationStartYear.Value, currentYear - project.ImplementationStartYear.Value + 1);
            // we expect the PM expected values to be copied from Start Year to current year
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);
            AssertFutureYearsCreatedCorrectly(projectUpdateBatch.PerformanceMeasureActualUpdates, project.PerformanceMeasureExpecteds, yearsExpected);
        }

        [Test]
        public void CreateFromProjectWhenNoCompletionYearAndHaveActualValuesExpectValuesFromLastEnteredYearToCurrentYearTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1001, "PerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.CompletionYear, Is.Null, "Precondition: Project Completion Year should not be set");

            var performanceMeasureActual1 = TestFramework.TestPerformanceMeasureActual.Create(-2001, project, performanceMeasure1, 177, 2010);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual2 = TestFramework.TestPerformanceMeasureActual.Create(-2002, project, performanceMeasure2, 297, 2011);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual3 = TestFramework.TestPerformanceMeasureActual.Create(-2003, project, performanceMeasure1, 377, 2011);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual4 = TestFramework.TestPerformanceMeasureActual.Create(-2004, project, performanceMeasure2, 497, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual5 = TestFramework.TestPerformanceMeasureActual.Create(-2005, project, performanceMeasure1, 577, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual6 = TestFramework.TestPerformanceMeasureActual.Create(-2006, project, performanceMeasure2, 697, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.Last());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.Last());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.Last());
            Assert.That(project.PerformanceMeasureActuals.Any(), Is.True, "Precondition: has performance measure expected values");

            // Act
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var maxEnteredYear = project.PerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.PerformanceMeasureActuals, currentYear, maxEnteredYear);
        }

        [Test]
        public void CreateFromProjectWhenHaveCompletionYearEarlierThanCurrentYearAndHaveActualValuesExpectValuesFromLastEnteredYearToCompletionYearTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            project.CompletionYear = 2013;
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1001, "PerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.CompletionYear, Is.LessThanOrEqualTo(DateTime.Today.Year), "Precondition: Project Completion Year should be less than or equal to current year");

            var performanceMeasureActual1 = TestFramework.TestPerformanceMeasureActual.Create(-2001, project, performanceMeasure1, 177, 2010);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual2 = TestFramework.TestPerformanceMeasureActual.Create(-2002, project, performanceMeasure2, 297, 2011);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual3 = TestFramework.TestPerformanceMeasureActual.Create(-2003, project, performanceMeasure1, 377, 2011);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual4 = TestFramework.TestPerformanceMeasureActual.Create(-2004, project, performanceMeasure2, 497, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual5 = TestFramework.TestPerformanceMeasureActual.Create(-2005, project, performanceMeasure1, 577, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual6 = TestFramework.TestPerformanceMeasureActual.Create(-2006, project, performanceMeasure2, 697, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.Last());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.Last());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.Last());
            Assert.That(project.PerformanceMeasureActuals.Any(), Is.True, "Precondition: has performance measure expected values");

            // Act
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var maxEnteredYear = project.PerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.PerformanceMeasureActuals, project.CompletionYear.Value, maxEnteredYear);
        }

        [Test]
        public void CreateFromProjectWhenHaveCompletionYearLaterThanCurrentYearAndHaveActualValuesExpectValuesFromLastEnteredYearToCurrentYearTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            project.CompletionYear = currentYear + 1;
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1001, "PerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(project.CompletionYear, Is.GreaterThan(currentYear), "Precondition: Project Completion Year should be later than current year");

            var performanceMeasureActual1 = TestFramework.TestPerformanceMeasureActual.Create(-2001, project, performanceMeasure1, 177, 2010);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual2 = TestFramework.TestPerformanceMeasureActual.Create(-2002, project, performanceMeasure2, 297, 2011);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual3 = TestFramework.TestPerformanceMeasureActual.Create(-2003, project, performanceMeasure1, 377, 2011);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual3,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual4 = TestFramework.TestPerformanceMeasureActual.Create(-2004, project, performanceMeasure2, 497, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual4,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual5 = TestFramework.TestPerformanceMeasureActual.Create(-2005, project, performanceMeasure1, 577, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual5,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual6 = TestFramework.TestPerformanceMeasureActual.Create(-2006, project, performanceMeasure2, 697, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.Last());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.Last());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5004,
                performanceMeasureActual6,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.Last());
            Assert.That(project.PerformanceMeasureActuals.Any(), Is.True, "Precondition: has performance measure expected values");

            // Act
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var maxEnteredYear = project.PerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.PerformanceMeasureActuals, currentYear, maxEnteredYear);
        }

        [Test]
        public void CreateFromProjectWhenHaveActualAndExpectedValuesShouldUseActualValuesTest()
        {
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            var performanceMeasureExpected = TestFramework.TestPerformanceMeasureExpected.Create(-2001, project, performanceMeasure1, 877);
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-3001,
                performanceMeasureExpected,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-4001,
                performanceMeasureExpected,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureExpectedSubcategoryOption.Create(-5001,
                performanceMeasureExpected,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            var performanceMeasureActual = TestFramework.TestPerformanceMeasureActual.Create(-2002, project, performanceMeasure1, 977, 2012);
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3003,
                performanceMeasureActual,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4003,
                performanceMeasureActual,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5003,
                performanceMeasureActual,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());

            // Act
            PerformanceMeasureActualUpdate.CreateFromProject(projectUpdateBatch);

            // Assert
            var currentYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            var maxEnteredYear = project.PerformanceMeasureActuals.Max(x => x.CalendarYear);
            AssertNewPerformanceMeasureActualUpdateCreatedCorrectly(projectUpdateBatch, project.PerformanceMeasureActuals, currentYear, maxEnteredYear);
        }

        [Test]
        public void CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYearWithExemptionsTest()
        {
            // Arrange
            var project = TestFramework.TestProject.Create(-777, "Project-777");
            var performanceMeasure1 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1000, "PerformanceMeasure1");
            var performanceMeasure2 = TestFramework.TestPerformanceMeasure.CreateWithSubcategories(-1001, "PerformanceMeasure2");
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            var projectExemptReportingYear1 = TestFramework.TestProjectExemptReportingYear.Create(project, 2011);
            var projectExemptReportingYear2 = TestFramework.TestProjectExemptReportingYear.Create(project, 2013);
            var projectExemptReportingYears = new List<ProjectExemptReportingYear> {projectExemptReportingYear1, projectExemptReportingYear2};

            Assert.That(performanceMeasure1.PerformanceMeasureSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");
            Assert.That(performanceMeasure2.PerformanceMeasureSubcategories.Count, Is.GreaterThanOrEqualTo(3), "Precondition: Expecting at least 3 subcategories for the performance measure");

            var performanceMeasureActual1 = TestFramework.TestPerformanceMeasureActual.Create(-2000, project, performanceMeasure1, 777, 2009);
            var performanceMeasureActual2 = TestFramework.TestPerformanceMeasureActual.Create(-2001, project, performanceMeasure2, 888, 2009);

            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3000,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4000,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5000,
                performanceMeasureActual1,
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure1.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-3001,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[0].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-4001,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[1].PerformanceMeasureSubcategoryOptions.First());
            TestFramework.TestPerformanceMeasureActualSubcategoryOption.Create(-5001,
                performanceMeasureActual2,
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2],
                performanceMeasure2.GetPerformanceMeasureSubcategories()[2].PerformanceMeasureSubcategoryOptions.First());

            const int yearToStartFrom = 2010;
            const int endYear = 2014;
            const int numberOfYears = ((endYear - yearToStartFrom) + 1);
            var yearsToFill = Enumerable.Range(yearToStartFrom, numberOfYears).Where(x => !projectExemptReportingYears.Select(y => y.CalendarYear).Contains(x)).ToList();
            var performanceMeasureValuesToClone = new List<IPerformanceMeasureValue> {performanceMeasureActual1, performanceMeasureActual2};
            var result = PerformanceMeasureActualUpdate.CreatePerformanceMeasureActualUpdateRecordsForGivenYearToCurrentYear(projectUpdateBatch,
                performanceMeasureValuesToClone,
                yearToStartFrom,
                endYear);
            Assert.That(result.Count, Is.EqualTo(performanceMeasureValuesToClone.Count*yearsToFill.Count), "Should have created records from start year to end year");
            Assert.That(result.Select(x => x.CalendarYear).Intersect(projectExemptReportingYears.Select(x => x.CalendarYear)), Is.Empty, "Should not have any of the exempt years");
            yearsToFill.ForEach(x =>
            {
                AssertClonePerformanceMeasureValueSuccessful(projectUpdateBatch, performanceMeasureActual1, x, null);
                AssertClonePerformanceMeasureValueSuccessful(projectUpdateBatch, performanceMeasureActual2, x, null);
            });
        }

        private static void AssertNewPerformanceMeasureActualUpdateCreatedCorrectly(ProjectUpdateBatch projectUpdateBatch,
            ICollection<PerformanceMeasureActual> currentProjectPerformanceMeasureValues,
            int currentYear,
            int maxEnteredYear)
        {
            var futurePerformanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates.Where(x => x.CalendarYear > maxEnteredYear).ToList();
            var startYear = maxEnteredYear + 1;
            var yearsExpected = Enumerable.Range(startYear, currentYear - startYear + 1).ToList();
            var projectPerformanceMeasureValuesForMaxEnteredYear = currentProjectPerformanceMeasureValues.Where(x => x.CalendarYear == maxEnteredYear).ToList();
            AssertFutureYearsCreatedCorrectly(futurePerformanceMeasureActualUpdates, projectPerformanceMeasureValuesForMaxEnteredYear, yearsExpected);
            Assert.That(
                projectUpdateBatch.PerformanceMeasureActualUpdates.Where(x => x.CalendarYear <= maxEnteredYear)
                    .Select(pmavu => PerformanceMeasureValueToString(pmavu, pmavu.CalendarYear, pmavu.ActualValue)),
                Is.EquivalentTo(currentProjectPerformanceMeasureValues.Select(pmev => PerformanceMeasureValueToString(pmev, pmev.CalendarYear, pmev.ActualValue))),
                "Should have copied the PM expected values and set them to current year with null actual value");
        }

        private static void AssertFutureYearsCreatedCorrectly(IEnumerable<PerformanceMeasureActualUpdate> futurePerformanceMeasureActualUpdates,
            IEnumerable<IPerformanceMeasureValue> currentProjectPerformanceMeasureValues,
            IEnumerable<int> yearsExpected)
        {
            Assert.That(futurePerformanceMeasureActualUpdates.Select(pmavu => PerformanceMeasureValueToString(pmavu, pmavu.CalendarYear, null)),
                Is.EquivalentTo(currentProjectPerformanceMeasureValues.SelectMany(pmev => yearsExpected.Select(year => PerformanceMeasureValueToString(pmev, year, null)))),
                "Should have copied the PM expected values and set them to the future year with null actual value");
        }

        private static void AssertClonePerformanceMeasureValueSuccessful(ProjectUpdateBatch projectUpdateBatch,
            IPerformanceMeasureValue performanceMeasureValue,
            int newCalendarYear,
            double? reportedValue)
        {
            // Act
            var result = PerformanceMeasureActualUpdate.ClonePerformanceMeasureValue(projectUpdateBatch, performanceMeasureValue, newCalendarYear, reportedValue);

            // Assert
            Assert.That(result.ProjectUpdateBatchID, Is.EqualTo(projectUpdateBatch.ProjectUpdateBatchID), "Should have assigned it to this project update batch");
            Assert.That(result.PerformanceMeasureID, Is.EqualTo(performanceMeasureValue.PerformanceMeasureID), "Should have cloned correctly");
            Assert.That(result.ActualValue, Is.EqualTo(reportedValue), "Should have cloned the reported value correctly");
            Assert.That(result.CalendarYear, Is.EqualTo(newCalendarYear), "Should be set to the new calendar year");
            Assert.That(result.PerformanceMeasureActualSubcategoryOptionUpdates.Select(PerformanceMeasureValueSubcategoryOptionToString),
                Is.EquivalentTo(performanceMeasureValue.PerformanceMeasureSubcategoryOptions.Select(PerformanceMeasureValueSubcategoryOptionToString)),
                "Should have copied the performanceMeasureSubcategory options correctly");
        }

        private static string PerformanceMeasureValueToString(IPerformanceMeasureValue pmev, int year, double? actualValueExpected)
        {
            return string.Format("PerformanceMeasureID: {0}; CalendarYear: {1}; ActualValue: {2}; PerformanceMeasureSubcategoryOptions: {3}",
                pmev.PerformanceMeasureID,
                year,
                actualValueExpected,
                string.Join(", ", pmev.PerformanceMeasureSubcategoryOptions.Select(PerformanceMeasureValueSubcategoryOptionToString)));
        }

        private static string PerformanceMeasureValueSubcategoryOptionToString(IPerformanceMeasureValueSubcategoryOption pmavsco)
        {
            return string.Format("PerformanceMeasureID: {0}, PerformanceMeasureSubcategoryID: {1}, PerformanceMeasureSubcategoryOptionID: {2}",
                pmavsco.PerformanceMeasureID,
                pmavsco.PerformanceMeasureSubcategoryID,
                pmavsco.PerformanceMeasureSubcategoryOption != null ? pmavsco.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionID : ModelObjectHelpers.NotYetAssignedID);
        }
    }
}