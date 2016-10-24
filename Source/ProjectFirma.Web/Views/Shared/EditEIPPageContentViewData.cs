using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class EditEIPPageContentViewData : EIPViewData
    {
        public readonly string DisplayUrl;

        public EditEIPPageContentViewData(Person currentPerson, ProjectFirmaPageType projectFirmaPageType)
            : base(currentPerson, Models.ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType))
        {
            PageTitle = projectFirmaPageType.ProjectFirmaPageTypeDisplayName;
            DisplayUrl = projectFirmaPageType.GetViewUrl();
        }        
    }
}