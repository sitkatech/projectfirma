using System.Web;

namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaType : IFirmaPage, IAuditableEntity
    {
        public HtmlString GetFirmaPageContentHtmlString() => GeospatialAreaIntroContentHtmlString;

        public string GetFirmaPageDisplayName() => GeospatialAreaTypeName;
        public bool HasPageContent() => !string.IsNullOrWhiteSpace(GeospatialAreaIntroContent);

        public string GetAuditDescriptionString() => GeospatialAreaTypeName;
    }
}