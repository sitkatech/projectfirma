using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Manage Indicator")]
    public class IndicatorManageFeature : EIPFeature
    {
        public IndicatorManageFeature() : base(new List<EIPRole> { EIPRole.Admin }) { }
    }
}