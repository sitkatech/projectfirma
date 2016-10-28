using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProgramPerformanceMeasure
        {
            public static ProgramPerformanceMeasure Create()
            {
                var program = TestProgram.Create();
                var performanceMeasure = TestPerformanceMeasure.Create();
                return Create(program, performanceMeasure);
            }

            public static ProgramPerformanceMeasure Create(Program program, PerformanceMeasure performanceMeasure)
            {
                var programPerformanceMeasure = ProgramPerformanceMeasure.CreateNewBlank(program, performanceMeasure);
                return programPerformanceMeasure;
            }
        }
    }
}