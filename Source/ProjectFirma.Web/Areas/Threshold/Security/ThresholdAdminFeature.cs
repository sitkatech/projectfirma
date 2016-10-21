using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Threshold.Security
{
    [SecurityFeatureDescription("Admin for Thresholds")]
    public class ThresholdAdminFeature : ThresholdFeature
    {
        public ThresholdAdminFeature() : base(new List<ThresholdRole> { ThresholdRole.Admin })
        {            
        }
    }
}