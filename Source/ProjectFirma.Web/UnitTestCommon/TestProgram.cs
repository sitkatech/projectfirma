using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProgram
        {
            public static Program Create()
            {
                var focusArea = TestFocusArea.Create();
                var program = Program.CreateNewBlank(focusArea);
                return program;
            }

            public static Program Create(DatabaseEntities dbContext)
            {
                var focusArea = TestFocusArea.Create(dbContext);
                var program = new Program(focusArea,
                    Program.GetNextProgramNumberForFocusArea(dbContext.Programs, focusArea.FocusAreaID),
                    MakeTestName("Test Program Name", Program.FieldLengths.ProgramName));
                dbContext.Programs.Add(program);
                return program;
            }
        }
    }
}