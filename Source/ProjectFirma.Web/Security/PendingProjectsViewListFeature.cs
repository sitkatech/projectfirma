using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    public class PendingProjectsViewListFeature : FirmaFeature
    {
        public PendingProjectsViewListFeature() : base(Role.All.Except(new List<Role>{Role.Unassigned}))
        {
        }
    }
}