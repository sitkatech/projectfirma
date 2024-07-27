

using System;

namespace ProjectFirmaModels.Models.DataTransferObjects
{

    public class OrganizationSimpleDto
    {
        public int OrganizationID { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAbbreviation { get; set; }
        public int SectorID { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationUrl { get; set; }
        public int? LogoFileResourceInfoID { get; set; }
        public bool IsUserAccountOrganization { get; set; }
    }

}