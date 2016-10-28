using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class DisplayPageContentViewData : FirmaViewData
    {
        public readonly bool ShowEditButton;
        public readonly string EditUrl;

        public DisplayPageContentViewData(Person currentPerson, FirmaPageType firmaPageType) : base(currentPerson, Models.FirmaPage.GetFirmaPageByPageType(firmaPageType))
        {
            PageTitle = firmaPageType.FirmaPageTypeDisplayName;
            ShowEditButton = new FirmaPageManageFeature().HasPermission(currentPerson, Models.FirmaPage.GetFirmaPageByPageType(firmaPageType)).HasPermission;
            EditUrl = SitkaRoute<Controllers.HomeController>.BuildUrlFromExpression(x => x.EditPageContent(firmaPageType.ToEnum));
        }
    }
}