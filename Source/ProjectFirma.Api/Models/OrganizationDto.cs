using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class OrganizationDto
    {
        public OrganizationDto(Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationGuid = organization.OrganizationGuid;
            OrganizationShortName = organization.OrganizationShortName;
        }

        public OrganizationDto()
        {
        }

        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationShortName { get; set; }
    }
}