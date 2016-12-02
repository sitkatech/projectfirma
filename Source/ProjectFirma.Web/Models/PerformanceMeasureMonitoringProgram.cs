using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureMonitoringProgram : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var monitoringProgram = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.Find(MonitoringProgramID);
                var monitoringProgramName = monitoringProgram != null ? monitoringProgram.MonitoringProgramName : ViewUtilities.NotFoundString;

                var performanceMeasure = HttpRequestStorage.DatabaseEntities.PerformanceMeasures.Find(PerformanceMeasureID);
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.PerformanceMeasureName : ViewUtilities.NotFoundString;

                return string.Format("PerformanceMeasure: {0}, Monitoring Program: {1}", performanceMeasureName, monitoringProgramName);
            }
        }
    }
}