using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Sustainability.Security
{
    [SecurityFeatureDescription("Manage Sustainability Dashboard")]
    public class SustainabilityDashboardManageFeature : SustainabilityFeature
    {
        public SustainabilityDashboardManageFeature() : base(new List<SustainabilityRole> { SustainabilityRole.Admin })
        {
            
        }
    }
}