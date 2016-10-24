using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Transportation Project Budget")]
    public class TransportationProjectBudgetManageFeature : EIPFeature
    {
        public TransportationProjectBudgetManageFeature() : base(new List<Role> {Role.Admin, Role.TMPOManager})
        {
        }
    }
}