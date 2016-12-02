using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasureMonitoringProgram
{
    public class EditPerformanceMeasureMonitoringProgramsViewData : FirmaUserControlViewData
    {
        public readonly List<MonitoringProgramSimple> AllMonitoringPrograms;
        public readonly int PerformanceMeasureID;

        public EditPerformanceMeasureMonitoringProgramsViewData(Models.PerformanceMeasure performanceMeasure, List<MonitoringProgramSimple> allMonitoringPrograms)
        {
            AllMonitoringPrograms = allMonitoringPrograms;
            PerformanceMeasureID = performanceMeasure.PerformanceMeasureID;
        }
    }
}