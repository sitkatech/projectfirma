using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Transportation Strategy")]
    public class TransportationStrategyManageFeature : FirmaFeature
    {
        public TransportationStrategyManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
        {
        }
    }
}