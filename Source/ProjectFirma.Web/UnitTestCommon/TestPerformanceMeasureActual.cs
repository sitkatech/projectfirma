using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureActual
        {
            public static PerformanceMeasureActual Create()
            {
                var project = TestProject.Create();
                var performanceMeasure = TestPerformanceMeasure.Create();
                return Create(project, performanceMeasure);
            }

            public static PerformanceMeasureActual Create(Project project, PerformanceMeasure performanceMeasure)
            {
                var performanceMeasureActual = PerformanceMeasureActual.CreateNewBlank(project, performanceMeasure);
                return performanceMeasureActual;
            }

            public static PerformanceMeasureActual Create(int performanceMeasureActualID, Project project, PerformanceMeasure performanceMeasure, double actualValue, int calendarYear)
            {
                var performanceMeasureActual = PerformanceMeasureActual.CreateNewBlank(project, performanceMeasure);
                performanceMeasureActual.PerformanceMeasureActualID = performanceMeasureActualID;
                performanceMeasureActual.ActualValue = actualValue;
                performanceMeasureActual.CalendarYear = calendarYear;
                return performanceMeasureActual;
            }
        }
    }
}