using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : LakeTahoeInfoBaseViewData
    {
        public readonly List<SustainabilityPillar> SustainabilityPillars;
        public readonly LakeTahoeInfoNavBarViewData LakeTahoeInfoNavBarViewData;
        public readonly bool UserCanViewThresholds;

        public IndexViewData(Person currentPerson, List<SustainabilityPillar> sustainabilityPillars, bool userCanViewThresholds) : base(currentPerson, LTInfoArea.LTInfo)
        {
            PageTitle = "Lake Tahoe Info";
            SustainabilityPillars = sustainabilityPillars;
            UserCanViewThresholds = userCanViewThresholds;
            LakeTahoeInfoNavBarViewData = new LakeTahoeInfoNavBarViewData(currentPerson, false, true, LogInUrl, LogOutUrl, RequestSupportUrl);
        }
    }
}