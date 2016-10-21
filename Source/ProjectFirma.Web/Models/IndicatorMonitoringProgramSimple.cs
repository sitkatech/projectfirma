namespace ProjectFirma.Web.Models
{
    public class IndicatorMonitoringProgramSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public IndicatorMonitoringProgramSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public IndicatorMonitoringProgramSimple(int monitoringProgramPartnerID, int indicatorID, int monitoringProgramID)
            : this()
        {
            MonitoringProgramPartnerID = monitoringProgramPartnerID;
            IndicatorID = indicatorID;
            MonitoringProgramID = monitoringProgramID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public IndicatorMonitoringProgramSimple(IndicatorMonitoringProgram indicatorMonitoringProgram)
            : this()
        {
            MonitoringProgramPartnerID = indicatorMonitoringProgram.IndicatorMonitoringProgramID;
            IndicatorID = indicatorMonitoringProgram.IndicatorID;
            MonitoringProgramID = indicatorMonitoringProgram.MonitoringProgramID;
        }

        public int MonitoringProgramPartnerID { get; set; }
        public int IndicatorID { get; set; }
        public int MonitoringProgramID { get; set; }
    }
}