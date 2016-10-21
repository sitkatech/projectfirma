using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("View Terminated Project List")]
    public class ProjectsViewTerminatedListFeature : EIPFeature
    {
        public ProjectsViewTerminatedListFeature()
            : base(LakeTahoeInfoBaseFeatureHelpers.AllEIPRolesExceptUnassigned)
        {
        }
    }
}