using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestEIPPerformanceMeasureExpected
        {
            public static EIPPerformanceMeasureExpected Create()
            {
                var project = TestProject.Create();
                var eipPerformanceMeasure = TestEIPPerformanceMeasure.Create();
                return Create(project, eipPerformanceMeasure);
            }

            public static EIPPerformanceMeasureExpected Create(Project project, EIPPerformanceMeasure eipPerformanceMeasure)
            {
                var eipPerformanceMeasureExpected = EIPPerformanceMeasureExpected.CreateNewBlank(project, eipPerformanceMeasure);
                return eipPerformanceMeasureExpected;
            }

            public static EIPPerformanceMeasureExpected Create(int eipPerformanceMeasureExpectedID, Project project, EIPPerformanceMeasure eipPerformanceMeasure, double expectedValue)
            {
                var eipPerformanceMeasureExpected = EIPPerformanceMeasureExpected.CreateNewBlank(project, eipPerformanceMeasure);
                eipPerformanceMeasureExpected.EIPPerformanceMeasureExpectedID = eipPerformanceMeasureExpectedID;
                eipPerformanceMeasureExpected.ExpectedValue = expectedValue;
                return eipPerformanceMeasureExpected;
            }
        }
    }
}