using System.Web;

namespace ProjectFirma.Web.Models
{
    public interface IFirmaPage
    {
        HtmlString GetFirmaPageContentHtmlString();
        string GetFirmaPageDisplayName();
        bool HasPageContent();
        string GetEditPageContentUrl();
    }
}