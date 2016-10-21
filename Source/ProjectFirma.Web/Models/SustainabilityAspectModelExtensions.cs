using System;
using ProjectFirma.Web.Areas.Sustainability.Controllers;
using ProjectFirma.Web.Common;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public static class SustainabilityAspectModelExtensions
    {
        public static string GetUrl(this SustainabilityAspect aspect)
        {
            return SitkaRoute<AspectController>.BuildUrlFromExpression(x => x.Summary(aspect.SustainabilityAspectName));
        }

        public static string GetHomePageAnchorUrl(this SustainabilityAspect aspect)
        {
            var homeUrl = SitkaRoute<HomeController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Index(), ProjectFirmaWebConfiguration.CanonicalHostNameSustainability);
            return String.Format("{0}#{1}", homeUrl, aspect.SustainabilityAspectName);
        }
    }
}