using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestPerformanceMeasureActualUpdate
        {
            public static PerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, int calendarYear)
            {
                var performanceMeasureActualUpdate = Create(projectUpdateBatch, calendarYear, null);
                return performanceMeasureActualUpdate;
            }

            public static PerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, int calendarYear, double? actualValue)
            {
                var performanceMeasure = TestPerformanceMeasure.Create();
                var performanceMeasureActualUpdate = new PerformanceMeasureActualUpdate(projectUpdateBatch, performanceMeasure, calendarYear) {ActualValue = actualValue};
                return performanceMeasureActualUpdate;
            }
        }
    }
}