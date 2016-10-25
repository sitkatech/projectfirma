using System.Web;

namespace ProjectFirma.Web.Views.FirmaPage
{
    public class FirmaPageDetailsViewData : FirmaUserControlViewData
    {
        public readonly HtmlString FirmaPageContent;

        public FirmaPageDetailsViewData(HtmlString firmaPageContent)
        {
            FirmaPageContent = firmaPageContent;
        }
    }
}