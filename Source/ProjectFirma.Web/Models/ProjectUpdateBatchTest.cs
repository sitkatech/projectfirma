using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.UnitTestCommon;
using ProjectFirma.Web.Areas.EIP.Views.ProjectUpdate;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;
using WebGrease.Css.Extensions;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class ProjectUpdateBatchTest
    {
        [Test]
        public void CreateProjectUpdateBatchAndLogTransitionTest()
        {
            var person = TestFramework.TestPerson.Create();
            var project = TestFramework.TestProject.Create();
            var projectUpdateBatch = ProjectUpdateBatch.CreateProjectUpdateBatchAndLogTransition(project, person);
            Assert.That(projectUpdateBatch, Is.Not.Null, "Should have created one");
            Assert.That(projectUpdateBatch.ProjectUpdateHistories.Count, Is.EqualTo(1), "Should have created a project update history record");
            var projectUpdateHistory = projectUpdateBatch.ProjectUpdateHistories.First();
            Assert.That(projectUpdateHistory.ProjectUpdateState, Is.EqualTo(ProjectUpdateState.Created), "Should have created a project update history record in transition: Created");
            Assert.That(projectUpdateHistory.TransitionDate.ToShortDateString(),
                Is.EqualTo(DateTime.Today.ToShortDateString()),
                "Should have created a project update history record and the date should be today");
        }

        [Test]
        public void ProjectUpdateBatchStatesTest()
        {
            var person = TestFramework.TestPerson.Create();
            var project = TestFramework.TestProject.Create();
            var projectUpdateBatch = ProjectUpdateBatch.CreateProjectUpdateBatchAndLogTransition(project, person);
            var projectUpdate = TestFramework.TestProjectUpdate.Create(projectUpdateBatch);
            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            projectUpdate.PlanningDesignStartYear = currentYear;
            projectUpdate.ImplementationStartYear = currentYear;
            projectUpdate.CompletionYear = currentYear;

            Assert.That(projectUpdateBatch.IsApproved, Is.False);
            Assert.That(projectUpdateBatch.IsSubmitted, Is.False);
            Assert.That(projectUpdateBatch.IsReadyToSubmit, Is.False);
            Assert.That(projectUpdateBatch.IsCreated, Is.True);
            Assert.That(projectUpdateBatch.InEditableState, Is.True);

            var preconditionException = Assert.Catch<PreconditionException>(() => projectUpdateBatch.SubmitToTrpa(person, DateTime.Now.AddDays(1)), "Should not be allowed to submit yet");
            Assert.That(preconditionException.Message, Is.StringContaining("You cannot submit a project update that is not ready to be submitted"));
            TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, currentYear, 1000);
            var organization1 = TestFramework.TestOrganization.Create("Org1");
            var fundingSource1 = TestFramework.TestFundingSource.Create(organization1, "Funding Source 1");
            TestFramework.TestProjectFundingSourceExpenditureUpdate.Create(projectUpdateBatch, fundingSource1, currentYear, 2000);
            projectUpdate.ProjectLocationSimpleTypeID = ProjectLocationSimpleType.None.ProjectLocationSimpleTypeID;
            projectUpdate.ProjectLocationNotes = "No location for now";

            projectUpdateBatch.SubmitToTrpa(person, DateTime.Now.AddDays(1));
            Assert.That(projectUpdateBatch.IsApproved, Is.False);
            Assert.That(projectUpdateBatch.IsReadyToSubmit, Is.False);
            Assert.That(projectUpdateBatch.IsSubmitted, Is.True);
            Assert.That(projectUpdateBatch.IsCreated, Is.False);
            Assert.That(projectUpdateBatch.InEditableState, Is.False);

            projectUpdateBatch.RejectSubmission(person, DateTime.Now.AddDays(2));
            Assert.That(projectUpdateBatch.IsApproved, Is.False);
            Assert.That(projectUpdateBatch.IsReadyToSubmit, Is.True);
            Assert.That(projectUpdateBatch.IsSubmitted, Is.False);
            Assert.That(projectUpdateBatch.IsCreated, Is.False);
            Assert.That(projectUpdateBatch.InEditableState, Is.True);

            preconditionException =
                Assert.Catch<PreconditionException>(
                    () =>
                        projectUpdateBatch.Approve(person,
                            DateTime.Now.AddDays(4),
                            new List<ProjectExemptReportingYear>(),
                            new List<ProjectFundingSourceExpenditure>(),
                            new List<TransportationProjectBudget>(),
                            new List<EIPPerformanceMeasureActual>(),
                            new List<EIPPerformanceMeasureActualSubcategoryOption>(),
                            new List<ProjectExternalLink>(),
                            new List<ProjectNote>(),
                            new List<ProjectImage>(),
                            new List<ProjectLocation>()),
                    "Should not be allowed to approve yet");
            Assert.That(preconditionException.Message, Is.StringContaining("You cannot approve a project update that has not been submitted"));

            // we have to re submit to get to approve
            projectUpdateBatch.SubmitToTrpa(person, DateTime.Now.AddDays(3));
            Assert.That(projectUpdateBatch.IsApproved, Is.False);
            Assert.That(projectUpdateBatch.IsReadyToSubmit, Is.False);
            Assert.That(projectUpdateBatch.IsSubmitted, Is.True);
            Assert.That(projectUpdateBatch.IsCreated, Is.False);
            Assert.That(projectUpdateBatch.InEditableState, Is.False);

            projectUpdateBatch.Approve(person,
                DateTime.Now.AddDays(4),
                new List<ProjectExemptReportingYear>(),
                new List<ProjectFundingSourceExpenditure>(),
                new List<TransportationProjectBudget>(),
                new List<EIPPerformanceMeasureActual>(),
                new List<EIPPerformanceMeasureActualSubcategoryOption>(),
                new List<ProjectExternalLink>(),
                new List<ProjectNote>(),
                new List<ProjectImage>(),
                new List<ProjectLocation>());
            Assert.That(projectUpdateBatch.IsApproved, Is.True);
            Assert.That(projectUpdateBatch.IsReadyToSubmit, Is.False);
            Assert.That(projectUpdateBatch.IsSubmitted, Is.False);
            Assert.That(projectUpdateBatch.IsCreated, Is.False);
            Assert.That(projectUpdateBatch.InEditableState, Is.False);
        }

        [Test]
        public void GetNewOrCurrentNotApprovedProjectUpdateBatchForProjectNoneExistingTest()
        {
            var person = TestFramework.TestPerson.Create();
            var project = TestFramework.TestProject.Create();
            var currentNotApprovedProjectUpdateBatchForProject = project.GetLatestNotApprovedUpdateBatch() ?? ProjectUpdateBatch.CreateNewProjectUpdateBatchForProject(project, person);
            Assert.That(currentNotApprovedProjectUpdateBatchForProject, Is.Not.Null, "Should have returned a new ProjectUpdateBatch");
            Assert.That(currentNotApprovedProjectUpdateBatchForProject.IsCreated, Is.True, "Should have returned a new ProjectUpdateBatch that is in draft");
            Assert.That(currentNotApprovedProjectUpdateBatchForProject.ProjectID, Is.EqualTo(project.ProjectID), "Should have returned a new ProjectUpdateBatch that is in draft for the given project");
        }

        [Test]
        public void GetNewOrCurrentNotApprovedProjectUpdateBatchForProjectExistingTest()
        {
            var person = TestFramework.TestPerson.Create();
            var project = TestFramework.TestProject.Create();
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            var currentNotApprovedProjectUpdateBatchForProject = project.GetLatestNotApprovedUpdateBatch() ?? ProjectUpdateBatch.CreateNewProjectUpdateBatchForProject(project, person);
            Assert.That(currentNotApprovedProjectUpdateBatchForProject, Is.Not.Null, "Should have returned the existing ProjectUpdateBatch");
            Assert.That(currentNotApprovedProjectUpdateBatchForProject.ProjectUpdateBatchID, Is.EqualTo(projectUpdateBatch.ProjectUpdateBatchID), "Should have returned the existing ProjectUpdateBatch");

            // flip it to submitted
            TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Submitted, person, DateTime.Now.AddDays(1));
            currentNotApprovedProjectUpdateBatchForProject = project.GetLatestNotApprovedUpdateBatch() ?? ProjectUpdateBatch.CreateNewProjectUpdateBatchForProject(project, person);
            Assert.That(currentNotApprovedProjectUpdateBatchForProject, Is.Not.Null, "Should have returned the existing ProjectUpdateBatch, even if it is submitted");
            Assert.That(currentNotApprovedProjectUpdateBatchForProject.ProjectUpdateBatchID,
                Is.EqualTo(projectUpdateBatch.ProjectUpdateBatchID),
                "Should have returned the existing ProjectUpdateBatch, even if it is submitted");

            // flip it to approved
            TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Approved, person, DateTime.Now.AddDays(2));
            currentNotApprovedProjectUpdateBatchForProject = project.GetLatestNotApprovedUpdateBatch() ?? ProjectUpdateBatch.CreateNewProjectUpdateBatchForProject(project, person);
            Assert.That(currentNotApprovedProjectUpdateBatchForProject, Is.Not.Null, "Should have returned a new ProjectUpdateBatch, since the existing one we had has now been Approved");
            Assert.That(currentNotApprovedProjectUpdateBatchForProject.IsCreated,
                Is.True,
                "Should have returned a new ProjectUpdateBatch that is in draft, since the existing one we had has now been Approved");
            Assert.That(currentNotApprovedProjectUpdateBatchForProject.ProjectID,
                Is.EqualTo(project.ProjectID),
                "Should have returned a new ProjectUpdateBatch that is in draft for the given project, since the existing one we had has now been Approved");
        }

        [Test]
        public void GetProjectUpdateStartToCompletionYearRangeTest()
        {
            var project = TestFramework.TestProject.Create();
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(projectUpdateBatch.ProjectUpdate, Is.Null, "Precondition: no project update record yet");

            // Should just have one year, current year
            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, currentYear, currentYear);

            // create a project update record
            var projectUpdate = TestFramework.TestProjectUpdate.Create(projectUpdateBatch);
            Assert.That(projectUpdateBatch.ProjectUpdate.ImplementationStartYear.HasValue, Is.False, "Precondition: Project update record has no start year");
            Assert.That(projectUpdateBatch.ProjectUpdate.CompletionYear.HasValue, Is.False, "Precondition: Project update record has no completion year");
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, currentYear, currentYear);

            // now set a start year
            // start year before minimum year for reporting (2007), no completion year
            projectUpdate.ImplementationStartYear = 2004;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, ProjectFirmaDateUtilities.MinimumYearForReporting, currentYear);

            // start year in the past but greater than minimum year for reporting (2007), no completion year
            projectUpdate.ImplementationStartYear = currentYear - 3;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, projectUpdate.ImplementationStartYear.Value, currentYear);

            // start year in the future, no completion year
            projectUpdate.ImplementationStartYear = currentYear + 1;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, currentYear, currentYear);

            // now set a completion year that is less than current year; expect the range to be start year to completion year
            projectUpdate.ImplementationStartYear = currentYear - 2;
            projectUpdate.CompletionYear = currentYear - 1;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, projectUpdate.ImplementationStartYear.Value, projectUpdate.CompletionYear.Value);

            // now set a completion year that is greater than current year; expect the range to be start year to current year
            projectUpdate.CompletionYear = currentYear + 1;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, projectUpdate.ImplementationStartYear.Value, currentYear);

            // No Start Year
            // 10/30/15 RL:  Rules have changed so that you should never not have a ImplementationStartYear when you get to the Performance Measures area; this is our best guess on what should happen if this anomaly happens
            // now set a completion year before the minimum year for reporting (2007); expect it to be minimum year for reporting (2007) to minimum year for reporting (2007)
            projectUpdate.ImplementationStartYear = null;

            projectUpdate.CompletionYear = 2006;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, ProjectFirmaDateUtilities.MinimumYearForReporting, ProjectFirmaDateUtilities.MinimumYearForReporting);

            // now set a completion year to be <= curent year but greater than minimum year for reporting (2007); expect it to be completion year to completion year
            projectUpdate.CompletionYear = currentYear;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, projectUpdate.CompletionYear.Value, projectUpdate.CompletionYear.Value);

            projectUpdate.CompletionYear = currentYear - 1;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, projectUpdate.CompletionYear.Value, projectUpdate.CompletionYear.Value);

            // now set a completion year to be > curent year; expect it to be current year to current year
            projectUpdate.CompletionYear = currentYear + 1;
            AssertYearRangeForEIPPerformanceMeasuresCorrect(projectUpdateBatch, currentYear, currentYear);

            // invalid year combo; should default to just using the start year
            projectUpdate.ImplementationStartYear = 2012;
            projectUpdate.CompletionYear = 2011;
            
            var result = ProjectUpdateBatch.GetProjectUpdateImplementationStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            Assert.That(result, Is.Empty, "Both start and completion years before the minimum year; expect it to return an empty range");

            // both start and completion years before the minimum year; expect it to return an empty range
            projectUpdate.ImplementationStartYear = 2003;
            projectUpdate.CompletionYear = 2005;
            result = ProjectUpdateBatch.GetProjectUpdateImplementationStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            Assert.That(result, Is.Empty, "Both start and completion years before the minimum year; expect it to return an empty range");

            // both start and completion years after the current year; expect it to return an empty range
            projectUpdate.ImplementationStartYear = currentYear + 2;
            projectUpdate.CompletionYear = currentYear + 4;
            result = ProjectUpdateBatch.GetProjectUpdateImplementationStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            Assert.That(result, Is.Empty, "Both start and completion years after the current year; expect it to return an empty range");
        }
        
        [Test]
        public void GetProjectUpdatePlanningDesignStartToCompletionYearRangeTest()
        {
            var project = TestFramework.TestProject.Create();
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(projectUpdateBatch.ProjectUpdate, Is.Null, "Precondition: no project update record yet");

            // Should just have one year, current year
            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, currentYear, currentYear);

            // create a project update record
            var projectUpdate = TestFramework.TestProjectUpdate.Create(projectUpdateBatch);
            Assert.That(projectUpdateBatch.ProjectUpdate.PlanningDesignStartYear.HasValue, Is.False, "Precondition: Project update record has no start year");
            Assert.That(projectUpdateBatch.ProjectUpdate.CompletionYear.HasValue, Is.False, "Precondition: Project update record has no completion year");
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, currentYear, currentYear);

            // now set a start year
            // start year before minimum year for reporting (2007), no completion year
            projectUpdate.PlanningDesignStartYear = 2004;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, ProjectFirmaDateUtilities.MinimumYearForReporting, currentYear);

            // start year in the past but greater than minimum year for reporting (2007), no completion year
            projectUpdate.PlanningDesignStartYear = currentYear - 3;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, currentYear);

            // start year in the future, no completion year
            projectUpdate.PlanningDesignStartYear = currentYear + 1;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, currentYear, currentYear);

            // now set a completion year that is less than current year; expect the range to be start year to completion year
            projectUpdate.PlanningDesignStartYear = currentYear - 2;
            projectUpdate.CompletionYear = currentYear - 1;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, projectUpdate.CompletionYear.Value);

            // now set a completion year that is greater than current year; expect the range to be start year to current year
            projectUpdate.CompletionYear = currentYear + 1;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, currentYear);

            // No Start Year
            // 10/30/15 RL:  Rules have changed so that you should never not have a PlanningDesignStartYear when you get to the Expenditures area; this is our best guess on what should happen if this anomaly happens
            // now set a completion year before the minimum year for reporting (2007); expect it to be minimum year for reporting (2007) to minimum year for reporting (2007)
            projectUpdate.PlanningDesignStartYear = null;

            projectUpdate.CompletionYear = 2006;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, ProjectFirmaDateUtilities.MinimumYearForReporting, ProjectFirmaDateUtilities.MinimumYearForReporting);

            // now set a completion year to be <= curent year but greater than minimum year for reporting (2007); expect it to be completion year to completion year
            projectUpdate.CompletionYear = currentYear;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, projectUpdate.CompletionYear.Value, projectUpdate.CompletionYear.Value);

            projectUpdate.CompletionYear = currentYear - 1;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, projectUpdate.CompletionYear.Value, projectUpdate.CompletionYear.Value);

            // now set a completion year to be > curent year; expect it to be current year to current year
            projectUpdate.CompletionYear = currentYear + 1;
            AssertYearRangeForExpendituresCorrect(projectUpdateBatch, currentYear, currentYear);

            // invalid year combo; should default to just using the start year
            projectUpdate.PlanningDesignStartYear = 2012;
            projectUpdate.CompletionYear = 2011;

            var result = ProjectUpdateBatch.GetProjectUpdatePlanningDesignStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            Assert.That(result, Is.Empty, "Completion year is before start year; expect it to return an empty range");

            // both start and completion years before the minimum year; expect it to return an empty range
            projectUpdate.PlanningDesignStartYear = 2003;
            projectUpdate.CompletionYear = 2005;
            result = ProjectUpdateBatch.GetProjectUpdatePlanningDesignStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            Assert.That(result, Is.Empty, "Both start and completion years before the minimum year; expect it to return an empty range");

            // both start and completion years after the current year; expect it to return an empty range
            projectUpdate.PlanningDesignStartYear = currentYear + 2;
            projectUpdate.CompletionYear = currentYear + 4;
            result = ProjectUpdateBatch.GetProjectUpdatePlanningDesignStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            Assert.That(result, Is.Empty, "Both start and completion years after the current year; expect it to return an empty range");
        }

        [Test]
        public void GetProjectUpdatePlanningDesignStartToCompletionYearRangeForTransportationProjectBudgetsTest()
        {
            var project = TestFramework.TestProject.Create();
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);

            Assert.That(projectUpdateBatch.ProjectUpdate, Is.Null, "Precondition: no project update record yet");

            // Should just have one year, current year
            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, currentYear, currentYear);

            // create a project update record
            var projectUpdate = TestFramework.TestProjectUpdate.Create(projectUpdateBatch);
            Assert.That(projectUpdateBatch.ProjectUpdate.PlanningDesignStartYear.HasValue, Is.False, "Precondition: Project update record has no start year");
            Assert.That(projectUpdateBatch.ProjectUpdate.CompletionYear.HasValue, Is.False, "Precondition: Project update record has no completion year");
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, currentYear, currentYear);

            // now set a start year
            // start year before minimum year for reporting (2007), no completion year, expect the range to be start year to current year
            projectUpdate.PlanningDesignStartYear = 2004;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, currentYear);

            // start year in the past but greater than minimum year for reporting (2007), expect the range to be start year to current year
            projectUpdate.PlanningDesignStartYear = currentYear - 3;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, currentYear);

            // start year in the future, no completion year, expect the range to be start year to start year
            projectUpdate.PlanningDesignStartYear = currentYear + 1;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, projectUpdate.PlanningDesignStartYear.Value);

            // now set a completion year that is less than current year; expect the range to be start year to completion year
            projectUpdate.PlanningDesignStartYear = currentYear - 2;
            projectUpdate.CompletionYear = currentYear - 1;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, projectUpdate.CompletionYear.Value);

            // now set a completion year that is greater than current year; expect the range to be start year to completion year
            projectUpdate.CompletionYear = currentYear + 3;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, projectUpdate.CompletionYear.Value);

            // No Start Year
            // 10/30/15 RL:  Rules have changed so that you should never not have a PlanningDesignStartYear when you get to the Budgets area; this is our best guess on what should happen if this anomaly happens
            // now set a completion year before the minimum year for reporting (2007); expect it to be completion year to completion year
            projectUpdate.PlanningDesignStartYear = null;

            projectUpdate.CompletionYear = 2006;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.CompletionYear.Value, projectUpdate.CompletionYear.Value);

            // now set a completion year to be <= curent year but greater than minimum year for reporting (2007); expect it to be completion year to completion year
            projectUpdate.CompletionYear = currentYear;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.CompletionYear.Value, projectUpdate.CompletionYear.Value);

            projectUpdate.CompletionYear = currentYear - 1;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.CompletionYear.Value, projectUpdate.CompletionYear.Value);

            // now set a completion year to be > curent year; expect it to be current year to completion year
            projectUpdate.CompletionYear = currentYear + 1;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, currentYear, projectUpdate.CompletionYear.Value);

            // invalid year combo; should throw an exception
            projectUpdate.PlanningDesignStartYear = 2012;
            projectUpdate.CompletionYear = 2011;
            Assert.Throws<PreconditionException>(() => ProjectFirmaDateUtilities.CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(new List<int>(), projectUpdateBatch.ProjectUpdate, ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting()));

            // both start and completion years before the minimum year; expect it to return start to completion year
            projectUpdate.PlanningDesignStartYear = 2003;
            projectUpdate.CompletionYear = 2005;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, projectUpdate.CompletionYear.Value);

            // both start and completion years after the current year; expect it to return start to completion year
            projectUpdate.PlanningDesignStartYear = currentYear + 2;
            projectUpdate.CompletionYear = currentYear + 4;
            AssertYearRangeForBudgetsCorrect(projectUpdateBatch, projectUpdate.PlanningDesignStartYear.Value, projectUpdate.CompletionYear.Value);
        }

        [Test]
        public void ValidateExpendituresAndForceValidationTest()
        {
            var projectUpdate = TestFramework.TestProjectUpdate.Create();
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;
            Assert.That(projectUpdate.PlanningDesignStartYear, Is.Null, "Should not have a Planning/Design Start Year set");

            var result = projectUpdateBatch.ValidateExpendituresAndForceValidation();
            Assert.That(result.IsValid, Is.False, "Should not be valid since we do not have a Planning/Design Start Year set");
            Assert.That(result.GetWarningMessages(), Is.EquivalentTo(new List<string> {ProjectFirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection}));

            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            projectUpdate.PlanningDesignStartYear = 2005;
            projectUpdate.ImplementationStartYear = currentYear;
            AssertExpenditureYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(),
                ProjectFirmaDateUtilities.MinimumYearForReporting,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year before 2007 but no completion year, expect range of 2007 to be at least current year to be missing");

            projectUpdate.PlanningDesignStartYear = currentYear - 3;
            AssertExpenditureYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year but no completion year, expect range of start year to be at least current year to be missing");

            projectUpdate.CompletionYear = currentYear - 1;
            projectUpdate.ImplementationStartYear = currentYear - 1;
            AssertExpenditureYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                false,
                "Has start year and completion year before current year, expect range of start year to completion year to be missing");

            projectUpdate.CompletionYear = currentYear + 1;
            AssertExpenditureYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, expect range of start year to current year to be missing");

            projectUpdate.PlanningDesignStartYear = 2002;
            projectUpdate.ImplementationStartYear = 2003;
            projectUpdate.CompletionYear = 2006;
            result = projectUpdateBatch.ValidateExpendituresAndForceValidation();
            Assert.That(result.IsValid, Is.EqualTo(true), "Should be valid since the project start and completion year is before 2007");
            Assert.That(result.GetWarningMessages(), Is.Empty, "Should not have any validation warnings");

            // now add some expenditure update records
            projectUpdate.PlanningDesignStartYear = currentYear - 1;
            projectUpdate.ImplementationStartYear = currentYear;
            projectUpdate.CompletionYear = currentYear + 2;
            var organization1 = TestFramework.TestOrganization.Create("Org1");
            var fundingSource1 = TestFramework.TestFundingSource.Create(organization1, "Funding Source 1");
            TestFramework.TestProjectFundingSourceExpenditureUpdate.Create(projectUpdateBatch, fundingSource1, currentYear + 2, 1000); // record after current year
            TestFramework.TestProjectFundingSourceExpenditureUpdate.Create(projectUpdateBatch, fundingSource1, projectUpdate.PlanningDesignStartYear.Value - 2, 2000); // record before start year
            AssertExpenditureYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, expenditure record outside of validatable range, expect range of start year to current year to be missing");

            TestFramework.TestProjectFundingSourceExpenditureUpdate.Create(projectUpdateBatch, fundingSource1, projectUpdate.PlanningDesignStartYear.Value, 3000); // record at start year
            TestFramework.TestProjectFundingSourceExpenditureUpdate.Create(projectUpdateBatch, fundingSource1, projectUpdate.CompletionYear.Value, 4000); // record at completion year
            AssertExpenditureYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, expenditure records inside validatable range, expect range of start year to current year to be missing except for the start year and completion year");

            // fill in the other years missing
            ProjectFirmaDateUtilities.GetRangeOfYears(projectUpdate.PlanningDesignStartYear.Value, projectUpdate.CompletionYear.Value)
                .GetMissingYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList().Select(x => x.CalendarYear))
                .ForEach(x => TestFramework.TestProjectFundingSourceExpenditureUpdate.Create(projectUpdateBatch, fundingSource1, x, 5000));
            AssertExpenditureYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                currentYear,
                projectUpdateBatch,
                true,
                "Has start year and completion year after current year, all years filled, should be valid");
        }

        [Test]
        public void ValidateTransportationBudgetsAndForceValidationWhenNotOnFTIPListTest()
        {
            var projectUpdate = TestFramework.TestProjectUpdate.Create();
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;
            Assert.That(projectUpdateBatch.Project.OnFederalTransportationImprovementProgramList, Is.False, "Should not be on FTIP for this test to be useful");

            var result = projectUpdateBatch.ValidateTransportationBudgetsAndForceValidation();
            Assert.That(result.IsValid, Is.True, "Should be valid since we don't care about any Transportation Budgets when project is not on FTIP list");

            // add some Transportation Budget Rows
            var currentYear = DateTime.Today.Year;
            projectUpdate.ImplementationStartYear = currentYear - 1;
            projectUpdate.CompletionYear = currentYear + 2;
            var organization1 = TestFramework.TestOrganization.Create("Org1");
            var fundingSource1 = TestFramework.TestFundingSource.Create(organization1, "Funding Source 1");

            TestFramework.TestTransportationProjectBudgetUpdate.Create(projectUpdateBatch, fundingSource1, TransportationProjectCostType.Construction, currentYear + 2, 1000); // record after current year

            result = projectUpdateBatch.ValidateTransportationBudgetsAndForceValidation();
            Assert.That(result.IsValid, Is.True, "Should be valid since we don't care about any Transportation Budgets when project is not on FTIP list");

            projectUpdateBatch.Project.OnFederalTransportationImprovementProgramList = true;
            Assert.That(projectUpdateBatch.Project.OnFederalTransportationImprovementProgramList, Is.True, "Should be on FTIP for this test to be useful");

            result = projectUpdateBatch.ValidateTransportationBudgetsAndForceValidation();
            Assert.That(result.IsValid, Is.False, "Should not be valid since project is on FTIP list");
        }

        [Test]
        public void ValidateTransportationBudgetsAndForceValidationWhenOnFTIPListTest()
        {
            var projectUpdate = TestFramework.TestProjectUpdate.Create();
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;
            projectUpdateBatch.Project.OnFederalTransportationImprovementProgramList = true;
            Assert.That(projectUpdateBatch.Project.OnFederalTransportationImprovementProgramList, Is.True, "Should be on FTIP for this test to be useful");

            Assert.That(projectUpdate.PlanningDesignStartYear, Is.Null, "Should not have a Planning/Design Start Year set");
            var result = projectUpdateBatch.ValidateTransportationBudgetsAndForceValidation();
            Assert.That(result.IsValid, Is.False, "Should not be valid since we do not have a Planning/Design Start Year set");
            Assert.That(result.GetWarningMessages(), Is.EquivalentTo(new List<string> { ProjectFirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection }));

            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            projectUpdate.PlanningDesignStartYear = 2005;
            projectUpdate.ImplementationStartYear = currentYear;
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                string.Format("Has start year before 2007 but no completion year, expect range of {0} to at least current year to be missing", projectUpdate.ImplementationStartYear));

            projectUpdate.PlanningDesignStartYear = currentYear - 3;
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year but no completion year, expect range of start year to at least current year to be missing");

            projectUpdate.CompletionYear = currentYear - 1;
            projectUpdate.ImplementationStartYear = currentYear - 1;
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                false,
                "Has start year and completion year before current year, expect range of start year to completion year to be missing");

            projectUpdate.CompletionYear = currentYear + 1;
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, expect range of start year to completion year to be missing");

            projectUpdate.PlanningDesignStartYear = 2002;
            projectUpdate.ImplementationStartYear = 2006;
            projectUpdate.CompletionYear = 2006;
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                false,
                "Transportation budgets are not restricted by the Minimum Year for Reporting (2007)");

            // now add some transportation probject budget update records
            projectUpdate.PlanningDesignStartYear = currentYear - 1;
            projectUpdate.ImplementationStartYear = currentYear;
            projectUpdate.CompletionYear = currentYear + 2;
            var organization1 = TestFramework.TestOrganization.Create("Org1");
            var fundingSource1 = TestFramework.TestFundingSource.Create(organization1, "Funding Source 1");

          
            TestFramework.TestTransportationProjectBudgetUpdate.Create(projectUpdateBatch, fundingSource1, TransportationProjectCostType.Construction, currentYear + 2, 1000); // record after current year
            TestFramework.TestTransportationProjectBudgetUpdate.Create(projectUpdateBatch, fundingSource1, TransportationProjectCostType.PreliminaryEngineering, projectUpdate.PlanningDesignStartYear.Value - 2, 2000); // record before start year
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, budget record outside of validatable range, expect range of start year to completion year to be missing");

            TestFramework.TestTransportationProjectBudgetUpdate.Create(projectUpdateBatch, fundingSource1, TransportationProjectCostType.RightOfWay, projectUpdate.PlanningDesignStartYear.Value, 3000); // record at start year
            TestFramework.TestTransportationProjectBudgetUpdate.Create(projectUpdateBatch, fundingSource1, TransportationProjectCostType.PreliminaryEngineering, projectUpdate.CompletionYear.Value, 4000); // record at completion year
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, budget records inside validatable range, expect range of start year to completion year to be missing except for the start year and completion year");

            // fill in the other years missing
            ProjectFirmaDateUtilities.GetRangeOfYears(projectUpdate.PlanningDesignStartYear.Value, projectUpdate.CompletionYear.Value)
                .GetMissingYears(projectUpdateBatch.ProjectFundingSourceExpenditureUpdates.ToList().Select(x => x.CalendarYear))
                .ForEach(x => TestFramework.TestTransportationProjectBudgetUpdate.Create(projectUpdateBatch, fundingSource1, TransportationProjectCostType.Construction, x, 5000));
            AssertBudgetYears(projectUpdateBatch.TransportationProjectBudgetUpdates.ToList(),
                projectUpdate.PlanningDesignStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                true,
                "Has start year and completion year after current year, all years filled, should be valid");
        }

        [Test]
        public void ValidateEIPPerformanceMeasuresAndForceValidationTest()
        {
            var projectUpdate = TestFramework.TestProjectUpdate.Create();
            projectUpdate.ProjectStageID = ProjectStage.Implementation.ProjectStageID;
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;

            Assert.That(projectUpdate.ProjectStage.RequiresEIPPerformanceMeasureActuals(), Is.True, "Should be in stage that requires performance measure actual values");
            Assert.That(projectUpdate.ProjectStage, Is.Not.EqualTo(ProjectStage.PlanningDesign), "Should not be in Planning/Design");
            Assert.That(projectUpdate.ImplementationStartYear, Is.Null, "Should not have an Implementation Start Year set");

            var result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.False, "Should not be valid since we do not have an Implementation Start Year set");
            Assert.That(result.GetWarningMessages(), Is.EquivalentTo(new List<string> { ProjectFirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection }));

            var currentYear = ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            projectUpdate.PlanningDesignStartYear = 2004;
            projectUpdate.ImplementationStartYear = 2005;
            AssertEIPPerformanceMeasures(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList(),
                ProjectFirmaDateUtilities.MinimumYearForReporting,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year before 2007 but no completion year, expect range of 2007 to at least current year to be missing");

            projectUpdate.ImplementationStartYear = currentYear - 3;
            AssertEIPPerformanceMeasures(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList(),
                projectUpdate.ImplementationStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year but no completion year, expect range of start year to at least current year to be missing");

            projectUpdate.CompletionYear = currentYear - 1;
            AssertEIPPerformanceMeasures(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList(),
                projectUpdate.ImplementationStartYear.Value,
                projectUpdate.CompletionYear.Value,
                projectUpdateBatch,
                false,
                "Has start year and completion year before current year, expect range of start year to completion year to be missing");

            projectUpdate.CompletionYear = currentYear + 1;
            AssertEIPPerformanceMeasures(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList(),
                projectUpdate.ImplementationStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, expect range of start year to current year to be missing");

            projectUpdate.PlanningDesignStartYear = 2001;
            projectUpdate.ImplementationStartYear = 2002;
            projectUpdate.CompletionYear = 2006;
            result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.EqualTo(true), "Should be valid since the project start and completion year is before 2007");
            Assert.That(result.GetWarningMessages(), Is.Empty, "Should not have any validation warnings");
            Assert.That(result.EIPPerformanceMeasureActualUpdatesWithWarnings, Is.Empty, "Should have no warnings");

            // now add some performance measure reported value records
            projectUpdate.ImplementationStartYear = currentYear - 1;
            projectUpdate.CompletionYear = currentYear + 2;
            TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, currentYear + 2); // record after current year
            TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, projectUpdate.ImplementationStartYear.Value - 2); // record before start year
            AssertEIPPerformanceMeasures(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList(),
                projectUpdate.ImplementationStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, expenditure record outside of validatable range, expect range of start year to current year to be missing");

            TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, projectUpdate.ImplementationStartYear.Value); // record at start year
            TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, projectUpdate.CompletionYear.Value); // record at completion year
            AssertEIPPerformanceMeasures(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList(),
                projectUpdate.ImplementationStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, expenditure records inside validatable range, expect range of start year to current year to be missing except for the start year and completion year");

            // fill in the other years missing
            ProjectFirmaDateUtilities.GetRangeOfYears(projectUpdate.ImplementationStartYear.Value, projectUpdate.CompletionYear.Value)
                .GetMissingYears(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList().Select(x => x.CalendarYear))
                .ForEach(x => TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, x));
            AssertEIPPerformanceMeasures(projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ToList(),
                projectUpdate.ImplementationStartYear.Value,
                currentYear,
                projectUpdateBatch,
                false,
                "Has start year and completion year after current year, all years filled, just incomplete rows");

            projectUpdateBatch.EIPPerformanceMeasureActualUpdates.ForEach((x, index) => x.ActualValue = index*10);
            result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.True, "Should have no warnings");
            Assert.That(result.GetWarningMessages(), Is.Empty, "Should have no warnings");
            Assert.That(result.EIPPerformanceMeasureActualUpdatesWithWarnings, Is.Empty, "Should have no warnings");
        }

        [Test]
        public void ValidateEIPPerformanceMeasuresAndForceValidationProjectUpdateInPlanningDesignTest()
        {
            var projectUpdate = TestFramework.TestProjectUpdate.Create();
            projectUpdate.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            var projectUpdateBatch = projectUpdate.ProjectUpdateBatch;

            Assert.That(projectUpdate.ProjectStage.RequiresEIPPerformanceMeasureActuals(), Is.False, "Should be in stage that requires performance measure actual values");
            Assert.That(projectUpdate.ProjectStage, Is.EqualTo(ProjectStage.PlanningDesign), "Should not be in Planning/Design");

            Assert.That(projectUpdate.ImplementationStartYear, Is.Null, "Should not have an Implementation Start Year set");
            var result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.False, "Should not be valid since we do not have a Implementation Start Year set");
            Assert.That(result.GetWarningMessages(), Is.EquivalentTo(new List<string> { ProjectFirmaValidationMessages.UpdateSectionIsDependentUponBasicsSection }));

            var currentYear = DateTime.Today.Year;
            projectUpdate.ImplementationStartYear = currentYear;
            projectUpdate.PlanningDesignStartYear = currentYear - 1;
            result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.True, "ProjectUpdate in Planning/Design stage, ignore the missing years validation");
            Assert.That(result.GetWarningMessages(), Is.Empty, "ProjectUpdate in Planning/Design stage, ignore the missing years validation");

            // now add some performance measure reported value records
            var eipPerformanceMeasureActualUpdate1 = TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, currentYear); // record after current year
            var eipPerformanceMeasureActualUpdate2 = TestFramework.TestEIPPerformanceMeasureActualUpdate.Create(projectUpdateBatch, currentYear - 1); // record before start year
            result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.False, "Should have warning about incomplete rows");
            Assert.That(result.GetWarningMessages(),
                Is.EquivalentTo(new List<string> {EIPPerformanceMeasuresValidationResult.FoundIncompleteEIPPerformanceMeasureRowsMessage}),
                "Should have warning about incomplete rows");
            Assert.That(result.EIPPerformanceMeasureActualUpdatesWithWarnings,
                Is.EquivalentTo(new HashSet<int>
                {
                    eipPerformanceMeasureActualUpdate1.EIPPerformanceMeasureActualUpdateID,
                    eipPerformanceMeasureActualUpdate2.EIPPerformanceMeasureActualUpdateID
                }),
                "Should have warning about incomplete rows");

            eipPerformanceMeasureActualUpdate1.ActualValue = 10;
            result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.False, "Should have warning about incomplete rows");
            Assert.That(result.GetWarningMessages(),
                Is.EquivalentTo(new List<string> {EIPPerformanceMeasuresValidationResult.FoundIncompleteEIPPerformanceMeasureRowsMessage}),
                "Should have warning about incomplete rows");
            Assert.That(result.EIPPerformanceMeasureActualUpdatesWithWarnings,
                Is.EquivalentTo(new HashSet<int> {eipPerformanceMeasureActualUpdate2.EIPPerformanceMeasureActualUpdateID}),
                "Should have warning about incomplete rows");

            eipPerformanceMeasureActualUpdate2.ActualValue = 20;
            result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.True, "Should have no warnings");
            Assert.That(result.GetWarningMessages(), Is.Empty, "Should have no warnings");
            Assert.That(result.EIPPerformanceMeasureActualUpdatesWithWarnings, Is.Empty, "Should have no warnings");
        }

        private static void AssertExpenditureYears(List<ProjectFundingSourceExpenditureUpdate> projectFundingSourceExpenditureUpdates,
            int startYear,
            int currentYear,
            ProjectUpdateBatch projectUpdateBatch,
            bool isValid,
            string assertionMessage)
        {
            var result = projectUpdateBatch.ValidateExpendituresAndForceValidation();
            Assert.That(result.IsValid, Is.EqualTo(isValid), string.Format("Should be {0}", isValid ? " valid" : "not valid"));

            var currentYearsEntered = projectFundingSourceExpenditureUpdates.Select(y => y.CalendarYear).Distinct().ToList();
            var expectedMissingYears = ProjectFirmaDateUtilities.GetRangeOfYears(startYear, currentYear).Where(x => !currentYearsEntered.Contains(x)).ToList();
            var fundingSources = projectFundingSourceExpenditureUpdates.Select(x => x.FundingSource).Distinct().ToList();
            if (!fundingSources.Any())
            {
                if (expectedMissingYears.Any())
                {
                    Assert.That(result.GetWarningMessages(),
                        Is.EquivalentTo(new List<string> {string.Format("Missing Expenditures for {0}", string.Join(", ", expectedMissingYears))}),
                        assertionMessage);
                }
                else
                {
                    Assert.That(result.GetWarningMessages(), Is.Empty, assertionMessage);
                }
            }
            else
            {
                // right now the test is constrained to just one funding source
                if (expectedMissingYears.Any())
                {
                    Assert.That(result.GetWarningMessages(),
                        Is.EquivalentTo(new List<string>
                        {
                            string.Format("Missing Expenditures for Funding Source '{0}' for the following years: {1}", fundingSources.First().DisplayName, string.Join(", ", expectedMissingYears))
                        }),
                        assertionMessage);
                }
                else
                {
                    Assert.That(result.GetWarningMessages(), Is.Empty, assertionMessage);
                }
            }
        }

        private static void AssertBudgetYears(List<TransportationProjectBudgetUpdate> transportationProjectBudgetUpdates,
            int startYear,
            int currentYear,
            ProjectUpdateBatch projectUpdateBatch,
            bool isValid,
            string assertionMessage)
        {
            var result = projectUpdateBatch.ValidateTransportationBudgetsAndForceValidation();
            Assert.That(result.IsValid, Is.EqualTo(isValid), string.Format("Should be {0}", isValid ? " valid" : "not valid"));

            var currentYearsEntered = transportationProjectBudgetUpdates.Select(y => y.CalendarYear).Distinct().ToList();
            var expectedMissingYears = ProjectFirmaDateUtilities.GetRangeOfYears(startYear, currentYear).Where(x => !currentYearsEntered.Contains(x)).ToList();
            var fundingSources = transportationProjectBudgetUpdates.Select(x => x.FundingSource).Distinct().ToList();
            if (!fundingSources.Any())
            {
                if (expectedMissingYears.Any())
                {
                    Assert.That(result.GetWarningMessages(),
                        Is.EquivalentTo(new List<string> {string.Format("Missing Budget Amounts for {0}", string.Join(", ", expectedMissingYears))}),
                        assertionMessage);
                }
                else
                {
                    Assert.That(result.GetWarningMessages(), Is.Empty, assertionMessage);
                }
            }
            else
            {
                // right now the test is constrained to just one funding source
                if (expectedMissingYears.Any())
                {
                    Assert.That(result.GetWarningMessages(),
                        Is.EquivalentTo(new List<string>
                        {
                            string.Format("Missing Budget Amounts for Funding Source '{0}' for the following years: {1}", fundingSources.First().DisplayName, string.Join(", ", expectedMissingYears))
                        }),
                        assertionMessage);
                }
                else
                {
                    Assert.That(result.GetWarningMessages(), Is.Empty, assertionMessage);
                }
            }
        }

        private static void AssertEIPPerformanceMeasures(List<EIPPerformanceMeasureActualUpdate> eipPerformanceMeasureActualUpdates,
            int startYear,
            int currentYear,
            ProjectUpdateBatch projectUpdateBatch,
            bool isValid,
            string assertionMessage)
        {
            var result = projectUpdateBatch.ValidateEIPPerformanceMeasuresAndForceValidation();
            Assert.That(result.IsValid, Is.EqualTo(isValid), string.Format("Should be {0}", isValid ? " valid" : "not valid"));

            var currentYearsEntered = eipPerformanceMeasureActualUpdates.Select(y => y.CalendarYear).Distinct().ToList();
            var missingReportedValues = eipPerformanceMeasureActualUpdates.Where(x => !x.ActualValue.HasValue).ToList();
            var expectedMissingYears = ProjectFirmaDateUtilities.GetRangeOfYears(startYear, currentYear).Where(x => !currentYearsEntered.Contains(x)).ToList();
            var missingYearsMessage = string.Format("Missing Performance Measures for {0}", string.Join(", ", expectedMissingYears));
            if (expectedMissingYears.Any() && missingReportedValues.Any())
            {
                Assert.That(result.GetWarningMessages(),
                    Is.EquivalentTo(new List<string> {missingYearsMessage, EIPPerformanceMeasuresValidationResult.FoundIncompleteEIPPerformanceMeasureRowsMessage}),
                    assertionMessage);
            }
            else if (expectedMissingYears.Any())
            {
                Assert.That(result.GetWarningMessages(), Is.EquivalentTo(new List<string> {missingYearsMessage}), assertionMessage);
            }
            else if (missingReportedValues.Any())
            {
                Assert.That(result.GetWarningMessages(), Is.EquivalentTo(new List<string> {EIPPerformanceMeasuresValidationResult.FoundIncompleteEIPPerformanceMeasureRowsMessage}), assertionMessage);
            }
            else
            {
                Assert.That(result.GetWarningMessages(), Is.Empty, assertionMessage);
            }
        }

        private static void AssertYearRangeForEIPPerformanceMeasuresCorrect(ProjectUpdateBatch projectUpdateBatch, int startYear, int currentYear)
        {
            var result = ProjectUpdateBatch.GetProjectUpdateImplementationStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            var expectedRange = ProjectFirmaDateUtilities.GetRangeOfYears(startYear, currentYear);
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }

        private static void AssertYearRangeForExpendituresCorrect(ProjectUpdateBatch projectUpdateBatch, int startYear, int currentYear)
        {
            var result = ProjectUpdateBatch.GetProjectUpdatePlanningDesignStartToCompletionYearRange(projectUpdateBatch.ProjectUpdate);
            var expectedRange = ProjectFirmaDateUtilities.GetRangeOfYears(startYear, currentYear);
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }

        private static void AssertYearRangeForBudgetsCorrect(ProjectUpdateBatch projectUpdateBatch, int startYear, int currentYear)
        {
            var result = ProjectFirmaDateUtilities.CalculateCalendarYearRangeForBudgetsAccountingForExistingYears(new List<int>(), projectUpdateBatch.ProjectUpdate, ProjectFirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            var expectedRange = ProjectFirmaDateUtilities.GetRangeOfYears(startYear, currentYear);
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }
    }
}