using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectFirmaPage
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Definition")]
        public HtmlString ProjectFirmaPageContentHtmlString { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditViewModel()
        {
        }
        
        public EditViewModel(Models.ProjectFirmaPage projectFirmaPage)
        {
            ProjectFirmaPageContentHtmlString = projectFirmaPage != null ? projectFirmaPage.ProjectFirmaPageContentHtmlString : null;
        }

        public void UpdateModel(Models.ProjectFirmaPage projectFirmaPage)
        {
            projectFirmaPage.ProjectFirmaPageContentHtmlString = ProjectFirmaPageContentHtmlString;
        }
    }
}