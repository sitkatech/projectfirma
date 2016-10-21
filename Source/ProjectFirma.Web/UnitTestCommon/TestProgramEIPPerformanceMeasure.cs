using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestProgramEIPPerformanceMeasure
        {
            public static ProgramEIPPerformanceMeasure Create()
            {
                var program = TestProgram.Create();
                var eipPerformanceMeasure = TestEIPPerformanceMeasure.Create();
                return Create(program, eipPerformanceMeasure);
            }

            public static ProgramEIPPerformanceMeasure Create(Program program, EIPPerformanceMeasure eipPerformanceMeasure)
            {
                var programEIPPerformanceMeasure = ProgramEIPPerformanceMeasure.CreateNewBlank(program, eipPerformanceMeasure);
                return programEIPPerformanceMeasure;
            }
        }
    }
}