using System.Web;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Home
{
    public class IndexViewData : SustainabilityDashboardViewData
    {
        public readonly HtmlString SustainabilityIntroHtmlString;
        public IndexViewData(Person currentPerson, SustainabilityCommonPageData sustainabilityCommonPageData) : base(currentPerson, sustainabilityCommonPageData)
        {
            PageTitle = "Sustainability Dashboard";
            SustainabilityIntroHtmlString = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.SIDHome).ProjectFirmaPageContentHtmlString;
        }
    }
}