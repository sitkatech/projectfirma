using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Threshold.Security
{    
    public abstract class ThresholdFeature : LakeTahoeInfoBaseFeature
    {
        protected ThresholdFeature(IEnumerable<ThresholdRole> roles) : base(roles.Select(x => (IRole)x).ToList(), LTInfoArea.Threshold) { }
    }
}