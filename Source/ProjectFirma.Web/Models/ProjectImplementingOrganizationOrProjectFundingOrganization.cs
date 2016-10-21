namespace ProjectFirma.Web.Models
{
    public class ProjectImplementingOrganizationOrProjectFundingOrganization
    {
        public ProjectImplementingOrganizationOrProjectFundingOrganization(ProjectImplementingOrganization projectImplementingOrganization, ProjectFundingOrganization projectFundingOrganization)
        {
            ProjectImplementingOrganization = projectImplementingOrganization;
            ProjectFundingOrganization = projectFundingOrganization;
        }

        public ProjectImplementingOrganization ProjectImplementingOrganization { get; private set; }
        public ProjectFundingOrganization ProjectFundingOrganization { get; private set; }
        public Project Project
        {
            get { return ProjectImplementingOrganization == null ? ProjectFundingOrganization.Project : ProjectImplementingOrganization.Project; }
        }
        public Organization Organization
        {
            get { return ProjectImplementingOrganization == null ? ProjectFundingOrganization.Organization : ProjectImplementingOrganization.Organization; }
        }
        public bool IsFundingOrganization
        {
            get { return ProjectFundingOrganization != null; }
        }
        public bool IsImplementingOrganization
        {
            get { return ProjectImplementingOrganization != null; }
        }
        public bool IsLeadOrganization
        {
            get { return ProjectImplementingOrganization != null && ProjectImplementingOrganization.IsLeadOrganization; }
        }
    }
}