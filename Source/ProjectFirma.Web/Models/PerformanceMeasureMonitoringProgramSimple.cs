namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureMonitoringProgramSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public PerformanceMeasureMonitoringProgramSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public PerformanceMeasureMonitoringProgramSimple(int monitoringProgramPartnerID, int performanceMeasureID, int monitoringProgramID)
            : this()
        {
            MonitoringProgramPartnerID = monitoringProgramPartnerID;
            PerformanceMeasureID = performanceMeasureID;
            MonitoringProgramID = monitoringProgramID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public PerformanceMeasureMonitoringProgramSimple(PerformanceMeasureMonitoringProgram performanceMeasureMonitoringProgram)
            : this()
        {
            MonitoringProgramPartnerID = performanceMeasureMonitoringProgram.PerformanceMeasureMonitoringProgramID;
            PerformanceMeasureID = performanceMeasureMonitoringProgram.PerformanceMeasureID;
            MonitoringProgramID = performanceMeasureMonitoringProgram.MonitoringProgramID;
        }

        public int MonitoringProgramPartnerID { get; set; }
        public int PerformanceMeasureID { get; set; }
        public int MonitoringProgramID { get; set; }
    }
}