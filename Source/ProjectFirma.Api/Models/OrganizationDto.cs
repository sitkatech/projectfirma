using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class OrganizationDto
    {
        public OrganizationDto(Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationGuid = organization.OrganizationGuid;
            OrganizationShortName = organization.OrganizationShortName;
            OrganizationTypeID = organization.OrganizationTypeID;
            IsActive = organization.IsActive;
            OrganizationUrl = organization.OrganizationUrl;
            if (organization.LogoFileResource != null)
            {
                LogoFileResource = new FileResourceDto(organization.LogoFileResource);
            }
        }

        public OrganizationDto()
        {
        }

        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationShortName { get; set; }
        public int OrganizationTypeID { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationUrl { get; set; }
        public FileResourceDto LogoFileResource { get; set; }
    }
}