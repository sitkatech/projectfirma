using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Terminated Project List")]
    public class ProjectsViewTerminatedListFeature : FirmaFeature
    {
        public ProjectsViewTerminatedListFeature()
            : base(FirmaBaseFeatureHelpers.AllRolesExceptUnassigned)
        {
        }
    }
}