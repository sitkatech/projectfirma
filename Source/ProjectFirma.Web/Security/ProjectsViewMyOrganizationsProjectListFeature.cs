using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
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