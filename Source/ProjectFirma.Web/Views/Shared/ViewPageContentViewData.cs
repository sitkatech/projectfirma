using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

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
            FirmaPageContentHtmlString = firmaPage.GetFirmaPageContentHtmlString();
            FirmaPageDisplayName = firmaPage.GetFirmaPageDisplayName();
            ShowEditButton = showEditButton;
            HasPageContent = firmaPage.HasPageContent();
            EditPageContentUrl = firmaPage.GetEditPageContentUrl();
        }

        public ViewPageContentViewData(Models.FirmaPage firmaPage, Person currentPerson)
            : this(firmaPage, new FirmaPageManageFeature().HasPermission(currentPerson, firmaPage).HasPermission)
        {
        }
    }
}
