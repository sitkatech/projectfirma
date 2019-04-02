using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("View Pending Projects")]
    public class PendingProjectsViewListFeature : FirmaFeature
    {
        public PendingProjectsViewListFeature() : base(Role.All.Except(new List<Role>{Role.Unassigned}))
        {
        }
    }
}