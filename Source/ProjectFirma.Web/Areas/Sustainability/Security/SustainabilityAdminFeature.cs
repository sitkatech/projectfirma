using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Sustainability.Security
{
    [SecurityFeatureDescription("_Admin for Sustainability")]
    public class SustainabilityAdminFeature : SustainabilityFeature
    {
        public SustainabilityAdminFeature() : base(new List<SustainabilityRole> { SustainabilityRole.Admin })
        {
            
        }
    }
}