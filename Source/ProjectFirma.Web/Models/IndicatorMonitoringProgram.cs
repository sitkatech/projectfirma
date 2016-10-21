using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class IndicatorMonitoringProgram : IAuditableEntity
    {
        public string AuditDescriptionString
        {
            get
            {
                var monitoringProgram = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.Find(MonitoringProgramID);
                var monitoringProgramName = monitoringProgram != null ? monitoringProgram.MonitoringProgramName : ViewUtilities.NotFoundString;

                var indicator = HttpRequestStorage.DatabaseEntities.Indicators.Find(IndicatorID);
                var indicatorName = indicator != null ? indicator.IndicatorName : ViewUtilities.NotFoundString;

                return string.Format("Indicator: {0}, Monitoring Program: {1}", indicatorName, monitoringProgramName);
            }
        }
    }
}