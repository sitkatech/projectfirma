using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    public class PendingProjectsViewListFeature : FirmaFeature
    {
        public PendingProjectsViewListFeature() : base(new List<Role> { Role.ProjectSteward, Role.Admin, Role.SitkaAdmin })
        {
        }
    }
}