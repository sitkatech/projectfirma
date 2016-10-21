using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestEIPPerformanceMeasureActualUpdate
        {
            public static EIPPerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, int calendarYear)
            {
                var eipPerformanceMeasureActualUpdate = Create(projectUpdateBatch, calendarYear, null);
                return eipPerformanceMeasureActualUpdate;
            }

            public static EIPPerformanceMeasureActualUpdate Create(ProjectUpdateBatch projectUpdateBatch, int calendarYear, double? actualValue)
            {
                var eipPerformanceMeasure = TestEIPPerformanceMeasure.Create();
                var eipPerformanceMeasureActualUpdate = new EIPPerformanceMeasureActualUpdate(projectUpdateBatch, eipPerformanceMeasure, calendarYear) {ActualValue = actualValue};
                return eipPerformanceMeasureActualUpdate;
            }
        }
    }
}