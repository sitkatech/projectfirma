using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Areas.Sustainability.Security
{    
    public abstract class SustainabilityFeature : LakeTahoeInfoBaseFeature
    {
        protected SustainabilityFeature(IEnumerable<SustainabilityRole> roles) : base(roles.Select(x => (IRole)x).ToList(), LTInfoArea.Sustainability) { }
    }
}