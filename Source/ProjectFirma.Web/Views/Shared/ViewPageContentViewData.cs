
using System.Web;

namespace ProjectFirma.Web.Views.Shared
{
    public class ViewPageContentViewData
    {
        public readonly HtmlString FirmaPageContentHtmlString;
        public readonly string FirmaPageDisplayName;
        public readonly bool ShowEditButton;
        public readonly bool HasPageContent;
        public readonly string FirmaPageContentID;
        public readonly string FirmaPageEditHoverButtonID;
        public readonly string EditPageContentUrl;

        public ViewPageContentViewData(Models.FirmaPage firmaPage, bool showEditButton)
        {
            FirmaPageContentHtmlString = firmaPage.FirmaPageContentHtmlString;
            FirmaPageDisplayName = firmaPage.FirmaPageType.FirmaPageTypeDisplayName;
            ShowEditButton = showEditButton;
            HasPageContent = firmaPage.HasFirmaPageContent;
            FirmaPageContentID = $"firmaPageContent{firmaPage.FirmaPageID}";
            FirmaPageEditHoverButtonID = $"editHoverButton{firmaPage.FirmaPageID}";
            EditPageContentUrl = firmaPage.GetEditInDialogUrl();
        }        
    }
}
