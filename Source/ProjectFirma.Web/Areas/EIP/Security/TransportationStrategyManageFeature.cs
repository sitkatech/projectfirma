using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Manage Transportation Strategy")]
    public class TransportationStrategyManageFeature : EIPFeature
    {
        public TransportationStrategyManageFeature() : base(new List<EIPRole> {EIPRole.Admin, EIPRole.TMPOManager})
        {
        }
    }
}