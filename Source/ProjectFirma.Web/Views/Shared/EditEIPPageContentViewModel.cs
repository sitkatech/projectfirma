using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditEIPPageContentViewModel : FormViewModel
    {
        public HtmlString FirmaPageContent { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditEIPPageContentViewModel()
        {
        }

        public EditEIPPageContentViewModel(FirmaPageType firmaPageType)
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