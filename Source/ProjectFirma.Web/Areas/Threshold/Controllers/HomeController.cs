using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Security;
using ProjectFirma.Web.Areas.Threshold.Views.Home;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;

namespace ProjectFirma.Web.Areas.Threshold.Controllers
{
    public class HomeController : LakeTahoeInfoBaseController
    {
        [AnonymousUnclassifiedFeature]
        public FileResult ExportGridToExcel(string gridName, bool printFooter)
        {
            return ExportGridToExcelImpl(gridName, printFooter);
        }

        [ThresholdIndicatorViewFeature]
        public ViewResult Index()
        {
            return IndexImpl();
        }

        private ViewResult IndexImpl()
        {
            var projectFirmaPage = ProjectFirmaPage.GetProjectFirmaPageByPageType(ProjectFirmaPageType.ThresholdsHome);
            var allThresholdCategories = HttpRequestStorage.DatabaseEntities.ThresholdCategories.OrderBy(p => p.DisplayName).ToList();
            var viewData = new IndexViewData(CurrentPerson, projectFirmaPage, allThresholdCategories);
            return RazorView<Index, IndexViewData>(viewData);
        }
    }
}