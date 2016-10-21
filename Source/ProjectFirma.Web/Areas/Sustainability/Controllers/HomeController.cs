using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Sustainability.Security;
using ProjectFirma.Web.Areas.Sustainability.Views;
using ProjectFirma.Web.Areas.Sustainability.Views.Home;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security.Shared;
using LtInfo.Common;
using About = ProjectFirma.Web.Areas.Sustainability.Views.Home.About;
using AboutViewData = ProjectFirma.Web.Areas.Sustainability.Views.Home.AboutViewData;
using Index = ProjectFirma.Web.Areas.Sustainability.Views.Home.Index;
using IndexViewData = ProjectFirma.Web.Areas.Sustainability.Views.Home.IndexViewData;

namespace ProjectFirma.Web.Areas.Sustainability.Controllers
{
    public class HomeController : LakeTahoeInfoBaseController
    {
        [AnonymousUnclassifiedFeature]
        public FileResult ExportGridToExcel(string gridName, bool printFooter)
        {
            return ExportGridToExcelImpl(gridName, printFooter);
        }

        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson, GetSustainabilityCommonPageData());
            return RazorView<Index, IndexViewData>(viewData);
        }

        [Route("About", Name = "Sustainability_About", Order = 1)]
        [HttpGet]
        [AnonymousUnclassifiedFeature]
        public ViewResult About()
        {
            var viewData = new AboutViewData(CurrentPerson, GetSustainabilityCommonPageData());
            return RazorView<About, AboutViewData>(viewData);
        }

        [Route("About/Edit", Name = "Sustainability_EditAbout", Order = 1)]
        [HttpGet]
        [SustainabilityDashboardManageFeature]
        public ViewResult EditAbout()
        {
            var viewData = new EditAboutViewData(CurrentPerson, GetSustainabilityCommonPageData());
            var viewModel = new EditAboutViewModel();
            return RazorView<EditAbout, EditAboutViewData, EditAboutViewModel>(viewData, viewModel);
        }

        [Route("About/Edit", Name = "Sustainability_EditAbout", Order = 1)]
        [HttpPost]
        [SustainabilityDashboardManageFeature]
        public ActionResult EditAbout(EditAboutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RazorView<EditAbout, EditAboutViewData, EditAboutViewModel>(new EditAboutViewData(CurrentPerson, GetSustainabilityCommonPageData()), viewModel);
            }

            viewModel.UpdateModel();
            return RazorView<About, AboutViewData>(new AboutViewData(CurrentPerson, GetSustainabilityCommonPageData()));
        }

        public static SustainabilityCommonPageData GetSustainabilityCommonPageData()
        {
            var pillars = HttpRequestStorage.DatabaseEntities.SustainabilityPillars.ToList();
            var sustainabilityDashboardHomeUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.Index());
            var allSustainabilityIndicatorsUrl = SitkaRoute<AspectController>.BuildUrlFromExpression(x => x.AllIndicators());
            var aboutUrl = SitkaRoute<HomeController>.BuildUrlFromExpression(x => x.About());
            var logInUrl = ProjectFirmaHelpers.GenerateLogInUrlWithReturnUrl();
            var logOutUrl = ProjectFirmaHelpers.GenerateLogOutUrlWithReturnUrl();
            return new SustainabilityCommonPageData(pillars, sustainabilityDashboardHomeUrl, allSustainabilityIndicatorsUrl, aboutUrl, logInUrl, logOutUrl);
        }
    }
}