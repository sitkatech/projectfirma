using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class LakeTahoeInfoSiteExplorerViewData
    {
        public readonly string HomeUrl;
        public readonly LTInfoArea LTInfoArea;
        public readonly string DataCenterUrl;

        public LakeTahoeInfoSiteExplorerViewData(LTInfoArea ltInfoArea)
        {
            HomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Index());
            LTInfoArea = ltInfoArea;
            DataCenterUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.DataCenter());
        }
    }
}