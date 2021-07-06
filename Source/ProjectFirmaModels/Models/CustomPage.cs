using System.Collections.Generic;
using System.Web;

namespace ProjectFirmaModels.Models
{
    public partial class CustomPage : IFirmaPage, IAuditableEntity, IHaveASortOrder
    {
        public HtmlString GetFirmaPageContentHtmlString() => CustomPageContentHtmlString;
        public string GetFirmaPageDisplayName() => CustomPageDisplayName;
        public bool HasPageContent() => !string.IsNullOrWhiteSpace(CustomPageContent);

        public string GetAuditDescriptionString() => $"Custom About Page: {CustomPageDisplayName}";

        public string GetDisplayName() => CustomPageDisplayName;

        public void SetSortOrder(int? value) => SortOrder = value;

        public int? GetSortOrder() => SortOrder;

        public int GetID() => CustomPageID;
    }
}