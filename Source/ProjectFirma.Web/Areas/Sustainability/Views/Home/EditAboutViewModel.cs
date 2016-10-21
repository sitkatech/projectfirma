using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Home
{
    public class EditAboutViewModel : FormViewModel
    {
        [Required]
        public HtmlString IntroHtmlString { get; set; }
        [Required]
        public HtmlString AboutHtmlString { get; set; }
        [Required]
        public HtmlString FaqHtmlString { get; set; }

        public EditAboutViewModel()
        {
            IntroHtmlString = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutIntro).ProjectFirmaPageContentHtmlString;
            AboutHtmlString = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutContent).ProjectFirmaPageContentHtmlString; ;
            FaqHtmlString = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutFAQ).ProjectFirmaPageContentHtmlString; ;
        }

        public void UpdateModel()
        {
            ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutIntro).ProjectFirmaPageContentHtmlString = IntroHtmlString;
            ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutContent).ProjectFirmaPageContentHtmlString = AboutHtmlString;
            ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutFAQ).ProjectFirmaPageContentHtmlString = FaqHtmlString;
        }
    }
}