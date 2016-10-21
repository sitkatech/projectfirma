using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Threshold.Security
{
    [SecurityFeatureDescription("View Threshold Indicator")]
    public class ThresholdIndicatorViewFeature : ThresholdFeature
    {
        public ThresholdIndicatorViewFeature() : base(new List<ThresholdRole> { ThresholdRole.Normal, ThresholdRole.Admin })
        {            
        }
    }
}