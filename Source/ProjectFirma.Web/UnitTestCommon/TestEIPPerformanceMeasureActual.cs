using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestEIPPerformanceMeasureActual
        {
            public static EIPPerformanceMeasureActual Create()
            {
                var project = TestProject.Create();
                var eipPerformanceMeasure = TestEIPPerformanceMeasure.Create();
                return Create(project, eipPerformanceMeasure);
            }

            public static EIPPerformanceMeasureActual Create(Project project, EIPPerformanceMeasure eipPerformanceMeasure)
            {
                var eipPerformanceMeasureActual = EIPPerformanceMeasureActual.CreateNewBlank(project, eipPerformanceMeasure);
                return eipPerformanceMeasureActual;
            }

            public static EIPPerformanceMeasureActual Create(int eipPerformanceMeasureActualID, Project project, EIPPerformanceMeasure eipPerformanceMeasure, double actualValue, int calendarYear)
            {
                var eipPerformanceMeasureActual = EIPPerformanceMeasureActual.CreateNewBlank(project, eipPerformanceMeasure);
                eipPerformanceMeasureActual.EIPPerformanceMeasureActualID = eipPerformanceMeasureActualID;
                eipPerformanceMeasureActual.ActualValue = actualValue;
                eipPerformanceMeasureActual.CalendarYear = calendarYear;
                return eipPerformanceMeasureActual;
            }
        }
    }
}