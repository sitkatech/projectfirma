using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class OrganizationDto
    {
        /// <summary>
        /// This Dto exists solely for posting Organizations created through Keystone login to an external system for tenants that source Organizations externally
        /// For all other uses, use the Dto in ProjectFirmaApi.Models
        /// </summary>
        public OrganizationDto(Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationGuid = organization.OrganizationGuid;
            OrganizationShortName = organization.OrganizationShortName;
            OrganizationTypeID = organization.OrganizationTypeID;
            OrganizationTypeName = organization.OrganizationType.OrganizationTypeName;
            IsActive = organization.IsActive;
            OrganizationUrl = organization.OrganizationUrl;
        }

        public OrganizationDto()
        {
        }

        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationShortName { get; set; }
        public int OrganizationTypeID { get; set; }
        public string OrganizationTypeName { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationUrl { get; set; }
    }
}