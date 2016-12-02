using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasureMonitoringProgram
{
    public class EditPerformanceMeasureMonitoringProgramsViewModel : FormViewModel
    {
        public List<PerformanceMeasureMonitoringProgramSimple> PerformanceMeasureMonitoringPrograms { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPerformanceMeasureMonitoringProgramsViewModel()
        {
        }

        public EditPerformanceMeasureMonitoringProgramsViewModel(List<PerformanceMeasureMonitoringProgramSimple> performanceMeasureMonitoringPrograms)
        {
            PerformanceMeasureMonitoringPrograms = performanceMeasureMonitoringPrograms;
        }

        public void UpdateModel(List<Models.PerformanceMeasureMonitoringProgram> currentPerformanceMeasureMonitoringPrograms, IList<Models.PerformanceMeasureMonitoringProgram> allPerformanceMeasureMonitoringPrograms)
        {
            var performanceMeasureMonitoringProgramsUpdated = new List<Models.PerformanceMeasureMonitoringProgram>();
            if (PerformanceMeasureMonitoringPrograms != null)
            {
                // Completely rebuild the list
                performanceMeasureMonitoringProgramsUpdated = PerformanceMeasureMonitoringPrograms.Select(x => new Models.PerformanceMeasureMonitoringProgram(x.PerformanceMeasureID, x.MonitoringProgramID)).ToList();
            }
            currentPerformanceMeasureMonitoringPrograms.Merge(performanceMeasureMonitoringProgramsUpdated, allPerformanceMeasureMonitoringPrograms, (x, y) => x.MonitoringProgramID == y.MonitoringProgramID && x.PerformanceMeasureID == y.PerformanceMeasureID);
        }
    }
}