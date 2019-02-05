using System.Web;

namespace ProjectFirmaModels.Models
{
    public interface IFirmaPage
    {
        HtmlString GetFirmaPageContentHtmlString();
        string GetFirmaPageDisplayName();
        bool HasPageContent();
    }
}