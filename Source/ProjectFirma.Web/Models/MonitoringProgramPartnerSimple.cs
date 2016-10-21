namespace ProjectFirma.Web.Models
{
    public class MonitoringProgramPartnerSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public MonitoringProgramPartnerSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public MonitoringProgramPartnerSimple(int monitoringProgramPartnerID, int monitoringProgramID, int organizationID)
            : this()
        {
            MonitoringProgramPartnerID = monitoringProgramPartnerID;
            MonitoringProgramID = monitoringProgramID;
            OrganizationID = organizationID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public MonitoringProgramPartnerSimple(MonitoringProgramPartner monitoringProgramPartner)
            : this()
        {
            MonitoringProgramPartnerID = monitoringProgramPartner.MonitoringProgramPartnerID;
            MonitoringProgramID = monitoringProgramPartner.MonitoringProgramID;
            OrganizationID = monitoringProgramPartner.OrganizationID;
        }

        public int MonitoringProgramPartnerID { get; set; }
        public int MonitoringProgramID { get; set; }
        public int OrganizationID { get; set; }
    }
}