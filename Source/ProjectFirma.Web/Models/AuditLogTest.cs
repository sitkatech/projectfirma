/*-----------------------------------------------------------------------
<copyright file="AuditLogTest.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
    /// TaxonomyBranchPerformanceMeasure
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
            var originalTaxonomyLeafName = testProject.TaxonomyLeaf.TaxonomyLeafName;
            // Act
            var newTaxonomyLeaf = TestFramework.TestTaxonomyLeaf.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges();

            testProject.TaxonomyLeafID = newTaxonomyLeaf.TaxonomyLeafID;

            var changeTracker = dbContext.ChangeTracker;
            changeTracker.DetectChanges();
            var modifiedEntries = changeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            var dbEntry = modifiedEntries.First();
            var result = AuditLog.GetAuditDescriptionStringIfAnyForProperty(objectContext, dbEntry, "TaxonomyLeafID", AuditLogEventType.Modified);

            // Assert
            Assert.That(result, Is.EqualTo(string.Format("TaxonomyLeaf: {0} changed to {1}", originalTaxonomyLeafName, newTaxonomyLeaf.TaxonomyLeafName)));
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
            var result = auditableEntityDeleted.GetAuditDescriptionString();

            // Assert
            Assert.That(result, Is.EqualTo(testProject.GetAuditDescriptionString()));
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
            System.Diagnostics.Trace.WriteLine(
                $"Looking for {FieldDefinition.FundingSource.GetFieldDefinitionLabel()} named \"{testFundingSource.FundingSourceName}\" in Audit Log database entries.");
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
        public void TestTaxonomyLeafAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            var dbContext = HttpRequestStorage.DatabaseEntities;
            var testTaxonomyLeaf = TestFramework.TestTaxonomyLeaf.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this FundingSource
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for TaxonomyLeaf named \"{0}\" in Audit Log database entries.", testTaxonomyLeaf.TaxonomyLeafName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testTaxonomyLeaf.TaxonomyLeafName)));

            // Change audit logging
            // --------------------

            var newTaxonomyLeafName = TestFramework.MakeTestName("New TaxonomyLeafName", TaxonomyLeaf.FieldLengths.TaxonomyLeafName);
            testTaxonomyLeaf.TaxonomyLeafName = newTaxonomyLeafName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newTaxonomyLeafName)));

            // Delete audit logging
            // --------------------

            testTaxonomyLeaf.DeleteTaxonomyLeaf();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this TaxonomyLeafName as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "TaxonomyLeaf" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testTaxonomyLeaf.TaxonomyLeafID) != null,
                "Could not find deleted TaxonomyLeaf record");
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
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for {0} named \"{1}\" in Audit Log database entries.", FieldDefinition.Project.GetFieldDefinitionLabel(), testProject.ProjectName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testProject.ProjectName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newProjectName = TestFramework.MakeTestName($"New {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} Name", Project.FieldLengths.ProjectName);
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
                $"Could not find deleted {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} record");
        }

        [Test]
        public void TestTaxonomyTrunkAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testTaxonomyTrunk = TestFramework.TestTaxonomyTrunk.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for TaxonomyTrunk named \"{0}\" in Audit Log database entries.", testTaxonomyTrunk.TaxonomyTrunkName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testTaxonomyTrunk.TaxonomyTrunkName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newTaxonomyTrunkName = TestFramework.MakeTestName("New TaxonomyTrunk Name", TaxonomyTrunk.FieldLengths.TaxonomyTrunkName);
            testTaxonomyTrunk.TaxonomyTrunkName = newTaxonomyTrunkName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newTaxonomyTrunkName)));

            // Delete audit logging
            // --------------------

            testTaxonomyTrunk.DeleteTaxonomyTrunk();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this TaxonomyTrunk name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "TaxonomyTrunk" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testTaxonomyTrunk.TaxonomyTrunkID) != null,
                "Could not find deleted TaxonomyTrunk record");
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
        public void TestTaxonomyBranchAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testTaxonomyBranch = TestFramework.TestTaxonomyBranch.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for TaxonomyBranch named \"{0}\" in Audit Log database entries.", testTaxonomyBranch.TaxonomyBranchName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testTaxonomyBranch.TaxonomyBranchName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newTaxonomyBranchName = TestFramework.MakeTestName("New TaxonomyBranch Name", TaxonomyBranch.FieldLengths.TaxonomyBranchName);
            testTaxonomyBranch.TaxonomyBranchName = newTaxonomyBranchName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newTaxonomyBranchName)));

            // Delete audit logging
            // --------------------

            testTaxonomyBranch.DeleteTaxonomyBranch();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this TaxonomyBranch name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "TaxonomyBranch" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testTaxonomyBranch.TaxonomyBranchID) != null,
                "Could not find deleted TaxonomyBranch record");
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
        [Ignore] //Ignoring because this test doesn't work without at least one pre-existing entries in the geospatialArea table
        public void TestProjectGeospatialAreaAuditLogging()
        {
            // This is a test that is driven off looking for IDs, not strings...
            // -----------------------------------------------------------------

            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testProjectGeospatialArea = TestFramework.TestProjectGeospatialArea.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for GeospatialArea \"{0}\" in Audit Log database entries.", testProjectGeospatialArea.GeospatialAreaID));
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.ToList()
                    .Any(al => al.ColumnName == "GeospatialAreaID" && al.OriginalValue != null && al.OriginalValue.Contains(testProjectGeospatialArea.GeospatialAreaID.ToString(CultureInfo.InvariantCulture))));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newGeospatialArea = HttpRequestStorage.DatabaseEntities.GeospatialAreas.First(ws => ws.GeospatialAreaID != testProjectGeospatialArea.GeospatialAreaID);
            testProjectGeospatialArea.GeospatialAreaID = newGeospatialArea.GeospatialAreaID;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW ID in reference to our ProjectGeospatialArea name
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.ToList()
                    .Any(al => al.TableName == "ProjectGeospatialArea" && al.ColumnName == "GeospatialAreaID" && al.NewValue.Contains(newGeospatialArea.GeospatialAreaID.ToString(CultureInfo.InvariantCulture))));

            // Delete audit logging
            // --------------------

            testProjectGeospatialArea.DeleteProjectGeospatialArea();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this ProjectGeospatialArea name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "ProjectGeospatialArea" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testProjectGeospatialArea.ProjectGeospatialAreaID) !=
                null,
                "Could not find deleted ProjectGeospatialArea record");
        }

        [Test]
        public void TestGeospatialAreaAuditLogging()
        {
            // Get an arbitrary real-word person to do these actions
            var firmaUser = HttpRequestStorage.DatabaseEntities.People.First();

            // Create audit logging
            // --------------------

            // Make a test object and save it
            var dbContext = HttpRequestStorage.DatabaseEntities;

            var testGeospatialArea = TestFramework.TestGeospatialArea.Create(dbContext);
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this object
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for GeospatialArea \"{0}\" in Audit Log database entries.", testGeospatialArea.GeospatialAreaName));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testGeospatialArea.GeospatialAreaName)));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newGeospatialAreaName = TestFramework.MakeTestName("New GeospatialArea", GeospatialArea.FieldLengths.GeospatialAreaName);
            testGeospatialArea.GeospatialAreaName = newGeospatialAreaName;
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);

            // Check that the audit log mentions this NEW name
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.NewValue.Contains(newGeospatialAreaName)));

            // Delete audit logging
            // --------------------

            testGeospatialArea.DeleteGeospatialArea();
            HttpRequestStorage.DatabaseEntities.SaveChanges(firmaUser);
            // Check that the audit log mentions this GeospatialArea name as deleted
            Check.Assert(
                HttpRequestStorage.DatabaseEntities.AuditLogs.SingleOrDefault(
                    al => al.TableName == "GeospatialArea" && al.AuditLogEventTypeID == AuditLogEventType.Deleted.AuditLogEventTypeID && al.RecordID == testGeospatialArea.GeospatialAreaID) != null,
                "Could not find deleted GeospatialArea record");
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
            System.Diagnostics.Trace.WriteLine(string.Format("Looking for Classification \"{0}\" in Audit Log database entries.", testClassification.GetDisplayName()));
            Check.Assert(HttpRequestStorage.DatabaseEntities.AuditLogs.Any(al => al.OriginalValue.Contains(testClassification.GetDisplayName())));

            // Change audit logging
            // --------------------

            // Make changes to the original object
            var newClassificationName = TestFramework.MakeTestName("New Classification", Classification.FieldLengths.DisplayName);
            var newClassificationDescription = TestFramework.MakeTestName("New ClassificationDescription");
            testClassification.DisplayName = newClassificationName;
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
