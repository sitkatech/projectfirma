using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectNote
        {
            public static ProjectNote Create()
            {
                var project = TestProject.Create();
                var projectNote = ProjectNote.CreateNewBlank(project);
                projectNote.Note = MakeTestProjectNoteString();
                projectNote.CreateDate = DateTime.Now;
                return projectNote;
            }

            public static ProjectNote Create(DatabaseEntities dbContext)
            {
                var project = TestProject.Create(dbContext);
                var projectNote = ProjectNote.CreateNewBlank(project);
                projectNote.Note = MakeTestProjectNoteString();
                projectNote.CreateDate = DateTime.Now;
                dbContext.AllProjectNotes.Add(projectNote);
                return projectNote;
            }

            private static string MakeTestProjectNoteString()
            {
                return TestFramework.MakeTestName("TestProjectNote", ProjectNote.FieldLengths.Note);
            }
        }
    }
}