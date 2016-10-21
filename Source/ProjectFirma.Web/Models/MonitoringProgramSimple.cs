namespace ProjectFirma.Web.Models
{
    public class MonitoringProgramSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public MonitoringProgramSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgramSimple(int monitoringProgramID, string monitoringProgramName)
            : this()
        {
            MonitoringProgramID = monitoringProgramID;
            MonitoringProgramName = monitoringProgramName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public MonitoringProgramSimple(MonitoringProgram monitoringProgram)
            : this()
        {
            MonitoringProgramID = monitoringProgram.MonitoringProgramID;
            MonitoringProgramName = monitoringProgram.MonitoringProgramName;
        }

        public int MonitoringProgramID { get; set; }
        public string MonitoringProgramName { get; set; }
    }
}