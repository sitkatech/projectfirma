using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.UnitTestCommon;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    [TestFixture]
    public class ProjectTest
    {
        [Test]
        public void ProjectUpdateSubmittedTest()
        {
            // Find all project update batches for given reporting year that are approved
            // If none approved, then look for submitted
            var project = TestFramework.TestProject.Create();
            var reportingYear = FirmaDateUtilities.CalculateCurrentYearToUseForReporting();
            // brand new project, should not have any updates
            AssertThatProjectHasNoSubmittedProjectUpdates(project, new List<int>(), "Brand new project, should not have any project updates submitted");

            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now;
            // brand new project update batch, should still not have any updates
            AssertThatProjectHasNoSubmittedProjectUpdates(project, new List<int>(), "Brand new project update batch, should not have any project updates submitted");

            var person = TestFramework.TestPerson.Create();

            // create a "submitted" transition
            TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Submitted, person);
            Assert.That(project.IsUpdateMandatory, Is.True, "In submitted state, no previous approvals for this reporting year, so we should be true");

            // add an "approved" transition
            TestFramework.TestProjectUpdateHistory.Create(projectUpdateBatch, ProjectUpdateState.Approved, person);
            Assert.That(project.IsUpdateMandatory, Is.True, "In approved state, no previous approvals for this reporting year, so we should be true");

            // user decides to do another update in the same reporting year
            var projectUpdateBatch2 = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch2.LastUpdateDate = DateTime.Now;
            
            AssertThatProjectHasNoSubmittedProjectUpdates(project, new List<int>{ reportingYear }, "Should not have any project updates submitted except for the reporting year");
        }

        private static void AssertThatProjectHasNoSubmittedProjectUpdates(Project project, List<int> reportingYearsToExclude, string assertMessage)
        {
            var rangeOfReportingYears = FirmaDateUtilities.GetRangeOfYears(2014, FirmaDateUtilities.CalculateCurrentYearToUseForReporting());
            rangeOfReportingYears.Where(x => !reportingYearsToExclude.Contains(x)).ToList().ForEach(year => Assert.That(project.IsUpdateMandatory, Is.True, assertMessage));
        }


        [Test]
        public void IsUpdateMandatoryForProjectWithoutExistingUpdateTest()
        {
            var project = TestFramework.TestProject.Create();
            project.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
            project.ProjectStageID = ProjectStage.Implementation.ProjectStageID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
            project.ProjectStageID = ProjectStage.PostImplementation.ProjectStageID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
            project.ProjectStageID = ProjectStage.Completed.ProjectStageID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(false));
            project.ProjectStageID = ProjectStage.Deferred.ProjectStageID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(false));
            project.ProjectStageID = ProjectStage.Terminated.ProjectStageID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(false));
        }

        [Test]
        public void IsUpdateMandatoryForProjectWithUpdateInPreviousReportingYearTest()
        {
            var project = TestFramework.TestProject.Create();
            project.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now.AddYears(-1);
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
        }


        [Test]
        public void IsUpdateMandatoryForProjectWithASingleUpdateInCurrentReportingYearTest()
        {
            var project = TestFramework.TestProject.Create();
            project.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now;

            // create a "created" transition
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Created.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
            // create a "submitted" transition
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Submitted.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
            // create a "returned" transition
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Returned.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
            // create a "submitted" transition
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Submitted.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));
            // create a "approved" transition
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Approved.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(false));
        }

        [Test]
        public void IsUpdateMandatoryForProjectWithMultipleUpdatesInCurrentReportingYearTest()
        {
            var project = TestFramework.TestProject.Create();
            project.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now;
            // create a "approved" transition
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Approved.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(false));

            var projectUpdateBatch2 = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch2.LastUpdateDate = DateTime.Now.AddDays(1);
            projectUpdateBatch2.ProjectUpdateStateID = ProjectUpdateState.Created.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(false));
        }

        [Test]
        public void IsUpdateMandatoryForProjectWitUpdatesInCurrentReportingYearAndPreviousYearTest()
        {
            var project = TestFramework.TestProject.Create();
            project.ProjectStageID = ProjectStage.PlanningDesign.ProjectStageID;
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now.AddYears(-1);
            // create a "approved" transition
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Approved.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));

            var projectUpdateBatch2 = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch2.LastUpdateDate = DateTime.Now;
            projectUpdateBatch2.ProjectUpdateStateID = ProjectUpdateState.Created.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(true));

            projectUpdateBatch2.LastUpdateDate = DateTime.Now.AddDays(1);
            projectUpdateBatch2.ProjectUpdateStateID = ProjectUpdateState.Approved.ProjectUpdateStateID;
            Assert.That(project.IsUpdateMandatory, Is.EqualTo(false));
        }

        [Test]
        public void GetLatestUpdateStateInPreviousReportingYearTest()
        {
            var project = TestFramework.TestProject.Create();
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now.AddYears(-1);
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Submitted.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Submitted));
        }

        [Test]
        public void GetLatestUpdateStateAllInCurrentReportingYearTest()
        {
            var project = TestFramework.TestProject.Create();
            Assert.That(project.GetLatestUpdateState(), Is.Null);
            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Created));
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Submitted.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Submitted));
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Returned.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Returned));
            projectUpdateBatch.ProjectUpdateStateID = ProjectUpdateState.Approved.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Approved));

            var projectUpdateBatch2 = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch2.LastUpdateDate = DateTime.Now.AddDays(1);
            projectUpdateBatch2.ProjectUpdateStateID = ProjectUpdateState.Created.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Created));        
   
            projectUpdateBatch2.ProjectUpdateStateID = ProjectUpdateState.Submitted.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Submitted));

            projectUpdateBatch2.ProjectUpdateStateID = ProjectUpdateState.Approved.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Approved));

            var projectUpdateBatch3 = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch3.LastUpdateDate = DateTime.Now.AddDays(2);
            projectUpdateBatch3.ProjectUpdateStateID = ProjectUpdateState.Created.ProjectUpdateStateID;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Created));           
        }

        [Test]
        public void AddANewBatchWhileAnExistingBatchIsInProgress()
        {
            var project = TestFramework.TestProject.Create();
            Assert.That(project.GetLatestUpdateState(), Is.Null);

            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Created));

            TestFramework.TestProjectUpdateBatch.Create(project);            

            var exception = Assert.Catch(() => project.GetLatestUpdateState());
            Assert.That(exception.Message, Is.EqualTo(FirmaValidationMessages.MoreThanOneProjectUpdateInProgress));
        }

        [Test]
        public void GetLatetsUpdateStateWithProjectUpdateBatchesInMultipleReportingYearsTest()
        {

            var project = TestFramework.TestProject.Create();
            Assert.That(project.GetLatestUpdateState(), Is.Null);

            var projectUpdateBatch = TestFramework.TestProjectUpdateBatch.Create(project);
            projectUpdateBatch.LastUpdateDate = DateTime.Now;
            Assert.That(project.GetLatestUpdateState(), Is.EqualTo(ProjectUpdateState.Created));

            TestFramework.TestProjectUpdateBatch.Create(project);            

            var exception = Assert.Catch(() => project.GetLatestUpdateState());
            Assert.That(exception.Message, Is.EqualTo(FirmaValidationMessages.MoreThanOneProjectUpdateInProgress));
        }
    }
}