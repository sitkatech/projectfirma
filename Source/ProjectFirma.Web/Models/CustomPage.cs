using System.Web;

namespace ProjectFirma.Web.Models
{
    public partial class CustomPage : IFirmaPage, IAuditableEntity
    {
        public HtmlString GetFirmaPageContentHtmlString() => CustomPageContentHtmlString;
        public string GetFirmaPageDisplayName() => CustomPageDisplayName;
        public bool HasPageContent() => !string.IsNullOrWhiteSpace(CustomPageContent);

        public string GetEditPageContentUrl()
        {
            return CustomPageModelExtensions.GetEditPageContentUrl(this);
        }

        public string GetAuditDescriptionString() => $"Custom About Page: {CustomPageDisplayName}";
    }
}