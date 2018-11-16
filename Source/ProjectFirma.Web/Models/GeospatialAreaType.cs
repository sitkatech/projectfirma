using System.Web;

namespace ProjectFirma.Web.Models
{
    public partial class GeospatialAreaType : IFirmaPage
    {
        public HtmlString FirmaPageContentHtmlString => GeospatialAreaIntroContentHtmlString;

        public string FirmaPageDisplayName => GeospatialAreaTypeName;
        public bool HasPageContent => !string.IsNullOrWhiteSpace(GeospatialAreaIntroContent);

        public string GetEditPageContentUrl()
        {
            return string.Empty;
        }
    }
}