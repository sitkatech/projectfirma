using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Pending Projects")]
    public class PendingProjectsViewListFeature : FirmaFeature
    {
        public PendingProjectsViewListFeature() : base(MultiTenantHelpers.ShowProposalsToThePublic() ? Role.All : FirmaBaseFeatureHelpers.AllRolesExceptUnassigned)
        {
        }
    }
}