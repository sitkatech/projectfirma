using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.FirmaPage
{
    public class IndexViewData : FirmaViewData
    {
        public readonly FirmaPageGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string FirmaPageUrl;

        public IndexViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage, false)
        {
            PageTitle = "Manage Page Content";

            GridSpec = new FirmaPageGridSpec(new FirmaPageViewListFeature().HasPermissionByPerson(currentPerson))
            {
                ObjectNameSingular = "Page",
                ObjectNamePlural = "Pages",
                SaveFiltersInCookie = true
            };
            GridName = "firmaPagesGrid";
            GridDataUrl = SitkaRoute<FirmaPageController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            FirmaPageUrl = SitkaRoute<FirmaPageController>.BuildUrlFromExpression(x => x.FirmaPageDetails(UrlTemplate.Parameter1Int));
        }
    }
}