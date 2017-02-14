using System.Data.Entity;
using System.Globalization;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common.DesignByContract;
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
    /// TaxonomyTierTwoPerformanceMeasure
    /// ProjectClassification
    /// PerformanceMeasureSubcategoryOption
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
            var originalTaxonomyTierOneName = testProject.TaxonomyTierOne.TaxonomyTierOneName;
            // Act
            var newTaxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            testProject.TaxonomyTierOneID = newTaxonomyTierOne.TaxonomyTierOneID;

            var changeTracker = dbContext.ChangeTracker;
            changeTracker.DetectChanges();
            var modifiedEntries = changeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            var dbEntry = modifiedEntries.First();
            var result = AuditLog.GetAuditDescriptionStringIfAnyForProperty(objectContext, dbEntry, "TaxonomyTierOneID", AuditLogEventType.Modified);

            // Assert
            Assert.That(result, Is.EqualTo(string.Format("TaxonomyTierOne: {0} changed to {1}", originalTaxonomyTierOneName, newTaxonomyTierOne.TaxonomyTierOneName)));
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
            testProject.DeleteProject();

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

            testFundingSource.DeleteFundingSource();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this FundingSource name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "FundingSource" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testFundingSource.FundingSourceID) != null,
                "Could not find deleted Funding Source record");
        }

        [Test]
        public void TestTaxonomyTierOneAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            var dbContext = HttpRequestStorage.DatabaseEntities;
            var testTaxonomyTierOne = TestFramework.TestTaxonomyTierOne.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this FundingSource
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for TaxonomyTierOne named \"{0}\" in Audit Log database entries.", testTaxonomyTierOne.TaxonomyTierOneName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testTaxonomyTierOne.TaxonomyTierOneName)));

            // Change audit logging
            // --------------------

            var newTaxonomyTierOneName = TestFramework.MakeTestName("New TaxonomyTierOneName", TaxonomyTierOne.FieldLengths.TaxonomyTierOneName);
            testTaxonomyTierOne.TaxonomyTierOneName = newTaxonomyTierOneName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newTaxonomyTierOneName)));

            // Delete audit logging
            // --------------------

            testTaxonomyTierOne.DeleteTaxonomyTierOne();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this TaxonomyTierOneName as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "TaxonomyTierOne" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testTaxonomyTierOne.TaxonomyTierOneID) != null,
                "Could not find deleted TaxonomyTierOne record");
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

            testProject.DeleteProject();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Project name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Project" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testProject.ProjectID) != null,
                "Could not find deleted project record");
        }

        [Test]
        public void TestTaxonomyTierThreeAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testTaxonomyTierThree = TestFramework.TestTaxonomyTierThree.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for TaxonomyTierThree named \"{0}\" in Audit Log database entries.", testTaxonomyTierThree.TaxonomyTierThreeName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testTaxonomyTierThree.TaxonomyTierThreeName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newTaxonomyTierThreeName = TestFramework.MakeTestName("New TaxonomyTierThree Name", TaxonomyTierThree.FieldLengths.TaxonomyTierThreeName);
            testTaxonomyTierThree.TaxonomyTierThreeName = newTaxonomyTierThreeName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newTaxonomyTierThreeName)));

            // Delete audit logging
            // --------------------

            testTaxonomyTierThree.DeleteTaxonomyTierThree();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this TaxonomyTierThree name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "TaxonomyTierThree" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testTaxonomyTierThree.TaxonomyTierThreeID) != null,
                "Could not find deleted TaxonomyTierThree record");
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

            testOrganization.DeleteOrganization();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Organization name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Organization" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testOrganization.OrganizationID) != null,
                "Could not find deleted Organization record");
        }

        [Test]
        public void TestTaxonomyTierTwoAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testTaxonomyTierTwo = TestFramework.TestTaxonomyTierTwo.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for TaxonomyTierTwo named \"{0}\" in Audit Log database entries.", testTaxonomyTierTwo.TaxonomyTierTwoName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testTaxonomyTierTwo.TaxonomyTierTwoName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newTaxonomyTierTwoName = TestFramework.MakeTestName("New TaxonomyTierTwo Name", TaxonomyTierTwo.FieldLengths.TaxonomyTierTwoName);
            testTaxonomyTierTwo.TaxonomyTierTwoName = newTaxonomyTierTwoName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newTaxonomyTierTwoName)));

            // Delete audit logging
            // --------------------

            testTaxonomyTierTwo.DeleteTaxonomyTierTwo();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this TaxonomyTierTwo name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "TaxonomyTierTwo" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testTaxonomyTierTwo.TaxonomyTierTwoID) != null,
                "Could not find deleted TaxonomyTierTwo record");
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

            testProjectNote.DeleteProjectNote();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this ProjectNote name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "ProjectNote" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testProjectNote.ProjectNoteID) != null,
                "Could not find deleted ProjectNote record");
        }

        [Test]
        [Ignore] //Ignoring because this test doesn't work without at least one pre-existing entries in the watershed table
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
            var newWatershed = HttpRequestStorage.DatabaseEntities.Watersheds.First(ws => ws.WatershedID != testProjectWatershed.WatershedID);
            testProjectWatershed.WatershedID = newWatershed.WatershedID;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW ID in reference to our ProjectWatershed name
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.ToList()
                    .Any(al => al.TableName == "ProjectWatershed" && al.ColumnName == "WatershedID" && al.NewValue.Contains(newWatershed.WatershedID.ToString(CultureInfo.InvariantCulture))));

            // Delete audit logging
            // --------------------

            testProjectWatershed.DeleteProjectWatershed();
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

            testWatershed.DeleteWatershed();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Watershed name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Watershed" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testWatershed.WatershedID) != null,
                "Could not find deleted Watershed record");
        }

        [Test]
        public void TestClassificationAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testClassification = TestFramework.TestClassification.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Classification \"{0}\" in Audit Log database entries.", testClassification.ClassificationName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testClassification.ClassificationName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newClassificationName = TestFramework.MakeTestName("New Classification", Classification.FieldLengths.ClassificationName);
            var newClassificationDescription = TestFramework.MakeTestName("New ClassificationDescription");
            testClassification.ClassificationName = newClassificationName;
            testClassification.ClassificationDescription = newClassificationDescription;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newClassificationName)));

            // Delete audit logging
            // --------------------

            testClassification.DeleteClassification();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this Classification name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "Classification" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testClassification.ClassificationID) !=
                null,
                "Could not find deleted Classification record");
        }

    }
}