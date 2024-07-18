using System;

namespace ProjectFirmaModels.Models.DataTransferObjects
{
    
    public class PersonSimpleDto
    {
        public int PersonID { get; set; }
        public Guid PersonGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordPdfK2SaltHash { get; set; }
        public int EIPRoleID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationID { get; set; }
        public int LTInfoRoleID { get; set; }
        public int ParcelTrackerRoleID { get; set; }
        public Guid? WebServiceAccessToken { get; set; }
        public string LoginName { get; set; }
        public int StormwaterRoleID { get; set; }
        public int MonitoringRoleID { get; set; }
        public int TransportationRoleID { get; set; }
        public int LakeClarityTrackerRoleID { get; set; }
        public int ThresholdRoleID { get; set; }
        public int ClimateResilienceRoleID { get; set; }
    }

}