using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.Sustainability.Views
{
    public class SustainabilityCommonPageData
    {
        public readonly List<SustainabilityPillar> SustainabilityPillars;
        public readonly string SustainabilityDashboardHomeUrl;
        public readonly string AllSustainabilityIndicatorsUrl;
        public readonly string AboutUrl;
        public readonly string LogInUrl;
        public readonly string LogOutUrl;

        public SustainabilityCommonPageData(List<SustainabilityPillar> sustainabilityPillars, string sustainabilityDashboardHomeUrl, string allSustainabilityIndicatorsUrl, string aboutUrl, string logInUrl, string logOutUrl)
        {
            SustainabilityPillars = sustainabilityPillars;
            SustainabilityDashboardHomeUrl = sustainabilityDashboardHomeUrl;
            LogInUrl = logInUrl;
            LogOutUrl = logOutUrl;
            AllSustainabilityIndicatorsUrl = allSustainabilityIndicatorsUrl;
            AboutUrl = aboutUrl;
        }
    }
}