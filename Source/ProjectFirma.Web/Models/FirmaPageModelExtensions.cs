using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public static class FirmaPageModelExtensions
    {
        public static string GetEditPageContentUrl(this FirmaPage firmaPage)
        {
            return SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(firmaPage));
        }
    }
}