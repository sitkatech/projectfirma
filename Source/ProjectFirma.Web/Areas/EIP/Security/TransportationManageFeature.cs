using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Manage Transportation Features")]
    public class TransportationManageFeature : EIPFeature
    {
        public TransportationManageFeature() : base(new List<EIPRole> { EIPRole.Admin, EIPRole.TMPOManager })
        {
        }
    }
}