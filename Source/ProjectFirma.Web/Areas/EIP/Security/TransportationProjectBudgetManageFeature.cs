using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.EIP.Security
{
    [SecurityFeatureDescription("Manage Transportation Project Budget")]
    public class TransportationProjectBudgetManageFeature : EIPFeature
    {
        public TransportationProjectBudgetManageFeature() : base(new List<EIPRole> {EIPRole.Admin, EIPRole.TMPOManager})
        {
        }
    }
}