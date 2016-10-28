using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureExpected
        {
            public static PerformanceMeasureExpected Create()
            {
                var project = TestProject.Create();
                var performanceMeasure = TestPerformanceMeasure.Create();
                return Create(project, performanceMeasure);
            }

            public static PerformanceMeasureExpected Create(Project project, PerformanceMeasure performanceMeasure)
            {
                var performanceMeasureExpected = PerformanceMeasureExpected.CreateNewBlank(project, performanceMeasure);
                return performanceMeasureExpected;
            }

            public static PerformanceMeasureExpected Create(int performanceMeasureExpectedID, Project project, PerformanceMeasure performanceMeasure, double expectedValue)
            {
                var performanceMeasureExpected = PerformanceMeasureExpected.CreateNewBlank(project, performanceMeasure);
                performanceMeasureExpected.PerformanceMeasureExpectedID = performanceMeasureExpectedID;
                performanceMeasureExpected.ExpectedValue = expectedValue;
                return performanceMeasureExpected;
            }
        }
    }
}