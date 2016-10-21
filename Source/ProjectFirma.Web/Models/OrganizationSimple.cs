using System;

namespace ProjectFirma.Web.Models
{
    public class OrganizationSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public OrganizationSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public OrganizationSimple(int organizationID, Guid? organizationGuid, string organizationName, string organizationAbbreviation, int sectorID, int? primaryContactPersonID, bool isActive, string url, int? logoFileResourceID)
            : this()
        {
            OrganizationID = organizationID;
            OrganizationGuid = organizationGuid;
            OrganizationName = organizationName;
            OrganizationAbbreviation = organizationAbbreviation;
            SectorID = sectorID;
            PrimaryContactPersonID = primaryContactPersonID;
            IsActive = isActive;
            URL = url;
            LogoFileResourceID = logoFileResourceID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public OrganizationSimple(Organization organization)
            : this()
        {
            OrganizationID = organization.OrganizationID;
            OrganizationGuid = organization.OrganizationGuid;
            OrganizationName = organization.OrganizationName;
            OrganizationAbbreviation = organization.OrganizationAbbreviation;
            SectorID = organization.SectorID;
            PrimaryContactPersonID = organization.PrimaryContactPersonID;
            IsActive = organization.IsActive;
            URL = organization.OrganizationUrl;
            LogoFileResourceID = organization.LogoFileResourceID;
        }

        public int OrganizationID { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAbbreviation { get; set; }
        public int SectorID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public bool IsActive { get; set; }
        public string URL { get; set; }
        public int? LogoFileResourceID { get; set; }
        
        public string DisplayName
        {
            get { return string.Format("{0}{1}", OrganizationName, !string.IsNullOrWhiteSpace(OrganizationAbbreviation) ? string.Format(" ({0})", OrganizationAbbreviation) : string.Empty); }
        }
    }
}