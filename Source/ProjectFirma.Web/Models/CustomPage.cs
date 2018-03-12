using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class CustomPage : IFirmaPage, IAuditableEntity
    {
        public HtmlString FirmaPageContentHtmlString => CustomPageContentHtmlString;
        public string FirmaPageDisplayName => CustomPageDisplayName;
        public bool HasPageContent => !string.IsNullOrWhiteSpace(CustomPageContent);

        public static FirmaPage GetFirmaPageByPageType(FirmaPageType firmaPageType)
        {
            var firmaPage = HttpRequestStorage.DatabaseEntities.FirmaPages.SingleOrDefault(x => x.FirmaPageTypeID == firmaPageType.FirmaPageTypeID);
            Check.RequireNotNull(firmaPage);
            return firmaPage;
        }

        public string GetEditPageContentUrl()
        {
            return SitkaRoute<CustomPageController>.BuildUrlFromExpression(t => t.EditInDialog(this));
        }

        public string AboutPageUrl => SitkaRoute<CustomPageController>.BuildUrlFromExpression(t => t.About(CustomPageVanityUrl));        

        public string DeleteUrl => SitkaRoute<CustomPageController>.BuildUrlFromExpression(c => c.DeleteCustomPage(CustomPageID));

        public string AuditDescriptionString => $"Custom About Page: {CustomPageDisplayName}";
    }
}