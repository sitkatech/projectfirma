using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Transportation Strategy")]
    public class TransportationStrategyManageFeature : EIPFeature
    {
        public TransportationStrategyManageFeature() : base(new List<Role> {Role.Admin, Role.TMPOManager})
        {
        }
    }
}