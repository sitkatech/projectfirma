using System.Data.Entity;
using System.Globalization;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// To test Audit Logging, we need to create, modify, and delete records, exercising as many field types as we can.
    /// It is most important that Audit Logging does not cause a crash. It is also important that Audit Logging 
    /// make proper Audit Logs.
    /// 
    /// I've covered a lot of ground here, but the following classes don't have tests written for them, and could arguably use them.
    /// I've just run out of steam on this effort for now:
    /// 
    /// PerformanceMeasureActual
    /// PerformanceMeasureActualSubcategoryOption
    /// PerformanceMeasureExpected
    /// PerformanceMeasureExpectedSubcategoryOption
    /// ProgramPerformanceMeasure
    /// ProjectThresholdCategory
    /// IndicatorSubcategoryOption
    /// 
    /// -- SLG
    /// </summary>
    [TestFixture]
    public class AuditLogTest : FirmaTestWithContext
    {
        [Test]
        public void GetAuditDescriptionStringIfAnyTest()
        {
            // Arrange
            var dbContext = HttpRequestStorage.DatabaseEntities;
            var objectContext = dbContext.GetObjectContext();
            var testProject = TestFramework.TestProject.Insert(dbContext);
            var originalActionPriorityName = testProject.ActionPriority.ActionPriorityName;
            // Act
            var newActionPriority = TestFramework.TestActionPriority.Create(dbContext);
            HttpRequestStorage.DetectChangesAndSave();

            testProject.ActionPriorityID = newActionPriority.ActionPriorityID;

            var changeTracker = dbContext.ChangeTracker;
            changeTracker.DetectChanges();
            var modifiedEntries = changeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            var dbEntry = modifiedEntries.First();
            var result = AuditLog.GetAuditDescriptionStringIfAnyForProperty(objectContext, dbEntry, "ActionPriorityID", AuditLogEventType.Modified);

            // Assert
            Assert.That(result, Is.EqualTo(string.Format("ActionPriority: {0} changed to {1}", originalActionPriorityName, newActionPriority.ActionPriorityName)));
        }

        [Test]
        public void GetAuditDescriptionStringIfAnyTest2()
        {
            // Arrange
            var dbContext = HttpRequestStorage.DatabaseEntities;
            var objectContext = dbContext.GetObjectContext();
            var testProject = TestFramework.TestProject.Insert(dbContext);
            var originalProjectStageName = ProjectStage.PlanningDesign.ProjectStageDisplayName;
            // Act
            var newProjectStage = ProjectStage.Terminated;
            testProject.ProjectStageID = newProjectStage.ProjectStageID;

            var changeTracker = dbContext.ChangeTracker;
            changeTracker.DetectChanges();
            var modifiedEntries = changeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            var dbEntry = modifiedEntries.First();
            var result = AuditLog.GetAuditDescriptionStringIfAnyForProperty(objectContext, dbEntry, "ProjectStageID", AuditLogEventType.Modified);

            // Assert
            Assert.That(result, Is.EqualTo(string.Format("Project Stage: {0} changed to {1}", originalProjectStageName, newProjectStage.ProjectStageDisplayName)));
        }

        [Test]
        public void GetDeletedEntityAuditDescriptionStringTest()
        {
            // Arrange
            var dbContext = HttpRequestStorage.DatabaseEntities;
            var objectContext = dbContext.GetObjectContext();
            var testProject = TestFramework.TestProject.Insert(dbContext);
            // Act
            HttpRequestStorage.DatabaseEntities.Projects.Remove(testProject);

            var changeTracker = dbContext.ChangeTracker;
            changeTracker.DetectChanges();
            var deletedEntries = changeTracker.Entries().Where(e => e.State == EntityState.Deleted).ToList();
            var dbEntry = deletedEntries.First();
            var objectStateEntry = objectContext.ObjectStateManager.GetObjectStateEntry(dbEntry.Entity);
            var objectByKey = objectContext.GetObjectByKey(objectStateEntry.EntityKey);
            var auditableEntityDeleted = (IAuditableEntity) objectByKey;
            var result = auditableEntityDeleted.AuditDescriptionString;

            // Assert
            Assert.That(result, Is.EqualTo(testProject.AuditDescriptionString));
        }

        [Test]
        public void TestFundingSourceAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test funding source and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;
            var testFundingSource = TestFramework.TestFundingSource.Create(dbContext);
            var testOrganization = TestFramework.TestOrganization.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this FundingSource
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Funding Source named \"{0}\" in Audit Log database entries.", testFundingSource.FundingSourceName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testFundingSource.FundingSourceName)));

            // Change audit logging
            // --------------------

            // Make changes to the Funding Source
            var newFundingSourceName = TestFramework.MakeTestName("New Funding Source Name");
            testFundingSource.FundingSourceName = newFundingSourceName;
            testFundingSource.Organization = testOrganization;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW FundingSource name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newFundingSourceName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.FundingSources.Remove(testFundingSource);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this FundingSource name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "FundingSource" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testFundingSource.FundingSourceID) != null,
                "Could not find deleted Funding Source record");
        }

        [Test]
        public void TestActionPriorityAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test Action Priority and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testActionPriority = TestFramework.TestActionPriority.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this FundingSource
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Action Priority named \"{0}\" in Audit Log database entries.", testActionPriority.ActionPriorityName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testActionPriority.ActionPriorityName)));

            // Change audit logging
            // --------------------

            // Make changes to the Action Priority Source
            var newActionPriorityName = TestFramework.MakeTestName("New Action Priority Name", ActionPriority.FieldLengths.ActionPriorityName);
            testActionPriority.ActionPriorityName = newActionPriorityName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newActionPriorityName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.ActionPriorities.Remove(testActionPriority);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this FundingSource name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "ActionPriority" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testActionPriority.ActionPriorityID) != null,
                "Could not find deleted Action Priority record");
        }

        [Test]
        public void TestProjectAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testProject = TestFramework.TestProject.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Project named \"{0}\" in Audit Log database entries.", testProject.ProjectName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testProject.ProjectName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newProjectName = TestFramework.MakeTestName("New Project Name", Project.FieldLengths.ProjectName);
            testProject.ProjectName = newProjectName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newProjectName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.Projects.Remove(testProject);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Project name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Project" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testProject.ProjectID) != null,
                "Could not find deleted project record");
        }

        [Test]
        public void TestFocusAreaAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testFocusArea = TestFramework.TestFocusArea.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for FocusArea named \"{0}\" in Audit Log database entries.", testFocusArea.FocusAreaName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testFocusArea.FocusAreaName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newFocusAreaName = TestFramework.MakeTestName("New FocusArea Name", FocusArea.FieldLengths.FocusAreaName);
            testFocusArea.FocusAreaName = newFocusAreaName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newFocusAreaName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.FocusAreas.Remove(testFocusArea);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this FocusArea name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "FocusArea" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testFocusArea.FocusAreaID) != null,
                "Could not find deleted FocusArea record");
        }

        [Test]
        public void TestOrganizationAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testOrganization = TestFramework.TestOrganization.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Organization named \"{0}\" in Audit Log database entries.", testOrganization.OrganizationName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testOrganization.OrganizationName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newOrganizationName = TestFramework.MakeTestName("New Organization Name", Organization.FieldLengths.OrganizationName);
            testOrganization.OrganizationName = newOrganizationName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newOrganizationName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.Organizations.Remove(testOrganization);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Organization name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Organization" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testOrganization.OrganizationID) != null,
                "Could not find deleted Organization record");
        }

        [Test]
        public void TestProgramAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testProgram = TestFramework.TestProgram.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Program named \"{0}\" in Audit Log database entries.", testProgram.ProgramName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testProgram.ProgramName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newProgramName = TestFramework.MakeTestName("New Program Name", Program.FieldLengths.ProgramName);
            testProgram.ProgramName = newProgramName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newProgramName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.Programs.Remove(testProgram);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Program name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Program" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testProgram.ProgramID) != null,
                "Could not find deleted Program record");
        }

        [Test]
        public void TestProjectNoteAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testProjectNote = TestFramework.TestProjectNote.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for ProjectNote \"{0}\" in Audit Log database entries.", testProjectNote.Note));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testProjectNote.Note)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newProjectNoteName = TestFramework.MakeTestName("New ProjectNote", ProjectNote.FieldLengths.Note);
            testProjectNote.Note = newProjectNoteName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newProjectNoteName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.ProjectNotes.Remove(testProjectNote);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this ProjectNote name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "ProjectNote" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testProjectNote.ProjectNoteID) != null,
                "Could not find deleted ProjectNote record");
        }

        [Test]
        public void TestProjectWatershedAuditLogging()
        {
            // This is a test that is driven off looking for IDs, not strings...
            // -----------------------------------------------------------------

            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testProjectWatershed = TestFramework.TestProjectWatershed.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Watershed \"{0}\" in Audit Log database entries.", testProjectWatershed.WatershedID));
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.ToList()
                    .Any(al => al.ColumnName == "WatershedID" && al.OriginalValue != null && al.OriginalValue.Contains(testProjectWatershed.WatershedID.ToString(CultureInfo.InvariantCulture))));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newWatershed = HttpRequestStorage.DatabaseEntities.Watersheds.FirstOrDefault(ws => ws.WatershedID != testProjectWatershed.WatershedID);
            testProjectWatershed.WatershedID = newWatershed == null ? ModelObjectHelpers.NotYetAssignedID : newWatershed.WatershedID;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW ID in reference to our ProjectWatershed name
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.ToList()
                    .Any(al => al.TableName == "ProjectWatershed" && al.ColumnName == "WatershedID" && al.NewValue.Contains(testProjectWatershed.WatershedID.ToString(CultureInfo.InvariantCulture))));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.ProjectWatersheds.Remove(testProjectWatershed);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this ProjectWatershed name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "ProjectWatershed" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testProjectWatershed.ProjectWatershedID) !=
                null,
                "Could not find deleted ProjectWatershed record");
        }

        [Test]
        public void TestWatershedAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testWatershed = TestFramework.TestWatershed.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Watershed \"{0}\" in Audit Log database entries.", testWatershed.WatershedName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testWatershed.WatershedName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newWatershedName = TestFramework.MakeTestName("New Watershed", Watershed.FieldLengths.WatershedName);
            testWatershed.WatershedName = newWatershedName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newWatershedName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.Watersheds.Remove(testWatershed);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Watershed name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Watershed" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testWatershed.WatershedID) != null,
                "Could not find deleted Watershed record");
        }

        [Test]
        public void TestThresholdCategoryAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testThresholdCategory = TestFramework.TestThresholdCategory.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for ThresholdCategory \"{0}\" in Audit Log database entries.", testThresholdCategory.ThresholdCategoryName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testThresholdCategory.ThresholdCategoryName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newThresholdCategoryName = TestFramework.MakeTestName("New ThresholdCategory", ThresholdCategory.FieldLengths.ThresholdCategoryName);
            var newThresholdCategoryDescription = TestFramework.MakeTestName("New ThresholdCategoryDescription");
            testThresholdCategory.ThresholdCategoryName = newThresholdCategoryName;
            testThresholdCategory.ThresholdCategoryDescription = newThresholdCategoryDescription;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newThresholdCategoryName)));

            // Delete audit logging
            // --------------------

            HttpRequestStorage.DatabaseEntities.ThresholdCategories.Remove(testThresholdCategory);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this ThresholdCategory name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "ThresholdCategory" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testThresholdCategory.ThresholdCategoryID) !=
                null,
                "Could not find deleted ThresholdCategory record");
        }

    }
}