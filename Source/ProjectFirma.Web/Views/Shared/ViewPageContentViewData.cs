
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.Shared
{
    public class ViewPageContentViewData
    {
        public readonly Models.FirmaPage FirmaPage;
        public readonly bool ShowEditButton;
        public readonly string FirmaPageContentID;
        public readonly string FirmaPageEditHoverButtonID;
        public readonly string EditPageContentUrl;

        public ViewPageContentViewData(Models.FirmaPage firmaPage, Person currentPerson)
        {
            FirmaPage = firmaPage;
            ShowEditButton = new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage).HasPermission;
            FirmaPageContentID = $"firmaPageContent{firmaPage.FirmaPageID}";
            FirmaPageEditHoverButtonID = $"editHoverButton{firmaPage.FirmaPageID}";
            EditPageContentUrl = SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(FirmaPage));
        }        
    }
}
