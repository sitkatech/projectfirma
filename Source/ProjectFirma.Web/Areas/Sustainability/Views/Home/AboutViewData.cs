using System.Web;
using ProjectFirma.Web.Areas.Sustainability.Controllers;
using ProjectFirma.Web.Areas.Sustainability.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Home
{
    public class AboutViewData : SustainabilityDashboardViewData
    {
        public readonly HtmlString IntroHtmlString;
        public readonly HtmlString AboutHtmlString;
        public readonly HtmlString FaqHtmlString;

        public AboutViewData(Person currentPerson, SustainabilityCommonPageData sustainabilityCommonPageData)
            : base(currentPerson, sustainabilityCommonPageData, "secondary-header")
        {
            PageTitle = "About the Sustainability Dashboard";
            IntroHtmlString = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutIntro).ProjectFirmaPageContentHtmlString;
            AboutHtmlString = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutContent).ProjectFirmaPageContentHtmlString;
            FaqHtmlString = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDAboutFAQ).ProjectFirmaPageContentHtmlString;

            IsEditButtonVisible = new SustainabilityDashboardManageFeature().HasPermissionByPerson(currentPerson);
            EditUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.EditAbout());
        }
    }
}