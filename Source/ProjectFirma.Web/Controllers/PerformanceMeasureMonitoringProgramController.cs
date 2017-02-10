using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.PerformanceMeasureMonitoringProgram;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureMonitoringProgramController : FirmaBaseController
    {
        [HttpGet]
        [PerformanceMeasureManageFeature]
        public PartialViewResult EditPerformanceMeasureMonitoringPrograms(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var performanceMeasureMonitoringProgramsimples = performanceMeasure.PerformanceMeasureMonitoringPrograms.Select(x => new PerformanceMeasureMonitoringProgramSimple(x)).ToList();
            var viewModel = new EditPerformanceMeasureMonitoringProgramsViewModel(performanceMeasureMonitoringProgramsimples);
            return ViewEditPerformanceMeasureMonitoringPrograms(performanceMeasure, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPerformanceMeasureMonitoringPrograms(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditPerformanceMeasureMonitoringProgramsViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPerformanceMeasureMonitoringPrograms(performanceMeasure, viewModel);
            }
            var currentPerformanceMeasureMonitoringPrograms = performanceMeasure.PerformanceMeasureMonitoringPrograms.ToList();
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureMonitoringPrograms.Load();
            var allPerformanceMeasureMonitoringPrograms = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasureMonitoringPrograms.Local;
            viewModel.UpdateModel(currentPerformanceMeasureMonitoringPrograms, allPerformanceMeasureMonitoringPrograms);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPerformanceMeasureMonitoringPrograms(PerformanceMeasure performanceMeasure, EditPerformanceMeasureMonitoringProgramsViewModel viewModel)
        {
            var allMonitoringPrograms = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.ToList().Select(x => new MonitoringProgramSimple(x)).OrderBy(p => p.MonitoringProgramName).ToList();
            var viewData = new EditPerformanceMeasureMonitoringProgramsViewData(performanceMeasure, allMonitoringPrograms);
            return RazorPartialView<EditPerformanceMeasureMonitoringPrograms, EditPerformanceMeasureMonitoringProgramsViewData, EditPerformanceMeasureMonitoringProgramsViewModel>(viewData, viewModel);
        }
    }
}