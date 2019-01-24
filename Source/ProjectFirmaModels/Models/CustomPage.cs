using System.Web;

namespace ProjectFirmaModels.Models
{
    public partial class CustomPage : IFirmaPage, IAuditableEntity
    {
        public HtmlString GetFirmaPageContentHtmlString() => CustomPageContentHtmlString;
        public string GetFirmaPageDisplayName() => CustomPageDisplayName;
        public bool HasPageContent() => !string.IsNullOrWhiteSpace(CustomPageContent);

        public string GetAuditDescriptionString() => $"Custom About Page: {CustomPageDisplayName}";
    }
}