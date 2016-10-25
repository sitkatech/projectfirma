using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProgramEIPPerformanceMeasure;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProgramEIPPerformanceMeasureController : FirmaBaseController
    {
        [HttpGet]
        [ProgramEIPPerformanceMeasureManageFeature]
        public PartialViewResult EditPrograms(EIPPerformanceMeasurePrimaryKey eipPerformanceMeasurePrimaryKey)
        {
            var eipPerformanceMeasure = eipPerformanceMeasurePrimaryKey.EntityObject;
            var programEIPPerformanceMeasureSimples = eipPerformanceMeasure.ProgramEIPPerformanceMeasures.Select(x => new ProgramEIPPerformanceMeasureSimple(x)).ToList();
            var primaryProgramID = eipPerformanceMeasure.PrimaryProgram != null ? eipPerformanceMeasure.PrimaryProgram.ProgramID : (int?) null;
            var viewModel = new EditProgramsViewModel(programEIPPerformanceMeasureSimples, primaryProgramID);
            return ViewEditPrograms(viewModel, eipPerformanceMeasure);
        }

        [HttpPost]
        [ProgramEIPPerformanceMeasureManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPrograms(EIPPerformanceMeasurePrimaryKey eipPerformanceMeasurePrimaryKey, EditProgramsViewModel viewModel)
        {
            var eipPerformanceMeasure = eipPerformanceMeasurePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditPrograms(viewModel, eipPerformanceMeasure);
            }
            HttpRequestStorage.DatabaseEntities.ProgramEIPPerformanceMeasures.Load();
            viewModel.UpdateModel(eipPerformanceMeasure.ProgramEIPPerformanceMeasures.ToList(), HttpRequestStorage.DatabaseEntities.ProgramEIPPerformanceMeasures.Local);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPrograms(EditProgramsViewModel viewModel, EIPPerformanceMeasure eipPerformanceMeasure)
        {
            var allPrograms = HttpRequestStorage.DatabaseEntities.Programs.ToList().OrderBy(p => p.DisplayName).ToList();
            var programSimples = allPrograms.Select(x => new ProgramSimple(x)).ToList();
            var viewData = new EditProgramsViewData(new EIPPerformanceMeasureSimple(eipPerformanceMeasure), programSimples);
            return RazorPartialView<EditPrograms, EditProgramsViewData, EditProgramsViewModel>(viewData, viewModel);
        }
    }
}