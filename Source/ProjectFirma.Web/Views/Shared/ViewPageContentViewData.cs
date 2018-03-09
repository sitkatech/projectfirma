
using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class ViewPageContentViewData
    {
        public readonly HtmlString FirmaPageContentHtmlString;
        public readonly string FirmaPageDisplayName;
        public readonly bool ShowEditButton;
        public readonly bool HasPageContent;
        public readonly string EditPageContentUrl;

        public ViewPageContentViewData(IFirmaPage firmaPage, bool showEditButton)
        {
            FirmaPageContentHtmlString = firmaPage.FirmaPageContentHtmlString;
            FirmaPageDisplayName = firmaPage.FirmaPageDisplayName;
            ShowEditButton = showEditButton;
            HasPageContent = firmaPage.HasPageContent;
            EditPageContentUrl = firmaPage.GetEditPageContentUrl();
        }        
    }
}
