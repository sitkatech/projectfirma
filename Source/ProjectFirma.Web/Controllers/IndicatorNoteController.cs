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
    public class IndicatorNoteController : LakeTahoeInfoBaseController
    {
        [HttpGet]
        [IndicatorNoteManageFeature]
        public PartialViewResult New(IndicatorPrimaryKey indicatorPrimaryKey)
        {
            var viewModel = new EditNoteViewModel();
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [IndicatorNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult New(IndicatorPrimaryKey indicatorPrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var indicator = indicatorPrimaryKey.EntityObject;
            var indicatorNote = IndicatorNote.CreateNewBlank(indicator);
            viewModel.UpdateModel(indicatorNote, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.IndicatorNotes.Add(indicatorNote);
            return new ModalDialogFormJsonResult();
        }

        [HttpGet]
        [IndicatorNoteManageFeature]
        public PartialViewResult Edit(IndicatorNotePrimaryKey indicatorNotePrimaryKey)
        {
            var indicatorNote = indicatorNotePrimaryKey.EntityObject;
            var viewModel = new EditNoteViewModel(indicatorNote.Note);
            return ViewEdit(viewModel);
        }

        [HttpPost]
        [IndicatorNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(IndicatorNotePrimaryKey indicatorNotePrimaryKey, EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            var indicatorNote = indicatorNotePrimaryKey.EntityObject;
            viewModel.UpdateModel(indicatorNote, CurrentPerson);
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEdit(EditNoteViewModel viewModel)
        {
            var viewData = new EditNoteViewData();
            return RazorPartialView<EditNote, EditNoteViewData, EditNoteViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [IndicatorNoteManageFeature]
        public PartialViewResult DeleteIndicatorNote(IndicatorNotePrimaryKey indicatorNotePrimaryKey)
        {
            var indicatorNote = indicatorNotePrimaryKey.EntityObject;
            var viewModel = new ConfirmDialogFormViewModel(indicatorNote.IndicatorNoteID);
            return ViewDeleteIndicatorNote(indicatorNote, viewModel);
        }

        private PartialViewResult ViewDeleteIndicatorNote(IndicatorNote indicatorNote, ConfirmDialogFormViewModel viewModel)
        {
            var canDelete = !indicatorNote.HasDependentObjects();
            var confirmMessage = canDelete
                ? string.Format("Are you sure you want to delete this note for Indicator '{0}'?", indicatorNote.Indicator.IndicatorDisplayName)
                : ConfirmDialogFormViewData.GetStandardCannotDeleteMessage("Indicator Note");

            var viewData = new ConfirmDialogFormViewData(confirmMessage, canDelete);

            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [IndicatorNoteManageFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteIndicatorNote(IndicatorNotePrimaryKey indicatorNotePrimaryKey, ConfirmDialogFormViewModel viewModel)
        {
            var indicatorNote = indicatorNotePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewDeleteIndicatorNote(indicatorNote, viewModel);
            }
            HttpRequestStorage.DatabaseEntities.IndicatorNotes.Remove(indicatorNote);
            return new ModalDialogFormJsonResult();
        }
    }
}