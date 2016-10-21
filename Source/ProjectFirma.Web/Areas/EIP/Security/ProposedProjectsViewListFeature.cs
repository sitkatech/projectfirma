using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("View Proposed Projects List")]
    public class ProposedProjectsViewListFeature : EIPFeature
    {
        public ProposedProjectsViewListFeature()
            : base(LakeTahoeInfoBaseFeatureHelpers.AllEIPRolesExceptUnassigned)
        {
        }
    }
}