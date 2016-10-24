using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class LakeTahoeInfoSiteExplorerViewData
    {
        public readonly string HomeUrl;

        public LakeTahoeInfoSiteExplorerViewData()
        {
            HomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}