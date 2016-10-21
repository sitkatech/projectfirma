using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.UnitTestCommon;
using LtInfo.Common.DesignByContract;
using NUnit.Framework;

namespace ProjectFirma.Web.Models
{
    /// <summary>
    /// Experimental code to explore ways to do EF 6 automated change logging
    /// </summary>
    [TestFixture]
    public class ProjectChangeLogTest : ProjectFirmaTestWithContext
    {
        [Test]
        public void ChangeProjectAndAttemptToLogWhatChanged()
        {
            var testProject = TestFramework.TestProject.Insert(HttpRequestStorage.DatabaseEntities);
            var originalProjectName = testProject.ProjectName;

            // This simulates a round-trip through a typical update model call. In this case, an unchanged
            // parameter is being set, but we don't think there should be any changes
            testProject.ProjectName = originalProjectName;
            var hadChanges = OutputChangedEntities();
            Check.Ensure(hadChanges == false, "We should detect no changes in this case");

            // Now we'll simulate an actual change. This SHOULD show changes
            testProject.ProjectName = "First Project Name";
            hadChanges = OutputChangedEntities();
            Check.Ensure(hadChanges == true, "We SHOULD detect changes in this case");

            // Finally, just for clarity, there's another case. Once you make a change before saving, the dirty
            // bit stays set, so despite the fact that this is set to the original value, it will still say changed.
            testProject.ProjectName = originalProjectName;
            hadChanges = OutputChangedEntities();
            Check.Ensure(hadChanges == true, "We SHOULD STILL detect changes in this case");

            HttpRequestStorage.DatabaseEntities.SaveChanges();
        }

        private static bool OutputChangedEntities()
        {
            var hadChangedEntities = false;
            try
            {
                // Detecting *ALL* changes for the entire context
                var dbEntityEntriesChanged = HttpRequestStorage.DatabaseEntities.ChangeTracker.Entries().Where(a => a.State != EntityState.Unchanged).ToList();
                foreach (var entry in dbEntityEntriesChanged)
                {
                    Trace.WriteLine(string.Format("Changed entity: {0}", entry.Entity.ToString()));

                    if (entry.State == EntityState.Added)
                    {
                        hadChangedEntities = true;

                        var addedPropertyNames = entry.CurrentValues.PropertyNames.Select(pn => pn).ToList();
                        Trace.WriteLine(string.Format("Added: {0}", string.Join(", ", addedPropertyNames)));
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        //Trace.WriteLine(string.Format("Original Values: {0}", entry.OriginalValues.ToString()));

                        var modifiedProperties = entry.CurrentValues.PropertyNames.Where(p => entry.Property(p).IsModified).Select(pn => entry.Property(pn)).ToList();
                        foreach (var modifiedProperty in modifiedProperties)
                        {
                            hadChangedEntities = true;

                            Trace.Write(string.Format("Modified: {0}, ", modifiedProperty.Name));
                            Trace.Write(string.Format("Original: {0}, ", modifiedProperty.OriginalValue));
                            Trace.Write(string.Format("New: {0}", modifiedProperty.CurrentValue));
                            Trace.WriteLine(string.Empty);
                        }
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                throw new ApplicationException("Problem detecting changes", e);
            }
            return hadChangedEntities;
        }
    }
}