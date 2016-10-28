using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditPageContentViewModel : FormViewModel
    {
        public HtmlString FirmaPageContent { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditPageContentViewModel()
        {
        }

        public EditPageContentViewModel(FirmaPageType firmaPageType)
        {
            var firmaPage = Models.FirmaPage.GetFirmaPageByPageType(firmaPageType);
            FirmaPageContent = firmaPage.FirmaPageContentHtmlString;
        }

        public void UpdateModel(FirmaPageType firmaPageType, Person currentPerson)
        {
            var firmaPage = Models.FirmaPage.GetFirmaPageByPageType(firmaPageType);
            firmaPage.FirmaPageContentHtmlString = FirmaPageContent;
        }
    }
}