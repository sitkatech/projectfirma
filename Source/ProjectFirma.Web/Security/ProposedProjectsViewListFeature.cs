using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Proposed Projects List")]
    public class ProposedProjectsViewListFeature : FirmaFeature
    {
        public ProposedProjectsViewListFeature()
            : base(FirmaBaseFeatureHelpers.AllRolesExceptUnassigned)
        {
        }
    }
}