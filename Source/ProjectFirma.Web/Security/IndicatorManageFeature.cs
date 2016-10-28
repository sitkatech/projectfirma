using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Indicator")]
    public class IndicatorManageFeature : FirmaFeature
    {
        public IndicatorManageFeature() : base(new List<Role> { Role.SitkaAdmin, Role.Admin }) { }
    }
}