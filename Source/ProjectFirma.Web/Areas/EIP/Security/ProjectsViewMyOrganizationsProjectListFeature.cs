using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("View My Organization's Project List")]
    public class ProjectsViewMyOrganizationsProjectListFeature : EIPFeature
    {
        public ProjectsViewMyOrganizationsProjectListFeature()
            : base(LakeTahoeInfoBaseFeatureHelpers.AllEIPRolesExceptUnassigned)
        {
        }
    }
}