using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProgramPerformanceMeasure;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramPerformanceMeasureController : FirmaBaseController
    {
        [HttpGet]
        [ProgramPerformanceMeasureManageFeature]
        public PartialViewResult EditPrograms(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var programPerformanceMeasureSimples = performanceMeasure.ProgramPerformanceMeasures.Select(x => new ProgramPerformanceMeasureSimple(x)).ToList();
            var primaryProgramID = performanceMeasure.PrimaryProgram != null ? performanceMeasure.PrimaryProgram.ProgramID : (int?) null;
            var viewModel = new EditProgramsViewModel(programPerformanceMeasureSimples, primaryProgramID);
            return ViewEditPrograms(viewModel, performanceMeasure);
        }

        [HttpPost]
        [ProgramPerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPrograms(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditProgramsViewModel viewModel)
        {
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPrograms(viewModel, performanceMeasure);
            }
            HttpRequestStorage.DatabaseEntities.ProgramPerformanceMeasures.Load();
            viewModel.UpdateModel(performanceMeasure.ProgramPerformanceMeasures.ToList(), HttpRequestStorage.DatabaseEntities.ProgramPerformanceMeasures.Local);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPrograms(EditProgramsViewModel viewModel, PerformanceMeasure performanceMeasure)
        {
            var allPrograms = HttpRequestStorage.DatabaseEntities.Programs.ToList().OrderBy(p => p.DisplayName).ToList();
            var programSimples = allPrograms.Select(x => new ProgramSimple(x)).ToList();
            var viewData = new EditProgramsViewData(new PerformanceMeasureSimple(performanceMeasure), programSimples);
            return RazorPartialView<EditPrograms, EditProgramsViewData, EditProgramsViewModel>(viewData, viewModel);
        }
    }
}