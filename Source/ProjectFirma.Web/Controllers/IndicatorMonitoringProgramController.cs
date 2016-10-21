using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.IndicatorMonitoringProgram;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class IndicatorMonitoringProgramController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [IndicatorManageFeature]
        public PartialViewResult EditIndicatorMonitoringPrograms(IndicatorPrimaryKey indicatorPrimaryKey)
        {
            var indicator = indicatorPrimaryKey.EntityObject;
            var indicatorMonitoringProgramsimples = indicator.IndicatorMonitoringPrograms.Select(x => new IndicatorMonitoringProgramSimple(x)).ToList();
            var viewModel = new EditIndicatorMonitoringProgramsViewModel(indicatorMonitoringProgramsimples);
            return ViewEditIndicatorMonitoringPrograms(indicator, viewModel);
        }

        [HttpPost]
        [IndicatorManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditIndicatorMonitoringPrograms(IndicatorPrimaryKey indicatorPrimaryKey, EditIndicatorMonitoringProgramsViewModel viewModel)
        {
            var indicator = indicatorPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditIndicatorMonitoringPrograms(indicator, viewModel);
            }
            var currentIndicatorMonitoringPrograms = indicator.IndicatorMonitoringPrograms.ToList();
            HttpRequestStorage.DatabaseEntities.IndicatorMonitoringPrograms.Load();
            var allIndicatorMonitoringPrograms = HttpRequestStorage.DatabaseEntities.IndicatorMonitoringPrograms.Local;
            viewModel.UpdateModel(currentIndicatorMonitoringPrograms, allIndicatorMonitoringPrograms);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditIndicatorMonitoringPrograms(Indicator indicator, EditIndicatorMonitoringProgramsViewModel viewModel)
        {
            var allMonitoringPrograms = HttpRequestStorage.DatabaseEntities.MonitoringPrograms.ToList().Select(x => new MonitoringProgramSimple(x)).OrderBy(p => p.MonitoringProgramName).ToList();
            var viewData = new EditIndicatorMonitoringProgramsViewData(indicator, allMonitoringPrograms);
            return RazorPartialView<EditIndicatorMonitoringPrograms, EditIndicatorMonitoringProgramsViewData, EditIndicatorMonitoringProgramsViewModel>(viewData, viewModel);
        }
    }
}