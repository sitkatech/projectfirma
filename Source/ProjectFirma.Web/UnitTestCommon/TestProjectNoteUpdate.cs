using System;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProjectNoteUpdate
        {
            public static ProjectNoteUpdate Create()
            {
                var projectUpdateBatch = TestProjectUpdateBatch.Create();
                var projectNoteUpdate = ProjectNoteUpdate.CreateNewBlank(projectUpdateBatch);
                projectNoteUpdate.Note = MakeTestProjectNoteUpdateString();
                projectNoteUpdate.CreateDate = DateTime.Now;
                return projectNoteUpdate;
            }

            private static string MakeTestProjectNoteUpdateString()
            {
                return TestFramework.MakeTestName("TestProjectNoteUpdate", ProjectNoteUpdate.FieldLengths.Note);
            }
        }
    }
}