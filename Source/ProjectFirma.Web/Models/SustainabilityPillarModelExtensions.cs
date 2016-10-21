using System;
using ProjectFirma.Web.Areas.Sustainability.Controllers;
using ProjectFirma.Web.Common;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class SustainabilityPillarModelExtensions
    {
        public static string GetHomePageAnchorUrl(this SustainabilityPillar pillar)
        {
            return String.Format("{0}#{1}", SitkaRoute<HomeController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Index(), ProjectFirmaWebConfiguration.CanonicalHostNameSustainability), pillar.SustainabilityPillarName);
        }
    }
}