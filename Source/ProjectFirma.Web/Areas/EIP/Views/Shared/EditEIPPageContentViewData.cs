using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared
{
    public class EditEIPPageContentViewData : EIPViewData
    {
        public readonly string DisplayUrl;

        public EditEIPPageContentViewData(Person currentPerson, ProjectFirmaPageType projectFirmaPageType)
            : base(currentPerson, ProjectFirmaPage.GetProjectFirmaPageByPageType(projectFirmaPageType))
        {
            PageTitle = projectFirmaPageType.ProjectFirmaPageTypeDisplayName;
            DisplayUrl = projectFirmaPageType.GetViewUrl();
        }        
    }
}