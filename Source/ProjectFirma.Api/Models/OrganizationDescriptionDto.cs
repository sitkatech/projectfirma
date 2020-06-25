using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class OrganizationDescriptionDto
    {
        public OrganizationDescriptionDto(Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            Description = organization.Description;
            FileResources = organization.OrganizationImages.Select(x => new FileResourceDto(x.FileResourceInfo))
                .ToList();

        }

        public OrganizationDescriptionDto()
        {
        }

        public int OrganizationID { get; set; }
        public string Description { get; set; }
        public List<FileResourceDto> FileResources { get; set; }

    }
}