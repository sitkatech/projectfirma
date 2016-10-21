using System.Web;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Home
{
    public class AboutViewData : SiteLayoutViewData
    {
        public readonly HtmlString AboutLTInfoHtmlString;
        public AboutViewData(Person currentPerson)
            : base(currentPerson)
        {
            PageTitle = "What is Lake Tahoe Info?";
            AboutLTInfoHtmlString = Models.ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.LTInfoAbout).ProjectFirmaPageContentHtmlString;
        }
    }
}