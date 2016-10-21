using ProjectFirma.Web.Areas.Sustainability.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Sustainability.Views.Home
{
    public class EditAboutViewData : SustainabilityDashboardViewData
    {
        public readonly string CancelUrl;
        public EditAboutViewData(Person currentPerson, SustainabilityCommonPageData sustainabilityCommonPageData)
            : base(currentPerson, sustainabilityCommonPageData, "secondary-header")
        {
            PageTitle = "About the Sustainability Dashboard";
            IsEditButtonVisible = false;
            CancelUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(c => c.About());
        }
    }
}