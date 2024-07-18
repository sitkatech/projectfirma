namespace ProjectFirmaModels.Models.DataTransferObjects
{
    public class ProjectImplementingOrganizationOrProjectFundingOrganizationSimpleDto
    {
        public OrganizationSimpleDto Organization { get; set; }
        public string PrimaryContactPersonFullName { get; set; }
        public bool IsFundingOrganization { get; set; }
        public bool IsImplementingOrganization { get; set; }
        public bool IsLeadOrganization { get; set; }
    }
}
