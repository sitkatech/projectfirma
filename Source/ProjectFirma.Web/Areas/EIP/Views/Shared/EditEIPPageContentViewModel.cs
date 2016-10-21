using System.Web;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared
{
    public class EditEIPPageContentViewModel : FormViewModel
    {
        public HtmlString ProjectFirmaPageContent { get; set; }

        /// <summary>
        /// Needed by model binder
        /// </summary>
        public EditEIPPageContentViewModel()
        {
        }

        public EditEIPPageContentViewModel(ProjectFirmaPageType projectFirmaPageType)
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType);
            ProjectFirmaPageContent = projectFirmaPage.ProjectFirmaPageContentHtmlString;
        }

        public void UpdateModel(ProjectFirmaPageType projectFirmaPageType, Person currentPerson)
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType);
            projectFirmaPage.ProjectFirmaPageContentHtmlString = ProjectFirmaPageContent;
        }
    }
}