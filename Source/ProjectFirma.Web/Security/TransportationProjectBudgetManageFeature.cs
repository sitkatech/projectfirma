using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Transportation Project Budget")]
    public class TransportationProjectBudgetManageFeature : FirmaFeature
    {
        public TransportationProjectBudgetManageFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin, Role.TMPOManager })
        {
        }
    }
}