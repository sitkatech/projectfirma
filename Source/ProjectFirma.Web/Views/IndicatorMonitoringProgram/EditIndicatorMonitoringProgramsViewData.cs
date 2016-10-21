using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.IndicatorMonitoringProgram
{
    public class EditIndicatorMonitoringProgramsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<MonitoringProgramSimple> AllMonitoringPrograms;
        public readonly int IndicatorID;

        public EditIndicatorMonitoringProgramsViewData(Models.Indicator indicator, List<MonitoringProgramSimple> allMonitoringPrograms)
        {
            AllMonitoringPrograms = allMonitoringPrograms;
            IndicatorID = indicator.IndicatorID;
        }
    }
}