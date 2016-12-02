using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class PerformanceMeasureNoteController : FirmaBaseController
    {
        [HttpGet]
        [PerformanceMeasureNoteManageFeature]
        public PartialViewResult New(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(PerformanceMeasurePrimaryKey performanceMeasurePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var performanceMeasure = performanceMeasurePrimaryKey.EntityObject;
            var performanceMeasureNote = PerformanceMeasureNote.CreateNewBlank(performanceMeasure);
            viewModel.UpdateModel(performanceMeasureNote, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureNotes.Add(performanceMeasureNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [PerformanceMeasureNoteManageFeature]
        public PartialViewResult Edit(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey)
        {
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(performanceMeasureNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [PerformanceMeasureNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(performanceMeasureNote, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [PerformanceMeasureNoteManageFeature]
        public PartialViewResult DeletePerformanceMeasureNote(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey)
        {
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(performanceMeasureNote.PerformanceMeasureNoteID);
            return ViewDeletePerformanceMeasureNote(performanceMeasureNote, viewModel);
        }

        private PartialViewResult ViewDeletePerformanceMeasureNote(PerformanceMeasureNote performanceMeasureNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !performanceMeasureNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this note for PerformanceMeasure '{0}'?", performanceMeasureNote.PerformanceMeasure.PerformanceMeasureDisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("PerformanceMeasure Note");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [PerformanceMeasureNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeletePerformanceMeasureNote(PerformanceMeasureNotePrimaryKey performanceMeasureNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var performanceMeasureNote = performanceMeasureNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeletePerformanceMeasureNote(performanceMeasureNote, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.PerformanceMeasureNotes.Remove(performanceMeasureNote);
            return new ModalDialogFormJsonResult();
        }
    }
}