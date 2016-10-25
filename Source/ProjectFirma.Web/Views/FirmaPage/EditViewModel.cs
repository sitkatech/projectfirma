using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.FirmaPage
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Definition")]
        public HtmlString FirmaPageContentHtmlString { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }
        
        public EditViewModel(Models.FirmaPage firmaPage)
        {
            FirmaPageContentHtmlString = firmaPage != null ? firmaPage.FirmaPageContentHtmlString : null;
        }

        public void UpdateModel(Models.FirmaPage firmaPage)
        {
            firmaPage.FirmaPageContentHtmlString = FirmaPageContentHtmlString;
        }
    }
}