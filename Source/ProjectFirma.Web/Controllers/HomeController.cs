using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.EIP.Security;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Home;
using ProjectFirma.Web.Security.Shared;
using Error = ProjectFirma.Web.Views.Shared.Error;
using ErrorViewData = ProjectFirma.Web.Views.Shared.ErrorViewData;
using Index = ProjectFirma.Web.Views.Home.Index;
using IndexViewData = ProjectFirma.Web.Views.Home.IndexViewData;
using NotFound = ProjectFirma.Web.Views.Shared.NotFound;
using NotFoundViewData = ProjectFirma.Web.Views.Shared.NotFoundViewData;

namespace ProjectFirma.Web.Controllers
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
            var sustainabilityPillars = HttpRequestStorage.DatabaseEntities.SustainabilityPillars.ToList();
            var userCanViewThresholds = new ThresholdIndicatorViewFeature().HasPermissionByPerson(CurrentPerson);
            var viewData = new IndexViewData(CurrentPerson, sustainabilityPillars, userCanViewThresholds);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [Route("About", Name = "LakeTahoeInfo_About", Order = 1)]
        [AnonymousUnclassifiedFeature]
        public ViewResult About()
        {
            var viewData = new AboutViewData(CurrentPerson);
            return RazorView<About, AboutViewData>(viewData);
        }

        [Route("DataCenter", Name = "LakeTahoeInfo_DataCenter", Order = 1)]
        [IndicatorViewFeature]
        public ViewResult DataCenter()
        {
            var viewData = new DataCenterViewData(CurrentPerson);
            return RazorView<DataCenter, DataCenterViewData>(viewData);
        }


        [AnonymousUnclassifiedFeature]
        public ViewResult Error()
        {
            var viewData = new ErrorViewData(CurrentPerson);
            return RazorView<Error, ErrorViewData>(viewData);
        }

        [AnonymousUnclassifiedFeature]
        public ViewResult NotFound()
        {
            var viewData = new NotFoundViewData(CurrentPerson);
            return RazorView<NotFound, NotFoundViewData>(viewData);
        }
    }
}