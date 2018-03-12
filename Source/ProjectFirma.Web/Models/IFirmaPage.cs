using System.Web;

namespace ProjectFirma.Web.Models
{
    public interface IFirmaPage
    {
        HtmlString FirmaPageContentHtmlString { get; }
        string FirmaPageDisplayName { get; }
        bool HasPageContent { get; }
        string GetEditPageContentUrl();
    }
}