using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.IndicatorMonitoringProgram
{
    public class EditIndicatorMonitoringProgramsViewModel : FormViewModel
    {
        public List<IndicatorMonitoringProgramSimple> IndicatorMonitoringPrograms { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditIndicatorMonitoringProgramsViewModel()
        {
        }

        public EditIndicatorMonitoringProgramsViewModel(List<IndicatorMonitoringProgramSimple> indicatorMonitoringPrograms)
        {
            IndicatorMonitoringPrograms = indicatorMonitoringPrograms;
        }

        public void UpdateModel(List<Models.IndicatorMonitoringProgram> currentIndicatorMonitoringPrograms, IList<Models.IndicatorMonitoringProgram> allIndicatorMonitoringPrograms)
        {
            var indicatorMonitoringProgramsUpdated = new List<Models.IndicatorMonitoringProgram>();
            if (IndicatorMonitoringPrograms != null)
            {
                // Completely rebuild the list
                indicatorMonitoringProgramsUpdated = IndicatorMonitoringPrograms.Select(x => new Models.IndicatorMonitoringProgram(x.IndicatorID, x.MonitoringProgramID)).ToList();
            }
            currentIndicatorMonitoringPrograms.Merge(indicatorMonitoringProgramsUpdated, allIndicatorMonitoringPrograms, (x, y) => x.MonitoringProgramID == y.MonitoringProgramID && x.IndicatorID == y.IndicatorID);
        }
    }
}